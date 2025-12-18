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
using Twilio.TwiML.Voice;

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
            Admin_Event admin = new Admin_Event();
            admin.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime selected = dateTimePickerStart.Value;
            DateTime start = dateTimePickerStart.Value;
            DateTime end = dateTimePickerEnd.Value;
            DateTime now = DateTime.Now;
            // renamed TB_Title
            if (string.IsNullOrEmpty(TB_ID.Text) || string.IsNullOrEmpty(TB_Title.Text) || string.IsNullOrEmpty(TB_Desc.Text) || string.IsNullOrEmpty(CB_Category.Text) || string.IsNullOrEmpty(CB_Settings.Text))
            {
                MessageBox.Show("Please Finish the Form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (selected < now)
            {
                MessageBox.Show("Cannot pick past dates.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (start < now)
            {
                MessageBox.Show("Start date cannot be in the past.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((end - start).TotalMinutes < 30)
            {
                MessageBox.Show("End date must be at least 30 minutes after start date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                createEventClass createEventClass = new createEventClass();
                createEventClass.setEventID(TB_ID.Text);
                createEventClass.setEventTitle(TB_Title.Text);
                createEventClass.setEventDesc(TB_Desc.Text);
                createEventClass.setEventCategory(CB_Category.Text);
                createEventClass.setEventStartDate(dateTimePickerStart.Value);
                createEventClass.setEventEndDate(dateTimePickerEnd.Value);
                createEventClass.setEventSetting(CB_Settings.Text);

                createEventClass.InsertEvent(
                    createEventClass.getEventID(),
                    createEventClass.getEventTitle(),
                    createEventClass.getEventDesc(),
                    createEventClass.getEventCategory(),
                    createEventClass.getEventStartDate(),
                    createEventClass.getEventEndDate(),
                    createEventClass.getEventSetting()
                );

                admin.AddEventPanel(
                    createEventClass.getEventID(),
                    createEventClass.getEventTitle(),
                    createEventClass.getEventDesc(),
                    createEventClass.getEventCategory(),
                    createEventClass.getEventStartDate(),
                    createEventClass.getEventEndDate(),
                    createEventClass.getEventSetting()
                );

                Admin_Event admin_Event = new Admin_Event();
                admin_Event.Show();
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

            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button2.FlatAppearance.MouseDownBackColor = Color.Transparent;

            // DateTimePickers format
            dateTimePickerStart.Format = DateTimePickerFormat.Custom;
            dateTimePickerStart.CustomFormat = "dd/MM/yyyy hh:mm tt";

            dateTimePickerEnd.Format = DateTimePickerFormat.Custom;
            dateTimePickerEnd.CustomFormat = "dd/MM/yyyy hh:mm tt";

            // Prevent start date in the past
            dateTimePickerStart.MinDate = DateTime.Now;

            // Set initial end date to 30 minutes after start
            dateTimePickerEnd.Value = dateTimePickerStart.Value.AddMinutes(30);
            dateTimePickerEnd.MinDate = dateTimePickerStart.Value.AddMinutes(30);
        }


        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            // End date cannot be before start date + 30 mins
            DateTime minEnd = dateTimePickerStart.Value.AddMinutes(30);
            dateTimePickerEnd.MinDate = minEnd;

            // Automatically adjust end date if it's too early
            if (dateTimePickerEnd.Value < minEnd)
            {
                dateTimePickerEnd.Value = minEnd;
            }
        }


        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
          
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void TB_Title_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
