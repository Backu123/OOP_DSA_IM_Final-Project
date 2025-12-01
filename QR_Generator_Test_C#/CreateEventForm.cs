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
            createEventClass createEventClass = new createEventClass();
            createEventClass.setEventID(TB_ID.Text);
            createEventClass.setEventTitle(TB_Title.Text);
            createEventClass.setEventDesc(TB_Desc.Text);
            createEventClass.setEventCategory(CB_Category.Text);
            createEventClass.setEventDuration(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            createEventClass.setEventSetting(CB_Settings.Text);
            admin.AddEventPanel(createEventClass.getEventID(), createEventClass.getEventTitle(), createEventClass.getEventDesc(), createEventClass.getEventCategory(), createEventClass.getEventDuration(), createEventClass.getEventSetting());
            this.Hide();
        }
    }
}
