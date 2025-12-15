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

namespace QR_Generator_Test_C_
{
    public partial class EventPanel : Form
    {
        public EventPanel()
        {
            InitializeComponent();
        }

        private string FormatStudentID(string rawID)
        {
            int id = int.Parse(rawID);
            return $"0325-{id:0000}";
        }

        private void SIgn_Up_Load(object sender, EventArgs e)
        {
            // Set column for present attendees
            PresentDGV.Columns.Add("Student_ID", "Student_ID");
            PresentDGV.Columns.Add("Student_Name", "Student_Name");
            PresentDGV.Columns["Student_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PresentDGV.Columns["Student_ID"].Width = 90; 

            // Set column for absent attendees
            AbsentDGV.Columns.Add("Student_ID", "Student_ID");
            AbsentDGV.Columns.Add("Student_Name", "Student_Name");
            AbsentDGV.Columns["Student_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            AbsentDGV.Columns["Student_ID"].Width = 90;


            DB db = new DB();
            MySqlConnection conn = db.GetConnection();
            String query = "SELECT Student_ID, Student_Name from attendance where Event_ID = @eventID;";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@eventID", "2TGZaZ");
            
            try
            {
                db.OpenConnection();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PresentDGV.Rows.Add(
                        FormatStudentID(reader["Student_ID"].ToString()),
                        reader["Student_Name"].ToString()
                    );
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
    }
}
