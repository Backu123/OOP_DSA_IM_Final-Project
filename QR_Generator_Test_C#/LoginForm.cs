using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
namespace QR_Generator_Test_C_
{
    public partial class LoginForm : Form
    {
        string userPhoneNumber;
        private OTP otpService = new OTP();
        private Timer otpTimer;
        private int countdown = 30; // 30 seconds

        public LoginForm()
        {
            InitializeComponent();
        }

        public String accUsername()
        {
            DB db = new DB();
            MySqlConnection conn = db.GetConnection();

            string query = "SELECT username FROM users WHERE username = @username";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", loginUser.Text);

            try
            {
                db.OpenConnection();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return reader["username"].ToString();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                db.CloseConnection();
            }

        }

        public String accSection()
        {
            DB db = new DB();
            MySqlConnection conn = db.GetConnection();

            string query = "SELECT section FROM users WHERE username = @username";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", loginUser.Text);

            try
            {
                db.OpenConnection();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return reader["section"].ToString();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                db.CloseConnection();
            }

        }

        public long accNum()
        {
            DB db = new DB();
            MySqlConnection conn = db.GetConnection();

            string query = "SELECT contactNum FROM users WHERE username = @username";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", loginUser.Text);

            try
            {
                db.OpenConnection();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return (long)reader["contactNum"];
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                db.CloseConnection();
            }

        }

        public String accPassword()
        {
            DB db = new DB();
            MySqlConnection conn = db.GetConnection();

            string query = "SELECT password FROM users WHERE username = @username";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", loginUser.Text);

            try
            {
                db.OpenConnection();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return reader["password"].ToString();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                db.CloseConnection();
            }

        }

        public String accSex()
        {
            DB db = new DB();
            MySqlConnection conn = db.GetConnection();

            string query = "SELECT sex FROM users WHERE username = @username";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", loginUser.Text);

            try
            {
                db.OpenConnection();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return reader["sex"].ToString();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                db.CloseConnection();
            }

        }

