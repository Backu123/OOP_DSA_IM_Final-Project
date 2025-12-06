using QRCoder;
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
    public partial class User_Event : Form
    {
        public User_Event()
        {
            InitializeComponent();
        }

        private void User_Event_Load(object sender, EventArgs e)
        {

            string data = Profile_Info.Instance.getContactNum().ToString();

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
    }
}
