using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_Generator_Test_C_
{
    internal class Profile_Info
    {
        private String username;
        private String section;
        private long contactNum;
        private String password;
        private String sex;

        public Profile_Info(String username, String section, long contactNum, String password, String sex)
        {
            this.username = username;
            this.section = section;
            this.contactNum = contactNum;
            this.password = password;
            this.sex = sex;
        }

        public String getUsername()
        {
            return username;
        }
        public String getSection()
        {
            return section;
        }
        public long getConttactNum()
        {
            return contactNum;
        }
        public String getSex()
        {
            return sex;
        }

        public void setUsername(String username)
        {
            this.username = username;
        }
        public void setSection(String section)
        {
            this.section = section;
        }
        public void setContactNum (long contactNum)
        {
            this.contactNum = contactNum;
        }


    }
}