        public String accRole()
        {
            DB db = new DB();
            MySqlConnection conn = db.GetConnection();

            string query = "SELECT role FROM users WHERE username = @username";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", loginUser.Text);

            try
            {
                db.OpenConnection();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return reader["role"].ToString();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                db.CloseConnection();
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void loginUser_TextChanged(object sender, EventArgs e)
        {

        }

        public bool UserExist()
        {
            DB db = new DB();
            MySqlConnection conn = db.GetConnection();

            string query = "SELECT * FROM users WHERE username = @username and password = @password  LIMIT 1";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", loginUser.Text);
            cmd.Parameters.AddWithValue("@password", loginPass.Text);

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

        private bool ValidateLogin(string username, string password)
        {
            DB db = new DB();
            MySqlConnection conn = db.GetConnection();

            string query = @"SELECT COUNT(*) 
                     FROM users 
                     WHERE username = @user 
                       AND password = @pass";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@user", username);
            cmd.Parameters.AddWithValue("@pass", password);

            try
            {
                db.OpenConnection();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                db.CloseConnection();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // 1️⃣ Empty check
            if (string.IsNullOrWhiteSpace(loginUser.Text) ||
                string.IsNullOrWhiteSpace(loginPass.Text) ||
                string.IsNullOrWhiteSpace(loginOTP.Text))
            {
                MessageBox.Show("Please complete the form");
                loginUser.Clear();
                loginPass.Clear();
                loginOTP.Clear();
                return;
            }

            // 2️⃣ Validate OTP
            if (!otpService.Validate(loginOTP.Text))
            {
                MessageBox.Show("Invalid OTP");
                loginUser.Clear();
                loginPass.Clear();
                loginOTP.Clear();
                return;
            }
            if (UserExist())
            {
                Profile_Info.Instance.setUsername(accUsername());
                Profile_Info.Instance.setSection(accSection());
                Profile_Info.Instance.setContactNum(accNum());
                Profile_Info.Instance.setPassword(accPassword());
                Profile_Info.Instance.setSex(accSex());
                Profile_Info.Instance.setRole(accRole());

                Dashboard dashboard = new Dashboard();
                dashboard.Show();
            }
            else
            {
                MessageBox.Show("User doesn't exist.");
            }
           
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private String GetUserPhone(string username)
        {
            string contactNum = "";
            DB db = new DB();
            MySqlConnection conn = db.GetConnection();
            string query = "SELECT contactNum FROM users WHERE username = @users";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@users", loginUser.Text);

            try
            {
                db.OpenConnection();
                MySqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    contactNum = reader["contactNum"].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
            return contactNum;
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            string otp = otpService.Generate();
            MessageBox.Show("Your OTP is: " + otp);  // <- THIS BLOCKS THE UI
            btnSendOTP.Enabled = false;
            countdown = 30;
            btnSendOTP.ForeColor = Color.White;
            btnSendOTP.Text = $"Wait {countdown}s";
            otpTimer.Start();
        }

        public String getUsername()
        {
            return loginUser.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TB_Username.Text) ||
                string.IsNullOrWhiteSpace(TB_Section.Text) ||
                string.IsNullOrWhiteSpace(TB_Password.Text) ||
                string.IsNullOrWhiteSpace(TB_Contact.Text) ||
                (radioButton1.Checked == false && radioButton2.Checked == false))
            {
                MessageBox.Show("Please complete the form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string role = "User";
            string rbValue = radioButton1.Checked ? radioButton1.Text : radioButton2.Text;

            DB db = new DB();
            MySqlConnection conn = db.GetConnection();

            // Check if contact number exists
            string checkQuery = "SELECT COUNT(*) FROM users WHERE contactNum = @contactNum";
            MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
            checkCmd.Parameters.AddWithValue("@contactNum", TB_Contact.Text);

            db.OpenConnection();
            int count = Convert.ToInt32(checkCmd.ExecuteScalar());
            db.CloseConnection();

            if (count > 0)
            {
                MessageBox.Show("This contact number is already registered. Please use another number.",
                                "Duplicate Contact Number",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO users(username, section, contactNum, password, sex, role) VALUES (@username, @section, @contactNum, @password, @sex, @role)";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@username", TB_Username.Text);
            cmd.Parameters.AddWithValue("@section", TB_Section.Text);
            cmd.Parameters.AddWithValue("@contactNum", TB_Contact.Text);
            cmd.Parameters.AddWithValue("@password", TB_Password.Text);
            cmd.Parameters.AddWithValue("@sex", rbValue);
            cmd.Parameters.AddWithValue("@role", role);

            try
            {
                db.OpenConnection();
                cmd.ExecuteNonQuery();
                MessageBox.Show("New Account Created Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }

            TB_Username.Clear();
            TB_Section.Text = "";
            TB_Password.Clear();
            TB_Contact.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void OtpTimer_Tick(object sender, EventArgs e)
        {
            countdown--;

            btnSendOTP.Text = $"Wait {countdown}s";

            if (countdown <= 0)
            {
                otpTimer.Stop();
                btnSendOTP.Enabled = true;
                btnSendOTP.Text = "Send OTP";
                countdown = 30; // reset countdown
            }
        }


        private void LoginForm_Load(object sender, EventArgs e)
        {
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button2.FlatAppearance.MouseDownBackColor = Color.Transparent;
            otpTimer = new Timer();
            otpTimer.Interval = 1000; // 1 second
            otpTimer.Tick += OtpTimer_Tick;
            TB_Password.PasswordChar = '*';
            loginPass.PasswordChar = '*';
        }


        private void TB_Contact_TextChanged(object sender, EventArgs e)
        {
        }

        private void TB_Contact_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TB_Contact.Text))
                TB_Contact.Text = "09";
        }

        private void TB_Username_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void TB_Section_TextChanged(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Orange;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void loginUser_MouseDown(object sender, MouseEventArgs e)
        {
            label1.ForeColor = Color.Orange;
        }

        private void loginUser_Leave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.DarkGray;
        }

        private void loginPass_MouseDown(object sender, MouseEventArgs e)
        {
            label2.ForeColor = Color.Orange;
        }

        private void loginPass_Leave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.DarkGray;
        }

        private void loginPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label11.ForeColor = Color.Orange;
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            label11.ForeColor = Color.Orange;
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            label11.ForeColor = Color.Gray;
        }

        private void TB_Username_MouseDown(object sender, MouseEventArgs e)
        {
            label5.ForeColor = Color.Orange;
        }
        private void TB_Username_Leave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Gray;
        }
        private void TB_Section_MouseDown(object sender, MouseEventArgs e)
        {
            label6.ForeColor = Color.Gray;
        }

        private void TB_Contact_MouseDown(object sender, MouseEventArgs e)
        {
            label7.ForeColor = Color.Orange;
        }

        private void TB_Contact_Leave(object sender, EventArgs e)
        {
            label7.ForeColor = Color.Gray;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            label11.ForeColor = Color.Gray;
        }

        private void loginPass_Enter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Orange;
        }

        private void loginUser_Enter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Orange;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            label11.ForeColor = Color.Orange;
        }

        private void TB_Username_Enter(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Orange;
        }

        private void TB_Contact_Enter(object sender, EventArgs e)
        {
            label7.ForeColor = Color.Orange;
        }

        private void TB_Password_Enter(object sender, EventArgs e)
        {   
            label8.ForeColor = Color.Orange;
        }

        private void TB_Section_Enter(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Orange;
        }

        private void TB_Password_Leave(object sender, EventArgs e)
        {
            label8.ForeColor = Color.Gray;
        }

        private void TB_Section_Leave(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Gray;
        }


    }
}
