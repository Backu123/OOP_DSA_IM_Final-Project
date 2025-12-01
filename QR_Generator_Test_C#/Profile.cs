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
            Dashboard db = new Dashboard();
            db.Show();
            this.Hide();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            string username = Profile_Info.Instance.getUsername();
            string section = Profile_Info.Instance.getSection();
            string sex = Profile_Info.Instance.getSex();
            string role = Profile_Info.Instance.getRole();
            long contactNum = Profile_Info.Instance.getContactNum();

            Profile_Name.Text = username;
            Profile_Section.Text = section;
            Profile_Sex.Text = sex;
            Profile_Role.Text = role;
            Profile_Contact.Text = "0" + contactNum.ToString();

            Profile_Name.Visible = true;
            Profile_Section.Visible = true;
            Profile_Contact.Visible = true;
            Profile_Sex.Visible = true;
        }
    }
}
