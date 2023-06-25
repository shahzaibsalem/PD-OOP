using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Application.BL
{
    public class Added_Amount:Credentials
    {
        private string Added_Money;

        public Added_Amount(string username,string password,string Added_Money):base(username,password)
        {
            this.Added_Money = Added_Money;
        }

        public  void Set_Added_Amount(string Added_Money)
        {
            this.Added_Money = Added_Money;
        }

        public void Set_Password(string password)
        {
            this.password = password;
        }

        public void Set_Username(string username)
        {
            this.username = username;
        }
        public string Get_Username()
        {
            return this.username;
        }

        public  string Get_Added_Amount()
        {
            return this.Added_Money;
        }

        public string Get_Password()
        {
            return this.password;
        }

        public override double Tax()
        {
            double tax = int.Parse(Get_Added_Amount()) * 0.30;
            return tax;
        }
    }
}
