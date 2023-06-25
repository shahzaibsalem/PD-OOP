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
    public class Added_moeny
    {
       public string MPIN;
       
        public int add_money;

        public Added_moeny(string MPIN,int add)
        {
            this.MPIN = MPIN;
            
            add_money = add;
        }
        public Added_moeny()
        {

        }
    }

    public class Deducted_Money
    {
        public string MPIN;
       
        public int deducted_amount;
        public Deducted_Money(string MPIN, int ded)
        {
            this.MPIN = MPIN;
            
            deducted_amount = ded;
        }
        public Deducted_Money()
        {

        }  
 
    }
    public class Admin_Login_Data
    {
      public  string username;
      public  string password;
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
