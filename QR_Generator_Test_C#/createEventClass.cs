using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace QR_Generator_Test_C_
{
    internal class createEventClass
    {
        private string eventID;
        private string eventTitle;
        private string eventDescription;
        private string eventCategory;
        private DateTime eventDuration;
        private string eventSetting;

        private static createEventClass instance;
        public static createEventClass Instance
        {
            get
            {
                if (instance == null)
                    instance = new createEventClass();
                return instance;
            }

        }

        public String getEventID() => eventID;
        public string getEventTitle() => eventTitle;
        public string getEventDesc() => eventDescription;
        public string getEventCategory() => eventCategory;
        public DateTime getEventDuration() => eventDuration;
        public string getEventSetting() => eventSetting;

        public void setEventID(string eventID) => this.eventID = eventID;
        public void setEventTitle(string eventTitle) => this.eventTitle = eventTitle;
        public void setEventDesc(string eventDesc) => this.eventDescription = eventDesc;
        public void setEventCategory(string eventCategory) => this.eventCategory = eventCategory;
        public void setEventDuration(DateTime eventDuration) => this.eventDuration = eventDuration;
        public void setEventSetting(string eventSetting) => this.eventSetting = eventSetting;

        public void InsertEvent(string ID, string title, string desc, string category, DateTime date, string setting)
        {
            DB db = new DB();
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();

                    string query = "INSERT INTO events (EventID, EventTitle, EventDesc, EventCategory, EventDate, EventSetting, created_by) " +
                                   "VALUES (@id, @title, @desc, @category, @date, @setting, @creator)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@creator", Profile_Info.Instance.getUsername());
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@desc", desc);
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@setting", setting);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();   
                }
                
            }
        }
    }

}
