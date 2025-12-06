using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace QR_Generator_Test_C_
{
    public partial class Scanner_Form : Form
    {
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;
        public string usernameResult;

        public Scanner_Form()
        {
            InitializeComponent();
        }

        private void Scanner_Form_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            // Load available cameras
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
            {
                cbo.Items.Add(filterInfo.Name);
            }

            // Auto-select first camera
            if (cbo.Items.Count > 0)
            {
                cbo.SelectedIndex = 0;
                StartCamera();   // 🚀 AUTO START CAMERA
            }
        }

        // Start camera
        private void StartCamera()
        {
            if (cbo.SelectedIndex < 0)
            {
                MessageBox.Show("No camera detected.");
                return;
            }

            captureDevice = new VideoCaptureDevice(filterInfoCollection[cbo.SelectedIndex].MonikerString);

            var bestResolution = captureDevice.VideoCapabilities
                .OrderByDescending(v => v.FrameSize.Width * v.FrameSize.Height)
                .FirstOrDefault();

            if (bestResolution != null)
                captureDevice.VideoResolution = bestResolution;

            captureDevice.NewFrame += CaptureDevice_NewFrame;
            captureDevice.Start();

            timer1.Start();
        }

        // Display camera feed
        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                Bitmap frame = (Bitmap)eventArgs.Frame.Clone();

                if (pictureBox1.InvokeRequired)
                {
                    pictureBox1.BeginInvoke(new Action(() =>
                    {
                        if (pictureBox1.Image != null)
                            pictureBox1.Image.Dispose();

                        pictureBox1.Image = frame;
                    }));
                }
                else
                {
                    if (pictureBox1.Image != null)
                        pictureBox1.Image.Dispose();

                    pictureBox1.Image = frame;
                }
            }
            catch { }
        }

        // Decode QR continuously
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) return;

            Bitmap img;

            lock (pictureBox1.Image)
            {
                img = (Bitmap)pictureBox1.Image.Clone();
            }

            var reader = new ZXing.BarcodeReader
            {
                AutoRotate = true,
                TryInverted = true,
                Options =
                {
                    TryHarder = true,
                    PossibleFormats = new List<ZXing.BarcodeFormat>
                    {
                        ZXing.BarcodeFormat.QR_CODE
                    }
                }
            };

            var result = reader.Decode(img);
            img.Dispose();

            if (result != null)
            {
                textBox1.Text = result.Text;
                usernameResult = result.Text;
            }
        }

        private void cbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // empty
        }


        // Stop camera safely
        private void Scanner_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (captureDevice != null)
                {
                    captureDevice.NewFrame -= CaptureDevice_NewFrame;

                    if (captureDevice.IsRunning)
                    {
                        captureDevice.SignalToStop();
                        captureDevice.WaitForStop();
                    }
                }
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_Event admin_Event = new Admin_Event();
            admin_Event.Show();
            this.Hide();
        }
    }
}
