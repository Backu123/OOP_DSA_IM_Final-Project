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
using System.ComponentModel;

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
            // ───── ComboBox setup (dont set SelectedIndex yet)
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            // ───── Camera setup
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
                cbo.Items.Add(filterInfo.Name);

            if (cbo.Items.Count > 0)
            {
                cbo.SelectedIndex = 0;
                StartCamera();
            }

            // ───── DataGridView setup
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Add("Student_ID", "Student ID");
            dataGridView1.Columns.Add("Student_Name", "Student Name");
            dataGridView1.Columns.Add("Event_ID", "Event ID");
            dataGridView1.Columns.Add("TimeIn", "Time In");
            dataGridView1.Columns.Add("TimeOut", "Time Out");
            dataGridView1.Columns.Add("ScanDate", "Scan Date");

            // Column types (IMPORTANT for sorting)
            dataGridView1.Columns["TimeIn"].ValueType = typeof(DateTime);
            dataGridView1.Columns["TimeOut"].ValueType = typeof(DateTime);
            dataGridView1.Columns["ScanDate"].ValueType = typeof(DateTime);

            dataGridView1.Columns["TimeIn"].SortMode = DataGridViewColumnSortMode.Programmatic;
            dataGridView1.Columns["Student_Name"].SortMode = DataGridViewColumnSortMode.Programmatic;
            dataGridView1.Columns["Student_ID"].SortMode = DataGridViewColumnSortMode.Programmatic;

            // ───── Load data from MySQL
            DB db = new DB();
            MySqlConnection conn = db.GetConnection();

            string query = @"SELECT Student_ID, Student_Name, Event_ID, TimeIn, TimeOut, ScanDate
                     FROM attendance
                     WHERE Event_ID = @eventID";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@eventID", eventID);

            try
            {
                db.OpenConnection();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dataGridView1.Rows.Add(
                        FormatStudentID(reader["Student_ID"].ToString()),
                        reader["Student_Name"].ToString(),
                        reader["Event_ID"].ToString(),
                        reader["TimeIn"] == DBNull.Value ? (object)null : Convert.ToDateTime(reader["TimeIn"]),
                        reader["TimeOut"] == DBNull.Value ? (object)null : Convert.ToDateTime(reader["TimeOut"]),
                        Convert.ToDateTime(reader["ScanDate"])
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

            // ───── DEFAULT SORT (runs AFTER data is loaded)
            comboBox1.SelectedIndex = 0;   // First to Last (TimeIn ASC)
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

        public bool UserExist(long contactNum)
        {
            DB db = new DB();
            MySqlConnection conn = db.GetConnection();

            string query = "SELECT users.ID, users.username, user_event.Event_ID FROM users JOIN user_event ON user_event.Student_ID = users.ID  WHERE users.contactNum = @contactNum AND user_event.Event_ID = @eventID";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@contactNum", contactNum);
            cmd.Parameters.AddWithValue("@eventID", this.eventID);

            try
            {
                db.OpenConnection();
                MySqlDataReader reader = cmd.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                db.CloseConnection();
            }
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
                try
                {
                    canScan = false;
                    string contactNum = result.Text;

                    // Check if user is enrolled in the event
                    bool exists = UserExist(long.Parse(contactNum));

                    if (!exists)
                    {
                        Result.ForeColor = Color.Red;
                        Result.Text = "User is NOT registered in this event.";
                        await Task.Delay(3000);
                        Result.Text = "";
                        canScan = true;
                        return;  // stop here → do NOT insert attendance
                    }

                    // User is valid → proceed with attendance
                    InsertOrUpdateAttendance(contactNum);

                    await Task.Delay(5000);
                    Result.Text = "";
                    canScan = true;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                
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

        private string FormatStudentID(string rawID)
        {
            int id = int.Parse(rawID);
            return $"0325-{id:0000}";
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            DB db = new DB();
            MySqlConnection conn = db.GetConnection();
            string query = @"SELECT * FROM attendance WHERE Event_ID = @eventID";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@eventID", eventID);

            try
            {
                db.OpenConnection();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string formattedID = FormatStudentID(reader["Student_ID"].ToString());

                    dataGridView1.Rows.Add(
                        formattedID,
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Result_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewColumn columnToSort;

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    columnToSort = dataGridView1.Columns["TimeIn"];
                    break;
                case 1:
                    columnToSort = dataGridView1.Columns["Student_Name"];
                    break;
                case 2:
                    columnToSort = dataGridView1.Columns["Student_ID"];
                    break;
                default:
                    return;
            }

            // Determine new sort direction
            System.ComponentModel.ListSortDirection newDirection;

            if (dataGridView1.SortedColumn == columnToSort)
            {
                // Toggle direction if the same column is already sorted
                if (dataGridView1.SortOrder == SortOrder.Ascending)
                    newDirection = System.ComponentModel.ListSortDirection.Descending;
                else
                    newDirection = System.ComponentModel.ListSortDirection.Ascending;
            }
            else
            {
                // Default to ascending if a different column is selected
                newDirection = System.ComponentModel.ListSortDirection.Ascending;
            }

            // Apply the sort
            dataGridView1.Sort(columnToSort, newDirection);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0) return;

            switch (comboBox1.SelectedIndex)
            {
                case 0: // First to Last (TimeIn)
                    dataGridView1.Sort(dataGridView1.Columns["TimeIn"], ListSortDirection.Ascending);
                    break;

                case 1: // Alphabetical
                    dataGridView1.Sort(dataGridView1.Columns["Student_Name"], ListSortDirection.Ascending);
                    break;

                case 2: // Numerical (Student ID)
                    dataGridView1.Sort(dataGridView1.Columns["Student_ID"], ListSortDirection.Ascending);
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EventPanel eventPanel = new EventPanel(this.eventID);
            eventPanel.Show();
        }
    }
}
