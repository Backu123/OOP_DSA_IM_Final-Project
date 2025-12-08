using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;

namespace QR_Generator_Test_C_
{
    public partial class Scanner_Form : Form
    {
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;
        bool canScan = true;
        private string eventID;

        public Scanner_Form(string eventID)
        {
            InitializeComponent();
            this.eventID = eventID;
        }

        private void Scanner_Form_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
                cbo.Items.Add(filterInfo.Name);

            if (cbo.Items.Count > 0)
            {
                cbo.SelectedIndex = 0;
                StartCamera();
            }

            dataGridView1.Columns.Add("Attendance_ID", "Attendance_ID");
            dataGridView1.Columns.Add("Student_ID", "Student_ID");
            dataGridView1.Columns.Add("Student_Name", "Student_Name");
            dataGridView1.Columns.Add("Event_ID", "Event_ID");
            dataGridView1.Columns.Add("TimeIn", "TimeIn");
            dataGridView1.Columns.Add("TimeOut", "TimeOut");
            dataGridView1.Columns.Add("ScanDate", "ScanDate");
        }

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

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();
            if (pictureBox1.InvokeRequired)
            {
                pictureBox1.BeginInvoke(new Action(() =>
                {
                    pictureBox1.Image?.Dispose();
                    pictureBox1.Image = frame;
                }));
            }
            else
            {
                pictureBox1.Image?.Dispose();
                pictureBox1.Image = frame;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Button action stays intact
            Admin_Event admin_Event = new Admin_Event();
            admin_Event.Show();
            this.Hide();
        }

        private void cbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ComboBox selection change action stays intact
            // You can add code here if needed
        }

        private void InsertOrUpdateAttendance(string contactNum)
        {
            DB db = new DB();
            MySqlConnection conn = db.GetConnection();

            try
            {
                db.OpenConnection();

                // Get Student ID, username, and EventID
                string query = @"SELECT users.ID, users.username, events.EventID
                         FROM users, events
                         WHERE users.contactNum = @contact
                         AND events.EventID = @eventID";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@contact", contactNum);
                cmd.Parameters.AddWithValue("@eventID", eventID);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string studentID = reader["ID"].ToString();
                    string studentName = reader["username"].ToString();
                    string eventID = reader["EventID"].ToString();

                    reader.Close();

                    // Check if an attendance record exists today
                    string checkQuery = @"SELECT AttendanceID, TimeIn, TimeOut
                                  FROM attendance
                                  WHERE Student_ID = @sid AND ScanDate = CURDATE() AND Event_ID = @eid
                                  LIMIT 1";
                    MySqlCommand cmdCheck = new MySqlCommand(checkQuery, conn);
                    cmdCheck.Parameters.AddWithValue("@sid", studentID);
                    cmdCheck.Parameters.AddWithValue("@eid", eventID);

                    object existing = cmdCheck.ExecuteScalar();

                    if (existing == null) // No record today → Time In
                    {
                        string insertQuery = @"INSERT INTO attendance (Student_ID, Student_Name, Event_ID, TimeIn, ScanDate)
                                       VALUES (@sid, @sname, @eid, NOW(), CURDATE())";

                        MySqlCommand cmdInsert = new MySqlCommand(insertQuery, conn);
                        cmdInsert.Parameters.AddWithValue("@sid", studentID);
                        cmdInsert.Parameters.AddWithValue("@sname", studentName);
                        cmdInsert.Parameters.AddWithValue("@eid", eventID);
                        cmdInsert.ExecuteNonQuery();
                        Result.ForeColor = Color.Green;
                        Result.Text = "Time-In Successful";
                    }
                    else // Record exists → Time Out
                    {
                        string updateQuery = @"UPDATE attendance
                                       SET TimeOut = NOW()
                                       WHERE Student_ID = @sid AND ScanDate = CURDATE() AND Event_ID = @eid AND TimeOut IS NULL";

                        MySqlCommand cmdUpdate = new MySqlCommand(updateQuery, conn);
                        cmdUpdate.Parameters.AddWithValue("@sid", studentID);
                        cmdUpdate.Parameters.AddWithValue("@eid", eventID);

                        int rowsAffected = cmdUpdate.ExecuteNonQuery(); // ← Important: execute the update

                        if (rowsAffected == 0)
                        {
                            MessageBox.Show($"{studentName} has already timed out today.");
                        }
                        else
                        {
                            Result.ForeColor = Color.Green;
                            Result.Text = "Time-Out Successful";
                        }
                    }

                    // Load last attendance to show in DataGridView
                    LoadLastAttendance(studentID);
                }
                else
                {
                    MessageBox.Show("User or Event not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Attendance Error: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }



        private void LoadLastAttendance(string studentID)
        {
            /*DB db = new DB();
            MySqlConnection conn = db.GetConnection();

            string query = @"SELECT AttendanceID, Student_ID, Student_Name, Event_ID, TimeIn, TimeOut, ScanDate
                             FROM attendance
                             WHERE Student_ID = @sid
                             ORDER BY AttendanceID DESC
                             LIMIT 1";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@sid", studentID);

            try
            {
                db.OpenConnection();
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    dataGridView1.Rows.Add(
                        reader["AttendanceID"].ToString(),
                        reader["Student_ID"].ToString(),
                        reader["Student_Name"].ToString(),
                        reader["Event_ID"].ToString(),
                        reader["TimeIn"].ToString(),
                        reader["TimeOut"].ToString(),
                        reader["ScanDate"].ToString()
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Error: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }*/
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null || !canScan) return;

            Bitmap img;
            lock (pictureBox1.Image)
            {
                img = (Bitmap)pictureBox1.Image.Clone();
            }

            var reader = new BarcodeReader
            {
                AutoRotate = true,
                TryInverted = true,
                Options =
                {
                    TryHarder = true,
                    PossibleFormats = new List<BarcodeFormat> { BarcodeFormat.QR_CODE }
                }
            };

            var result = reader.Decode(img);
            img.Dispose();

            if (result != null)
            {
                canScan = false;
                string contactNum = result.Text;

                InsertOrUpdateAttendance(contactNum);

                // 10 sec bfore next scan
                await Task.Delay(30000);
                canScan = true;
            }
        }

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

        private void Refresh_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            DB db = new DB();
            MySqlConnection conn = db.GetConnection();
            string query = @"SELECT * FROM attendance where Event_ID = @eventID";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@eventID", eventID);

            try
            {
                db.OpenConnection();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dataGridView1.Rows.Add(
                        reader["AttendanceID"].ToString(),
                        reader["Student_ID"].ToString(),
                        reader["Student_Name"].ToString(),
                        reader["Event_ID"].ToString(),
                        reader["TimeIn"].ToString(),
                        reader["TimeOut"].ToString(),
                        reader["ScanDate"].ToString()
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Error: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }
    }
}
