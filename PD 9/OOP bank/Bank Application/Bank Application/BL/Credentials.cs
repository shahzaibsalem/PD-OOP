using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Application.BL
{
   public class Credentials
   {
        protected string username;
        protected string password;
        protected double tax;
        public Credentials(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public virtual double Tax()
        {
            return tax;
        }

   }
}
