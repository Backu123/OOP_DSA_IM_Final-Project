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
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TB_Username.Text) || string.IsNullOrWhiteSpace(TB_Section.Text) || string.IsNullOrWhiteSpace(TB_Password.Text) || string.IsNullOrWhiteSpace(TB_Contact.Text) || (radioButton1.Checked == false && radioButton2.Checked == false))
            {
                MessageBox.Show("Please Complete the following form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
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

                    string query = "INSERT INTO users(username, section, contactNum, password, sex) values (@username, @section, @contactNum, @password, @sex)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@username", TB_Username.Text);
                    cmd.Parameters.AddWithValue("@section", TB_Section.Text);
                    cmd.Parameters.AddWithValue("@contactNum", TB_Contact.Text);
                    cmd.Parameters.AddWithValue("@password", TB_Password.Text);
                    cmd.Parameters.AddWithValue("@sex", rbValue);

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
    }
}
