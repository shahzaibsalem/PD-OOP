using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BL
{
    public class User_Login_Data
    {
        public string username;
        public string password;
        public string MPIN;

        public User_Login_Data(string username,string password,string MPIN)
        {
            this.username = username;
            this.password = password;
            this.MPIN = MPIN;
        }
        public User_Login_Data()
        {

        }
    }

    public class Admin_Login_Data
    {
        string username;
        string password;
        public Admin_Login_Data(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
    public class LogIn
    {
       public string username;
       public string password;

        public LogIn(string username,string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
