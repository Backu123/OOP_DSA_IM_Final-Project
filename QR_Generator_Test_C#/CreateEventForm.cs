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
    public partial class CreateEventForm : Form
    {
        private Admin_Event admin;
        private const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private Random random = new Random();
        public CreateEventForm(Admin_Event adminForm)
        {
            InitializeComponent();
            admin = adminForm;
        }

        public CreateEventForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime selected = dateTimePicker1.Value;
            DateTime now = DateTime.Now;
            if (string.IsNullOrEmpty(TB_ID.Text) || string.IsNullOrEmpty(TB_Title.Text) || string.IsNullOrEmpty(TB_Desc.Text) || string.IsNullOrEmpty(CB_Category.Text) || string.IsNullOrEmpty(CB_Settings.Text))
            {
                MessageBox.Show("Please Finish the Form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (selected < now)
            {
                MessageBox.Show("Cannot pick past dates.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                createEventClass createEventClass = new createEventClass();
                createEventClass.setEventID(TB_ID.Text);
                createEventClass.setEventTitle(TB_Title.Text);
                createEventClass.setEventDesc(TB_Desc.Text);
                createEventClass.setEventCategory(CB_Category.Text);
                createEventClass.setEventDuration(dateTimePicker1.Value);
                createEventClass.setEventSetting(CB_Settings.Text);

                createEventClass.InsertEvent(
                    createEventClass.getEventID(),
                    createEventClass.getEventTitle(),
                    createEventClass.getEventDesc(),
                    createEventClass.getEventCategory(),
                    createEventClass.getEventDuration(),
                    createEventClass.getEventSetting()
                    );

                admin.AddEventPanel(
                    createEventClass.getEventID(),
                    createEventClass.getEventTitle(),
                    createEventClass.getEventDesc(),
                    createEventClass.getEventCategory(),
                    createEventClass.getEventDuration(),
                    createEventClass.getEventSetting()
                    );
                this.Hide();
            }
        }

        private String GenerateEventID()
        {
            char[] code = new char[6];
            for (int i = 0; i < 6; i++)
            {
                code[i] = chars[random.Next(chars.Length)];
            }
            return new string(code);
        }

        private void Button_ID_Click(object sender, EventArgs e)
        {
            
        }

        private void CreateEventForm_Load(object sender, EventArgs e)
        {
            TB_ID.Text = GenerateEventID();
            TB_ID.Enabled = false;
            dateTimePicker1.CustomFormat = "MMMM-dd-yyyy hh:mm tt";
            dateTimePicker1.MinDate = DateTime.Now;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
          
        }
    }
}
