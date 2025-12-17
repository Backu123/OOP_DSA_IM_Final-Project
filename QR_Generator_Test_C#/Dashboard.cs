using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using QRCoder;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing.OneD;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;

namespace QR_Generator_Test_C_
{
    public partial class Dashboard : Form
    {
        QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
        private string username;
        public Dashboard()
        {
            InitializeComponent();
        }

        public string getUsername()
        {
            return username;
        }

        /*private void CenterPanel()
        {
            userPanel.Left = (this.ClientSize.Width - userPanel.Width) / 2;
            userPanel.Top = (this.ClientSize.Height - userPanel.Height) / 2;
            adminPanel.Left = (this.ClientSize.Width - adminPanel.Width) / 2;
            adminPanel.Top = (this.ClientSize.Height - adminPanel.Height) / 2;
        }*/

        private void Dashboard_Load(object sender, EventArgs e)
        {
            qRGeneratingToolStripMenuItem.Visible = false;
            if (Profile_Info.Instance.getRole() == "Admin")
            {
                createEventToolStripMenuItem.Visible = true;
                createAdminMenuItem.Visible = true;
                eventsToolStripMenuItem.Visible = false;
            }
            else
            {
                createEventToolStripMenuItem.Visible = false;
                createAdminMenuItem.Visible = false;
            }

            DB db = new DB();
            MySqlConnection conn = db.GetConnection();
            string query = "Select ID from users where username = @username";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", Profile_Info.Instance.getUsername());

            try
            {
                db.OpenConnection();
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int userID = Convert.ToInt32(reader["ID"]);
                    Profile_Info.Instance.setUserID(userID);
                    Profile_Info.Instance.setAdminID(userID);
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


        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dashboard db = new Dashboard();
            db.Show();
            this.Hide();
        }

        private void qRGeneratingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QR_Generator qr_ui = new QR_Generator();
            qr_ui.Show();
            this.Hide();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
        }

        private void eventsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Event_page event_Page = new Event_page();
            event_Page.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = Profile_Info.Instance.getUsername();
            string data = Profile_Info.Instance.getContactNum().ToString();
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.L);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(10);

            string savePath = $@"C:\Users\ASUS\Documents\OOP_DSA_Proj\OOP_DSA_IM_Final-Project\QR_Codes\{username}_QR.png";
            qrCodeImage.Save(savePath);
            MessageBox.Show("Upload Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void hihihihihihhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin_Event admin_Event = new Admin_Event();
            admin_Event.Show();
            this.Hide();
        }

        private void createAdminMenuItem_Click(object sender, EventArgs e)
        {
            Create_Admin create_Admin = new Create_Admin();
            create_Admin.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void adminPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void adminPanel_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void createAdminStrip_Click(object sender, EventArgs e)
        {
            Create_Admin create_Admin = new Create_Admin();
            create_Admin.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
