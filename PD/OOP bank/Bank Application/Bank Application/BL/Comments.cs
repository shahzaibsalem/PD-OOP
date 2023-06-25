using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Application.BL
{
   public class Comments:All_Credentials
   {
        private string Comment;

        public Comments(string username,string password,string comments):base(username,password)
        {
            this.Comment = comments;
        }

        public void Set_Username(string username)
        {
            this.username = username;
        }
        public void Set_Password(string password)
        {
            this.password = password;
        }
        public void Set_Comment(string Comment)
        {
            this.Comment = Comment;
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
            return this.Comment;
        }
    }
}
