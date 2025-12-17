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
    public partial class Start_Page : Form
    {
        public Start_Page()
        {
            InitializeComponent();
        }

        private void Start_Page_KeyDown(object sender, KeyEventArgs e)
        {
            LoginForm dashboard = new LoginForm();
            dashboard.Show();
            this.Hide();
        }

        private void Start_Page_Click(object sender, EventArgs e)
        {
            LoginForm dashboard = new LoginForm();
            dashboard.Show();
            this.Hide();
        }
        private void Start_Page_Load(object sender, EventArgs e)
        {
        }
    }
}
