using MySql.Data.MySqlClient;
using System;
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
    public partial class Event_page : Form
    {
        public Event_page()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        public static string ShowInputDialog(string title, string prompt)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.ClientSize = new Size(300, 150);

            label.Text = prompt;
            label.SetBounds(10, 20, 280, 20);

            textBox.SetBounds(10, 50, 280, 25);

            buttonOk.Text = "OK";
            buttonOk.SetBounds(115, 90, 75, 30);
            buttonOk.DialogResult = DialogResult.OK;

            buttonCancel.Text = "Cancel";
            buttonCancel.SetBounds(200, 90, 75, 30);
            buttonCancel.DialogResult = DialogResult.Cancel;

            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult result = form.ShowDialog();

            return (result == DialogResult.OK) ? textBox.Text : null;
        }

        public void AddEventPanel(string ID, string title, string desc, string category, DateTime date, string setting)
        {
            Panel eventPanel = new Panel();
            eventPanel.Width = 800;
            eventPanel.Height = 125;
            eventPanel.BorderStyle = BorderStyle.FixedSingle;
            eventPanel.BackColor = Color.Gray;
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
            eventPanel.Click += Panel_Click;
            flowEventsPanel.Controls.Add(eventPanel);
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void Panel_Click(object sender, EventArgs e)
        {
            string inputPass = ShowInputDialog("Validation", "Please re-enter your password: ");
            inputPass = inputPass.Trim();
            try
            {
                if (inputPass.Equals(Profile_Info.Instance.getPassword()))
                {
                    User_Event user_Event = new User_Event();
                    user_Event.Show();
                }
                else if (string.IsNullOrEmpty(inputPass))
                {
                    return;
                }
                else
                {
                    MessageBox.Show("Incorrect Password");
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void Event_page_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            flowEventsPanel.AutoScroll = true;
            flowEventsPanel.WrapContents = true;
            DB db = new DB();
            string joinQuery = "select users.ID, user_event.Event_ID, events.EventTitle, events.EventDesc, events.EventCategory, events.EventDate, events.EventSetting from users, user_event, events where users.ID = user_event.Student_ID and events.EventID=user_event.Event_ID and users.username = @username";
           /* string joinQuery = "select users.ID, user_event.Event_ID, events.EventTitle, events.EventDesc, events.EventCategory, events.EventDate, events.EventSetting from users, user_event, events where users.ID = user_event.Student_ID and events.EventID=user_event.Event_ID";
            string query = "SELECT EventID, EventTitle, EventDesc, EventCategory, EventDate, EventSetting FROM events";*/
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(joinQuery, conn);
                cmd.Parameters.AddWithValue("@username", Profile_Info.Instance.getUsername());
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string username = reader["ID"].ToString();
                    string eventID = reader["Event_ID"].ToString();
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

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        { 
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            string insertQuery = "INSERT INTO user_event(Student_ID, Event_ID) VALUES (@studentID, @eventID)";
            string selectEventQuery = @"SELECT EventID, EventTitle, EventDesc, EventCategory, EventDate, EventSetting 
                                FROM events 
                                WHERE EventID = @eventID";

            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@studentID", Profile_Info.Instance.userID());
                    cmd.Parameters.AddWithValue("@eventID", TB_EventID.Text);

                    cmd.ExecuteNonQuery();
                }
                using (MySqlCommand cmd2 = new MySqlCommand(selectEventQuery, conn))
                {
                    cmd2.Parameters.AddWithValue("@eventID", TB_EventID.Text);

                    using (MySqlDataReader reader = cmd2.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string eventID = reader["EventID"].ToString();
                            string eventTitle = reader["EventTitle"].ToString();
                            string eventDesc = reader["EventDesc"].ToString();
                            string eventCategory = reader["EventCategory"].ToString();
                            DateTime eventDuration = (DateTime)reader["EventDate"];
                            string eventSetting = reader["EventSetting"].ToString();

                            // Show only the selected event
                            AddEventPanel(eventID, eventTitle, eventDesc, eventCategory, eventDuration, eventSetting);
                        }
                        else
                        {
                            MessageBox.Show("Event ID not found.");
                        }
                    }
                }
            }
            TB_EventID.Text = "";
        }

    }
}
