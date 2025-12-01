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

        private void Dashboard_Load(object sender, EventArgs e)
        {
            qRGeneratingToolStripMenuItem.Visible = false;
            string username = Profile_Info.Instance.getUsername();
            string section = Profile_Info.Instance.getSection();
            string sex = Profile_Info.Instance.getSex();
            string role = Profile_Info.Instance.getRole();
            long contactNum = Profile_Info.Instance.getContactNum();
            accInfo.Enabled = false;
            string data = username;

            if (role == "Admin")
            {
                createEventToolStripMenuItem.Visible = true;
            }
            else
            {
                createEventToolStripMenuItem.Visible = false;
            }
            

            if (string.IsNullOrEmpty(data))
            {
                MessageBox.Show("Please Enter Something.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.L);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(10);
            pictureBox1.Image = qrCodeImage;

            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;

            accInfo.Multiline = true;
            accInfo.Text = $"Name: {username}{Environment.NewLine}Section: {section}{Environment.NewLine}Contact #: {contactNum}{Environment.NewLine}Sex: {sex}{Environment.NewLine}Role: {role}";

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
            this.Hide();
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
            string data = username;
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
    }
}
