using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
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
            if (string.IsNullOrWhiteSpace(TB_Username.Text) || string.IsNullOrWhiteSpace(TB_Section.Text) || string.IsNullOrWhiteSpace(TB_Password.Text) || string.IsNullOrWhiteSpace(TB_Contact.Text) || (radioButton1.Checked == false && radioButton2.Checked == false))
            {
                MessageBox.Show("Please Complete the following form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                DialogResult isAdmin = MessageBox.Show("Are you an admin?", "Access Modifier", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                String role;
                if (isAdmin == DialogResult.Yes)
                {
                    role = "Admin";
                }
                else
                {
                    role = "User";
                }

                string rbValue = "";
                bool isChecked1 = radioButton1.Checked;
                bool isChecked2 = radioButton2.Checked;
                if (isChecked1)
                {
                    rbValue = radioButton1.Text;
                }
                else if (isChecked2)
                {
                    rbValue = radioButton2.Text;
                }

                if (string.IsNullOrWhiteSpace(TB_Username.Text))
                {

                }
                else
                {
                    DB db = new DB();
                    MySqlConnection conn = db.GetConnection();

                    string query = "INSERT INTO users(username, section, contactNum, password, sex, role) values (@username, @section, @contactNum, @password, @sex, @role)";

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
                }
            }
            TB_Username.Text = null;
            TB_Section.Text = null;
            TB_Password.Text = null;
            TB_Contact.Text = null;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void TB_Contact_TextChanged(object sender, EventArgs e)
        {
        }

        private void TB_Contact_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TB_Contact.Text))
                TB_Contact.Text = "09";
        }
    }
}
