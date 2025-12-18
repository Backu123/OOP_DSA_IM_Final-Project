using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextFont = iTextSharp.text.Font;


namespace QR_Generator_Test_C_
{
    public partial class EventPanel : Form
    {
        private string eventID;
        private string eventName;
        public EventPanel(string eventID)
        {
            InitializeComponent();
            this.eventID = eventID;
        }
        private void ExportAttendanceToSinglePDF()
        {
            DB db = new DB();
            MySqlConnection conn = db.GetConnection();
            string query = "select EventTitle from events where EventID = @eventID";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@eventID", eventID);
            try
            {
                db.OpenConnection();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    eventName = reader["EventTitle"].ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf",
                FileName = $"{eventName}.pdf"
            };

            if (sfd.ShowDialog() != DialogResult.OK) return;

            Document doc = new Document(PageSize.A4, 15f, 15f, 20f, 10f);
            PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
            doc.Open();

            iTextFont titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
            Paragraph title = new Paragraph("EVENT ATTENDANCE REPORT\n\n", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);

            // Event info
            iTextFont infoFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);
            doc.Add(new Paragraph($"Event ID: {eventID}", infoFont));
            doc.Add(new Paragraph($"Generated on: {DateTime.Now:MMMM dd, yyyy}\n\n", infoFont));

            // WHOLE LIST (combine present + absent)
            DataGridView allDGV = new DataGridView();
            allDGV.Columns.Add("Student_ID", "Student_ID");
            allDGV.Columns.Add("Student_Name", "Student_Name");

            foreach (DataGridViewRow row in PresentDGV.Rows)
                if (!row.IsNewRow)
                    allDGV.Rows.Add(row.Cells[0].Value, row.Cells[1].Value);

            foreach (DataGridViewRow row in AbsentDGV.Rows)
                if (!row.IsNewRow)
                    allDGV.Rows.Add(row.Cells[0].Value, row.Cells[1].Value);

            AddDGVSectionToPDF(doc, allDGV, "ALL REGISTERED STUDENTS");
            AddDGVSectionToPDF(doc, PresentDGV, "PRESENT STUDENTS");
            AddDGVSectionToPDF(doc, AbsentDGV, "ABSENT STUDENTS");

            doc.Close();

            MessageBox.Show("Attendance PDF successfully created!");
        }

        private void AddDGVSectionToPDF(Document doc, DataGridView dgv, string sectionTitle)
        {
            // Space before section
            doc.Add(new Paragraph("\n"));

            // Section title
            iTextFont sectionFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
            Paragraph sectionHeader = new Paragraph(sectionTitle, sectionFont);
            sectionHeader.Alignment = Element.ALIGN_LEFT;
            doc.Add(sectionHeader);

            // Small space after title
            doc.Add(new Paragraph("\n"));

            // Create table
            PdfPTable table = new PdfPTable(dgv.Columns.Count);
            table.WidthPercentage = 100;
            table.SpacingBefore = 5f;
            table.SpacingAfter = 10f;

            // Header font
            iTextFont headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
            iTextFont cellFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);

            // Add headers
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                PdfPCell headerCell = new PdfPCell(new Phrase(col.HeaderText, headerFont));
                headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                headerCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                table.AddCell(headerCell);
            }

            // Add rows
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    table.AddCell(new Phrase(cell.Value?.ToString() ?? "", cellFont));
                }
            }

            doc.Add(table);
        }



        private string FormatStudentID(string rawID)
        {
            int id = int.Parse(rawID);
            return $"0325-{id:0000}";
        }


        private void SIgn_Up_Load(object sender, EventArgs e)
        {
            PresentDGV.Columns.Add("Student_ID", "Student_ID");
            PresentDGV.Columns.Add("Student_Name", "Student_Name");
            PresentDGV.Columns["Student_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PresentDGV.Columns["Student_ID"].Width = 90;

            AbsentDGV.Columns.Add("Student_ID", "Student_ID");
            AbsentDGV.Columns.Add("Student_Name", "Student_Name");
            AbsentDGV.Columns["Student_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            AbsentDGV.Columns["Student_ID"].Width = 90;

            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button2.FlatAppearance.MouseDownBackColor = Color.Transparent;

            DB db = new DB();
            MySqlConnection conn = db.GetConnection();
            try
            {
                db.OpenConnection();

                // PRESENT
                string presentQuery = @"SELECT Student_ID, Student_Name 
                                FROM attendance 
                                WHERE Event_ID = @eventID 
                                  AND TimeIn IS NOT NULL;";
                MySqlCommand presentCmd = new MySqlCommand(presentQuery, conn);
                presentCmd.Parameters.AddWithValue("@eventID", eventID);

                using (MySqlDataReader reader = presentCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int studentId = Convert.ToInt32(reader["Student_ID"]);
                        PresentDGV.Rows.Add($"0325-{studentId:0000}", reader["Student_Name"]);
                    }
                }

                // ABSENT
                string absentQuery = @"SELECT u.ID AS Student_ID, u.username AS Student_Name FROM user_event ue JOIN users u ON ue.Student_ID = u.ID LEFT JOIN attendance a ON a.Student_ID = u.ID AND a.Event_ID = ue.Event_ID WHERE ue.Event_ID = '2TGZaZ' AND a.AttendanceID IS NULL ORDER BY u.username ASC;";

                MySqlCommand absentCmd = new MySqlCommand(absentQuery, conn);
                absentCmd.Parameters.AddWithValue("@eventID", eventID);

                using (MySqlDataReader reader = absentCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int studentId = Convert.ToInt32(reader["Student_ID"]);
                        AbsentDGV.Rows.Add($"0325-{studentId:0000}", reader["Student_Name"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExportAttendanceToSinglePDF();
        }
    }
}
