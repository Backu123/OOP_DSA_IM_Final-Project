using MySql.Data.MySqlClient;
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
    public partial class Create_Admin : Form
    {
        public Create_Admin()
        {
            InitializeComponent();
        }

        private void TB_Username_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TB_Username.Text) || string.IsNullOrWhiteSpace(TB_Password.Text) || string.IsNullOrWhiteSpace(TB_Contact.Text) || (radioButton1.Checked == false && radioButton2.Checked == false))
            {
                MessageBox.Show("Please Complete the following form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String role = "Admin";
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

                if (string.IsNullOrWhiteSpace(TB_Username.Text) || string.IsNullOrWhiteSpace(TB_Password.Text))
                {
                    MessageBox.Show("Please Complete the Form.");
                }
                else
                {
                    DB db = new DB();
                    MySqlConnection conn = db.GetConnection();

                    string query = "INSERT INTO users(username, section, contactNum, password, sex, role) values (@username, @section, @contactNum, @password, @sex, @role)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@username", TB_Username.Text);
                    if (checkBox1.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@section", null);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@section", comboBox1.Text);
                    }
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
            comboBox1.Text = null;
            TB_Password.Text = null;
            TB_Contact.Text = null;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
                comboBox1.Enabled = false;
            else
                comboBox1.Enabled = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                comboBox1.Enabled = false;
                comboBox1.Text = null;
                label6.Enabled = false;
            }
            else
            {
                comboBox1.Enabled = true;
                label6.Enabled = true;
            }
        }
    }
}
