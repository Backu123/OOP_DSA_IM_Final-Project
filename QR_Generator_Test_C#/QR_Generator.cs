using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCoder;
using System.IO;
using static System.Console;

namespace QR_Generator_Test_C_
{
    public partial class QR_Generator : Form
    {
        QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
        public QR_Generator()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string data = textBox1.Text.Trim();
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

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            /*string data = textBox1.Text.Trim();
            if(string.IsNullOrEmpty(data) )
            {
                MessageBox.Show("Please Enter Something.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.L);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(10);
            pictureBox1.Image = qrCodeImage;
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;*/
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string data = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(data))
            {
                MessageBox.Show("Please Enter Something.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.L);
            QRCode qrCode = new QRCode(qrCodeData); 
            Bitmap qrCodeImage = qrCode.GetGraphic(10);

            string savePath = $@"C:\Users\ASUS\Documents\OOP_DSA_Proj\QR_Generator_Test_C#\QR_Codes\{textBox1.Text}_QR.png";
            qrCodeImage.Save(savePath);
            MessageBox.Show("Upload Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Dashboard db = new Dashboard();
            db.Show();
            this.Hide();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            pictureBox1.Image = null;
        }

        private void btnExit_Enter(object sender, EventArgs e)
        {

        }
    }
}
