using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Application.BL
{
   public class Message:Credentials
   {
        private string message;

        public Message(string username,string password,string message):base(username,password)
        {
            this.message = message;
        }

        public void Set_Username(string username)
        {
            this.username = username;
        }
        public void Set_Password(string password)
        {
            this.password = password;
        }
        public void Set_Message(string message)
        {
            this.message = message;
        }

        public string Get_Username()
        {
            return this.username;
        }
        public string Get_Password()
        {
            return this.password;
        }
        public string Get_Comment()
        {
            return this.message;
        }
    }
}
