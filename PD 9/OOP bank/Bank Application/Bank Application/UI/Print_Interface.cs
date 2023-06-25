using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_Application.DL;
using Bank_Application.BL;

namespace Bank_Application.UI
{
   public class Print_Interface
   {
        public static int SignUp_SignIn_Menu()
        {
            Console.WriteLine("1.Sign_Up");
            Console.WriteLine("2.Sign_In");
            Console.WriteLine("3.Exit:");
            int option = int.Parse(Console.ReadLine());
            return option;
        }

        public static void Take_SignUp_Info()
        {
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();
            Console.WriteLine("Are you admin?");
            string IsAdmin = Console.ReadLine();

           bool check = All_Functions.Check_valid_User(username);
           if(check==true)
           {
                Console.WriteLine("Invalid user!!!!");
           }
           else if(check==false)
           {
                Console.WriteLine("Sign_Up Success!!!!");
                All_Credentials credentials = new All_Credentials(username, password, IsAdmin);
                All_Functions.Add_Users_Managers_To_List(credentials);
            }
        }

        public static string Take_SignIn_Info()
        {
            string IsAdmin = "";

            Console.WriteLine("Enter your  username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter your  password:");
            string password = Console.ReadLine();

          All_Credentials credentials =  All_Functions.Check_Is_LogIn_info_Correct(username,password);
          if(credentials.IsAdmin=="no" || credentials.IsAdmin=="No")
          {
                IsAdmin = "no";
               
          }

          else if (credentials.IsAdmin == "yes" || credentials.IsAdmin == "Yes")
          {
                IsAdmin = "yes";
                
          }
          else
          {
                Console.WriteLine("Wrong Input!!!!");
          }
            return IsAdmin;
        }

        public static void Take_Info_Deducted_Amount()
        {

            string username="";
            string password;
            int deducted_amount;

            Console.WriteLine("Enter password:");
            password = Console.ReadLine();

            bool flag = All_Functions.Check_Valid_User_ForDeducted(password,username);

            if(flag==true)
            {
                Console.WriteLine("Enter amount to deduct:");
                deducted_amount = int.Parse(Console.ReadLine());
                All_Functions.Check_Valid_Amount(deducted_amount,username, password);
            }
        }

        public static void Input_Password_For_Transactions()
        {
            string password;
            Console.WriteLine("Enter your password:");
            password = Console.ReadLine();

            See_Transactions_Of_Your_Account(password);
        }

        public static void See_Transactions_Of_Your_Account(String password)
        {
            Console.Clear();
            foreach(Deducted_Money deducted in All_Functions.deducted_amount_list)
            {
                if(deducted.Get_Password()==password)
                {

                    Console.WriteLine(deducted.Get_Username() + "," + deducted.Get_Password() + "," + deducted.Get_Deducted_Money());
                   
                }
               
            }
        }

        public static void See_Policies_Of_Bnak()
        {
            Console.WriteLine(All_Functions.policies[0]);
        }

        public static int User_Menu_Bar()
        {
            Console.WriteLine("1.Add Money to your account:");
            Console.WriteLine("2.Withdraw Money from your account: ");
            Console.WriteLine("3.See transaction history of your bank account:");
            Console.WriteLine("4.Change your username:");
            Console.WriteLine("5.Change your password:");
            Console.WriteLine("6.See bank policies:");
            Console.WriteLine("7.Add comments for this application:");
            Console.WriteLine("8.Delete your bank account:");
            Console.WriteLine("9.Drop a message to manager:");
            Console.WriteLine("10.Exit:");
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
            Console.WriteLine("12.See tax of all bank account holders:");
            Console.WriteLine("13.Exit:");
            int option = int.Parse(Console.ReadLine());
            return option;
        }

        public static void Take_Input_For_Workers()
        {
            string name;
            string city;
            string post;
            int salary;

            Console.WriteLine("Enter name of worker:");
            name = Console.ReadLine();
            Console.WriteLine("Enter city of worker:");
            city = Console.ReadLine();
            Console.WriteLine("Enter post of worker:");
            post = Console.ReadLine();
            Console.WriteLine("Enter salary of worker:");
            salary =int.Parse(Console.ReadLine());

           bool flag = All_Functions. Valid_Salary(salary,  name,  city, post);

            if(flag)
            {
                Console.WriteLine("Success!!!!");

            }
            else
            {
                Console.WriteLine("Invalid salary!!!!");
            }
        }

        public static void Show_All_Workers()
        {
            Console.WriteLine("Here is the information of all the workers:");
            Console.WriteLine("_______________________________________________");

            foreach(Workers_Data worker in All_Functions.workers_list)
            {
                Console.WriteLine(worker.Get_Name() + "," + worker.Get_City() + "," + worker.Get_Salary() + "," + worker.Get_Post());
            }
        }

        public static void Take_Input_For_Policy()
        {
            string policy;

            Console.WriteLine("Enter the policies of bank:");
            policy = Console.ReadLine();


            Console.WriteLine("Successfully added!!!!");

            All_Functions.policies.Add(policy);
            All_Functions.Add_Policy_To_File();

        }

        public static void See_All_Comments()
        {
            Console.WriteLine("Here are the comments about your bank application:");
            Console.WriteLine("_______________________________________________");

            foreach(Comments comment in All_Functions.comments_list)
            {
                Console.WriteLine(comment.Get_Username() + "," + comment.Get_Password() + ">>>>>>>>>>" + comment.Get_Comment());
            }
        }

        public static void See_Transaction_Histories()
        {
            foreach(Deducted_Money deducted in All_Functions.deducted_amount_list)
            {
                Console.WriteLine(deducted.Get_Username() + "," + deducted.Get_Password() + ">>>>>>>>>>>" + deducted.Get_Deducted_Money());
            }
        }

        public static void Total_Amount_Of_Bank()
        {
            int total = 0;

            foreach(Added_Amount added in All_Functions.added_amount_list)
            {
                total = total + int.Parse(added.Get_Added_Amount());
            }

            Console.WriteLine("Here is the total amount in the bank:");
            Console.WriteLine(total);
        }

        public static void See_Tax()
        {
            double tax = All_Functions.Calculate_Tax();

            Console.WriteLine("The tax of all workers is:");

            foreach (Added_Amount added in All_Functions.added_amount_list)
            {

                Console.WriteLine(added.Get_Username()+">>>>>>"+added.Tax());
            }

            Console.WriteLine("_______________________________________________");
            Console.WriteLine("The total tax is:" + tax);
        }

    }
}
