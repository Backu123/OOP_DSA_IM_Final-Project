using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
namespace QR_Generator_Test_C_
{
    public partial class LoginForm : Form
    {
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

        private void button1_Click(object sender, EventArgs e)
        {
            Profile_Info.Instance.setUsername(accUsername());
            Profile_Info.Instance.setSection(accSection());
            Profile_Info.Instance.setContactNum(accNum());
            Profile_Info.Instance.setPassword(accPassword());
            Profile_Info.Instance.setSex(accSex());
            Profile_Info.Instance.setRole(accRole());


            if (string.IsNullOrWhiteSpace(loginUser.Text) || string.IsNullOrWhiteSpace(loginPass.Text))
            {
                MessageBox.Show("Please input a valid information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (UserExist())
                {
                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Your Account doesn't exist.");
                }
            }
            loginUser.Text = "";
            loginPass.Text = "";
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

        public String getUsername()
        {
            return loginUser.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TB_Username.Text) ||
                string.IsNullOrWhiteSpace(comboBox1.Text) ||
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
            cmd.Parameters.AddWithValue("@section", comboBox1.Text);
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
            comboBox1.Text = "";
            TB_Password.Clear();
            TB_Contact.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }
private void CenterPanel()
        {
            mainPanel.Left = (this.ClientSize.Width - mainPanel.Width) / 2;
            mainPanel.Top = (this.ClientSize.Height - mainPanel.Height) / 2;
        }
        

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            CenterPanel();
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

        private void button4_Click(object sender, EventArgs e)
        {
            TB_Password.Text = "kjwdnkedhnikd";
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void TB_Section_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void TB_Username_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TB_Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
