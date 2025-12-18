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
        private DateTime eventStartDate;
        private DateTime eventEndDate;
        private string eventSetting;

        // GETTERS
        public string getEventID() => eventID;
        public string getEventTitle() => eventTitle;
        public string getEventDesc() => eventDescription;
        public string getEventCategory() => eventCategory;
        public DateTime getEventStartDate() => eventStartDate;
        public DateTime getEventEndDate() => eventEndDate;
        public string getEventSetting() => eventSetting;

        // SETTERS
        public void setEventID(string eventID) => this.eventID = eventID;
        public void setEventTitle(string eventTitle) => this.eventTitle = eventTitle;
        public void setEventDesc(string eventDesc) => this.eventDescription = eventDesc;
        public void setEventCategory(string eventCategory) => this.eventCategory = eventCategory;
        public void setEventStartDate(DateTime startDate) => this.eventStartDate = startDate;
        public void setEventEndDate(DateTime endDate) => this.eventEndDate = endDate;
        public void setEventSetting(string eventSetting) => this.eventSetting = eventSetting;

        public void InsertEvent(
            string ID,
            string title,
            string desc,
            string category,
            DateTime startDate,
            DateTime endDate,
            string setting)
        {
            DB db = new DB();
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = @"
            INSERT INTO events
            (EventID, EventTitle, EventDesc, EventCategory, EventDate, EventEndDate, EventSetting, created_by)
            VALUES
            (@id, @title, @desc, @category, @start, @end, @setting, @creator)";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@creator", Profile_Info.Instance.getUsername());
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@desc", desc);
                cmd.Parameters.AddWithValue("@category", category);
                cmd.Parameters.AddWithValue("@start", startDate);
                cmd.Parameters.AddWithValue("@end", endDate);
                cmd.Parameters.AddWithValue("@setting", setting);

                cmd.ExecuteNonQuery();
            }
        }
    }


}
