using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Application.BL
{
   public class Deducted_Money:Credentials
   {
        private int Deducted_Amount;

        public Deducted_Money(string username,string password,int Deducted_Amount):base(username,password)
        {
            this.Deducted_Amount = Deducted_Amount;
        }

        public void Set_Username(string username)
        {
            this.username = username;
        }
        public void Set_Password(string password)
        {
            this.password = password;
        }
        public void Set_Deducted_Money(int Deducted_Amount)
        {
            this.Deducted_Amount = Deducted_Amount;
        }
        public string Get_Username()
        {
            return this.username;
        }
        public string Get_Password()
        {
            return this.password;
        }
        public int Get_Deducted_Money()
        {
            return this.Deducted_Amount;
        }
    }
}
