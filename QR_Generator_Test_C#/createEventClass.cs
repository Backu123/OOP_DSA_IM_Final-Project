using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QR_Generator_Test_C_
{
    internal class createEventClass
    {
        private string eventID;
        private string eventTitle;
        private string eventDescription;
        private string eventCategory;
        private string eventDuration;
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

        /*public createEventClass(String eventID, string eventTitle, string eventDescription, string eventCategory, string eventDuration, string eventSetting)
        {
            this.eventID = "t5y792";
            this.eventTitle = eventTitle;
            this.eventDescription = eventDescription;
            this.eventCategory = eventCategory;
            this.eventDuration = eventDuration;
            this.eventSetting = eventSetting;
        }*/

        public String getEventID() => eventID;
        public string getEventTitle() => eventTitle;
        public string getEventDesc() => eventDescription;
        public string getEventCategory() => eventCategory;
        public string getEventDuration() => eventDuration;
        public string getEventSetting() => eventSetting;

        public void setEventID(string eventID) => this.eventID = eventID;
        public void setEventTitle(string eventTitle) => this.eventTitle = eventTitle;
        public void setEventDesc(string eventDesc) => this.eventDescription = eventDesc;
        public void setEventCategory(string eventCategory) => this.eventCategory = eventCategory;
        public void setEventDuration(string eventDuration) => this.eventDuration = eventDuration;
        public void setEventSetting(string eventSetting) => this.eventSetting = eventSetting;

    }
}
