using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_Generator_Test_C_
{
    internal class Profile_Info
    {
        public int ID;
        private string formattedID;
        private string formattedAdminID;
        private String username;
        private String section;
        private long contactNum;
        private String password;
        private String sex;
        private String role;


        private static Profile_Info instance;
        public static Profile_Info Instance
        {
            get
            {
                if (instance == null)
                    instance = new Profile_Info();
                return instance;
            }
        }

        private Profile_Info() { }

        public int userID() => ID;
        public String getUserID() => formattedID;
        public String getAdminID() => formattedAdminID;
        public String getUsername() => username;
        public String getSection() => section;
        public long getContactNum() => contactNum;
        public String getSex() => sex;
        public String getRole() => role;
        public String getPassword() => password;

        public void setUserID(int ID)
        {
            this.ID = ID; 
            this.formattedID = $"0325-{ID:0000}";
        }
        public void setAdminID(int ID)
        {
            this.ID = ID;
            this.formattedAdminID = $"{ID:0000}";
        }
        public void setUsername(string username) => this.username = username;
        public void setSection(string section) => this.section = section;
        public void setContactNum(long contactNum) => this.contactNum = contactNum;
        public void setSex(string sex) => this.sex = sex;
        public void setRole(string role) => this.role = role;
        public void setPassword(string password) => this.password = password;
    }
}
