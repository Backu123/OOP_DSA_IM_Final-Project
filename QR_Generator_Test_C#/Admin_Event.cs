using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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


        public void AddEventPanel(string ID, string title, string desc, string category, DateTime date, string setting)
        {
            Panel eventPanel = new Panel();
            eventPanel.Width = 800;
            eventPanel.Height = 125;
            eventPanel.BorderStyle = BorderStyle.FixedSingle;
            eventPanel.BackColor = Color.White;
            eventPanel.Margin = new Padding(10);

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
            lblDate.Text = "Date: " + date;
            lblDate.Location = new Point(20, 70);
            lblDate.AutoSize = true;

            Label lblLocation = new Label();
            lblLocation.Text = "Location: " + setting;
            lblLocation.Location = new Point(450, 70);
            lblLocation.AutoSize = true;

            eventPanel.Controls.Add(lbID);
            eventPanel.Controls.Add(lblTitle);
            eventPanel.Controls.Add(lbDesc);
            eventPanel.Controls.Add(lblCategory);
            eventPanel.Controls.Add(lblDate);
            eventPanel.Controls.Add(lblLocation);

            flowEventsPanel.Controls.Add(eventPanel);
        }

        private void createEventButton_Click(object sender, EventArgs e)
        {
            CreateEventForm createEventForm = new CreateEventForm(this);
            createEventForm.Show();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Admin_Event_Load(object sender, EventArgs e)
        {
            flowEventsPanel.AutoScroll = true;
            flowEventsPanel.WrapContents = true;

            DB db = new DB();
            string query = "SELECT EventID, EventTitle, EventDesc, EventCategory, EventDate, EventSetting FROM events where created_by = @username";
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
                    DateTime eventDuration = (DateTime)reader["EventDate"];
                    string eventSetting = reader["EventSetting"].ToString();

                    AddEventPanel(eventID, eventTitle, eventDesc, eventCategory, eventDuration, eventSetting);
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

        
    }
}
