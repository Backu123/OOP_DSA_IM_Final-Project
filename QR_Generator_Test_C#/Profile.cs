using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QR_Generator_Test_C_
{
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void CenterPanel()
        {
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
            panel2.Left = (this.ClientSize.Width - panel2.Width) / 2;
            panel2.Top = (this.ClientSize.Height - panel2.Height) / 2;
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            CenterPanel();
            string role = Profile_Info.Instance.getRole().ToLower();
            panel1.Visible = true;
            panel2.Visible = true;
            /*if (role == "admin")
            {
                panel1.Visible = false;
                panel2.Visible = true;
                string section = Profile_Info.Instance.getSection();
                string lower = section.ToLower();
                if (lower == "instructor")
                {
                    label6.Text = "Department: ";
                    admin_section.Text = "College of Computer Studies";
                }
                else
                {
                    admin_section.Text = section;
                }
                string adminID = Profile_Info.Instance.getAdminID();
                string username = Profile_Info.Instance.getUsername();
                string sex = Profile_Info.Instance.getSex();
                long contactNum = Profile_Info.Instance.getContactNum();

                admin_ID.Text = adminID;
                admin_Name.Text = username;
                admin_Sex.Text = sex;
                admin_Contact.Text = "0" + contactNum.ToString();

                admin_ID.Visible = true;
                admin_Name.Visible = true;
                admin_section.Visible = true;
                admin_Sex.Visible = true;
                admin_Contact.Visible = true;
            }
            else
            {*/
                string studentID = Profile_Info.Instance.getUserID();
                string username = Profile_Info.Instance.getUsername();
                string section = Profile_Info.Instance.getSection();
                string sex = Profile_Info.Instance.getSex();
                long contactNum = Profile_Info.Instance.getContactNum();

                Profile_Name.Text = username;
                Profile_Section.Text = section;
                Profile_Sex.Text = sex;
                Profile_ID.Text = studentID;
                Profile_Contact.Text = "0" + contactNum.ToString();
                Profile_Role.Text = Profile_Info.Instance.getRole();
                

                Profile_ID.Visible = true;
                Profile_Name.Visible = true;
                Profile_Section.Visible = true;
                Profile_Contact.Visible = true;
                Profile_Sex.Visible = true;
            Profile_Role.Visible = true;

                panel1.Visible = true;
                panel2.Visible = false;
            /*}*/

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
