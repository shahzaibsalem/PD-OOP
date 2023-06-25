using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UI
{
   public class Interface
    {
        public static int User_Menu()
        {

            Console.WriteLine("1.Add Money to your account:");
            Console.WriteLine("2.Withdraw Money from your account: ");
            Console.WriteLine("3.See transaction history of your bank account:");
            Console.WriteLine("4.Change your MPIN:");
            Console.WriteLine("5.Change your username:");
            Console.WriteLine("6.Change your password:");
            Console.WriteLine("7.See bank policies:");
            Console.WriteLine("8.Add comments for this application:");
            Console.WriteLine("9.Delete your bank account:");
            Console.WriteLine("10.Drop a message to manager:");
            Console.WriteLine("11.Delete your bank account:");
            Console.WriteLine("12.Exit:");
            int option = int.Parse(Console.ReadLine());
            return option;
        }
        public static int Admin_Menu()
        {

            Console.WriteLine("1.See all the workers:");
            Console.WriteLine("2.Add a new worker ");
            Console.WriteLine("3.Update salary of a worker:");
            Console.WriteLine("4.Remove  a worker:");
            Console.WriteLine("5.Change your username:");
            Console.WriteLine("6.Change your password:");
            Console.WriteLine("7.Add new policies to bank:");
            Console.WriteLine("8.See all comments for your bank application:");
            Console.WriteLine("9.Remove  a account holder:");
            Console.WriteLine("10.See transaction histories of all the users:");
            Console.WriteLine("11.See total bank amount:");
            Console.WriteLine("12.Exit:");
            int option = int.Parse(Console.ReadLine());
            return option;
        }
        public static int Credentials_Menu()
        {
            Console.WriteLine("1.Sign_Up");
            Console.WriteLine("2.Sign_In");
            Console.WriteLine("3.Exit:");
            int option = int.Parse(Console.ReadLine());
            return option;
        }
        public static string Is_User_Admin()
        {
            string choice;
            Console.WriteLine("Are you user or admin:");
            choice = Console.ReadLine();
            return choice;
        }
        public static int Credentials_Admin_Menu()
        {
            Console.WriteLine("1.Sign_Up");
            Console.WriteLine("2.Sign_In");
            Console.WriteLine("3.Exit:");
            int option = int.Parse(Console.ReadLine());
            return option;
        }

    }
}
