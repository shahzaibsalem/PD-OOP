using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_Application.DL;

namespace Bank_Application.BL
{
  
    public class All_Credentials
    {
        public string username;
        public string password;
        public string IsAdmin;

        public All_Credentials(string username,string password,string IsAdmin)
        {
            this.username = username;
            this.password = password;
            this.IsAdmin = IsAdmin;
        }

        public All_Credentials(string username, string password)
        {
            this.username = username;
            this.password = password;
            
        }

        public All_Credentials()
        {

        }
    }
}
