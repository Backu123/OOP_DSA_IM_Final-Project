using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace QR_Generator_Test_C_ {

    public partial class Admin_Event : Form
    {
        private CreateEventForm createEventForm;

        public Admin_Event()
        {
            InitializeComponent();
        }
        public Admin_Event(CreateEventForm createEventForm)
        {
            InitializeComponent();
            this.createEventForm = createEventForm;
        }

        private void LblStatus_Paint(object sender, PaintEventArgs e)
        {
            Label lbl = sender as Label;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Color bgColor = (Color)lbl.Tag;

            using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                int radius = lbl.Height / 2;
                path.AddArc(0, 0, radius, lbl.Height, 90, 180); // left arc
                path.AddArc(lbl.Width - radius, 0, radius, lbl.Height, 270, 180); // right arc
                path.CloseAllFigures();

                using (SolidBrush brush = new SolidBrush(bgColor))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }

            // Draw text centered
            TextRenderer.DrawText(
                e.Graphics,
                lbl.Text,
                lbl.Font,
                lbl.ClientRectangle,
                lbl.ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );
        }


        public void AddEventPanel(string ID, string title, string desc, string category, DateTime startDate, DateTime endDate, string setting)
        {
            Panel eventPanel = new Panel();
            eventPanel.Width = 800;
            eventPanel.Height = 125;
            eventPanel.BorderStyle = BorderStyle.FixedSingle;
            eventPanel.BackColor = Color.LightBlue;
            eventPanel.Margin = new Padding(15);

            // --- Delete Button ---
            Button btnDelete = new Button();
            btnDelete.Size = new Size(25, 25);
            btnDelete.Location = new Point(eventPanel.Width - btnDelete.Width - 6, 94);
            btnDelete.Text = ""; // no text
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.BackColor = Color.Transparent;
            btnDelete.Image = Image.FromFile(@"C:\Users\ASUS\Downloads\trash-bin.png");
            btnDelete.ImageAlign = ContentAlignment.MiddleCenter;
            btnDelete.Image = new Bitmap(btnDelete.Image, btnDelete.Size); // resize image to button size

            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatAppearance.MouseOverBackColor = Color.Transparent;  
            btnDelete.FlatAppearance.MouseDownBackColor = Color.Transparent;  
            

            btnDelete.Tag = ID; // Store EventID
            btnDelete.Click += (s, e) =>
            {
                // Confirm deletion
                if (MessageBox.Show("Are you sure you want to delete this event?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DB db = new DB();
                    using (MySqlConnection conn = db.GetConnection())
                    {
                        conn.Open();
                        string deleteQuery = "DELETE FROM events WHERE EventID = @eventID";
                        using (MySqlCommand cmd = new MySqlCommand(deleteQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@eventID", btnDelete.Tag.ToString());
                            cmd.ExecuteNonQuery();
                        }
                    }
                    flowEventsPanel.Controls.Remove(eventPanel);
                    eventPanel.Dispose();
                }
            };
            eventPanel.Controls.Add(btnDelete);


            Label lbID = new Label();
            lbID.Text = "Event ID: " + ID;
            lbID.Location = new Point(20, 45);
            lbID.AutoSize = true;

            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Location = new Point(20, 15);
            lblTitle.Font = new Font(lblTitle.Font.FontFamily, 11, FontStyle.Bold);
            lblTitle.AutoSize = true;

            Label lbDesc = new Label();
            lbDesc.Text = "Description: " + desc;
            lbDesc.Location = new Point(20, 95);
            lbDesc.AutoSize = true;

            Label lblCategory = new Label();
            lblCategory.Text = "Category: " + category;
            lblCategory.Location = new Point(450, 45);
            lblCategory.AutoSize = true;

            Label lblDate = new Label();
            lblDate.Text = $"{startDate:MMM dd, yyyy hh:mm tt} - {endDate:MMM dd, yyyy hh:mm tt}";
            lblDate.Location = new Point(20, 70);
            lblDate.AutoSize = true;


            Label lblLocation = new Label();
            lblLocation.Text = "Location: " + setting;
            lblLocation.Location = new Point(450, 70);
            lblLocation.AutoSize = true;

            string status = GetEventStatus(startDate, endDate);

            Label lblStatus = new Label();
            lblStatus.Text = status;
            lblStatus.Location = new Point(680, 15);
            lblStatus.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblStatus.AutoSize = false; // Important for custom painting
            lblStatus.Width = 80;
            lblStatus.Height = 25;
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;

            // Set a background color according to status
            Color bgColor;

            switch (status)
            {
                case "Upcoming":
                    bgColor = Color.DodgerBlue;
                    break;
                case "Ongoing":
                    bgColor = Color.Green;
                    break;
                case "Ended":
                    bgColor = Color.Red;
                    break;
                default:
                    bgColor = Color.Gray;
                    break;
            }

            lblStatus.Tag = bgColor; // store color for Paint event
            lblStatus.ForeColor = Color.White;

            // Attach custom paint event
            lblStatus.Paint += LblStatus_Paint;

            eventPanel.Tag = new EventInfo
            {
                EventID = ID,
                StartDate = startDate,
                EndDate = endDate
            };

            eventPanel.Controls.Add(lbID);
            eventPanel.Controls.Add(lblTitle);
            eventPanel.Controls.Add(lbDesc);
            eventPanel.Controls.Add(lblCategory);
            eventPanel.Controls.Add(lblLocation);
            eventPanel.Controls.Add(lblStatus);
            eventPanel.Controls.Add(lblDate);
            eventPanel.Click += Panel_Click;
            flowEventsPanel.Controls.Add(eventPanel);
        }
        private string GetEventStatus(DateTime start, DateTime end)
        {
            DateTime now = DateTime.Now;

            if (now < start)
                return "Upcoming";
            else if (now >= start && now <= end)
                return "Ongoing";
            else
                return "Ended";
        }
        private void Panel_Click(object sender, EventArgs e)
        {
            if (sender is Panel panel && panel.Tag is EventInfo info)
            {
                string status = GetEventStatus(info.StartDate, info.EndDate);

                if (status == "Upcoming")
                {
                    MessageBox.Show("The event hasn't started yet.");
                }
                else if (status == "Ongoing")
                {
                    Scanner_Form scanner_Form = new Scanner_Form(info.EventID);
                    scanner_Form.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("The event has ended.");
                }
            }
        }


        private void createEventButton_Click(object sender, EventArgs e)
        {
            CreateEventForm createEventForm = new CreateEventForm(this);
            createEventForm.Show();
            this.Hide();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CenterPanel()
        {
            mainPanel.Left = (this.ClientSize.Width - mainPanel.Width) / 2;
            mainPanel.Top = (this.ClientSize.Height - mainPanel.Height) / 2;
        }
        private void Admin_Event_Load(object sender, EventArgs e)
        {
            CenterPanel();
            flowEventsPanel.AutoScroll = true;
            flowEventsPanel.WrapContents = true;
            Back.FlatAppearance.BorderSize = 0;
            Back.FlatAppearance.MouseOverBackColor = Color.Transparent;
            Back.FlatAppearance.MouseDownBackColor = Color.Transparent;
            createEventButton.FlatAppearance.BorderSize = 0;
            createEventButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            createEventButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            DB db = new DB();
            string query = @"SELECT EventID, EventTitle, EventDesc, EventCategory, EventDate, EventEndDate, EventSetting FROM events WHERE created_by = @username";
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", Profile_Info.Instance.getUsername());
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string eventID = reader["EventID"].ToString();
                    string eventTitle = reader["EventTitle"].ToString();
                    string eventDesc = reader["EventDesc"].ToString();
                    string eventCategory = reader["EventCategory"].ToString();
                    DateTime startDate = (DateTime)reader["EventDate"];
                    DateTime endDate = (DateTime)reader["EventEndDate"];
                    string eventSetting = reader["EventSetting"].ToString();

                    AddEventPanel(eventID, eventTitle, eventDesc, eventCategory, startDate, endDate, eventSetting);
                }
                conn.Close();
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
