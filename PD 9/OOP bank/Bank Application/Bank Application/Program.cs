using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_Application.BL;
using Bank_Application.DL;
using Bank_Application.UI;

namespace Bank_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            bool IsAdmin = false;

            All_Functions.Load_Credentials_From_File();
            All_Functions.Load_Added_Amount_From_File();
            All_Functions.Load_Deducted_Moeny_From_List();
            All_Functions.Load_Comments_From_File();
            All_Functions.Load_Messages_From_List();
            All_Functions.Load_Workers_From_File();
            All_Functions.Load_Policy_From_File();

            do
            {
               Console.Clear();
               int option= Print_Interface.SignUp_SignIn_Menu();
               
               if(option==1)
               {
                    Console.Clear();
                    Print_Interface.Take_SignUp_Info();
                    Console.ReadKey();
               }
               else if (option == 2)
               {
                    Console.Clear();
                    string Input = Print_Interface.Take_SignIn_Info();

                    if (Input == "no")
                    {
                        IsAdmin = true;
                        break;
                    }
                    else if (Input == "yes")
                    {
                        IsAdmin = false;
                        break;
                    }
                    Console.ReadKey();
               }
               else
               {
                    break;
               }

            }while (true);
            
            if(IsAdmin)
            {
                do
                {
                    Console.Clear();
                    int option = Print_Interface.User_Menu_Bar();

                    if (option  == 1)
                    {
                        Console.Clear();
                        All_Functions.Take_Input_For_Added_Money();
                        Console.ReadKey();
                    }
                    else if (option == 2)
                    {
                        Console.Clear();
                        Print_Interface.Take_Info_Deducted_Amount();
                        Console.ReadKey();
                    }
                    else if (option == 3)
                    {
                        Console.Clear();
                        Print_Interface.Input_Password_For_Transactions();
                        Console.ReadKey();
                    }
                    else if (option == 4)
                    {
                        Console.Clear();
                        All_Functions.Change_User_Username();
                        Console.ReadKey();
                    }
                    else if (option == 5)
                    {
                        Console.Clear();
                        All_Functions.Change_User_Password();
                        Console.ReadKey();
                    }
                    else if (option == 6)
                    {
                        Console.Clear();
                        Print_Interface.See_Policies_Of_Bnak();
                        Console.ReadKey();
                    }
                    else if (option == 7)
                    {
                        Console.Clear();
                        All_Functions.Input_For_Comments();
                        Console.ReadKey();
                    }
                    else if (option == 8)
                    {
                        Console.Clear();
                        All_Functions.Delete_Bank_Account();
                        break;
                    }
                    else if (option == 9)
                    {
                        Console.Clear();
                        All_Functions.Drop_Message();
                        Console.ReadKey();
                    }
                    else if (option == 10)
                    {
                        break;
                    }                  

                } while (true);
            }

            else if(!IsAdmin)
            {
                do
                {
                    Console.Clear();
                    int option = Print_Interface.Admin_Menu();

                    if (option == 1)
                    {
                        Console.Clear();
                        Print_Interface.Show_All_Workers();
                        Console.ReadKey();
                    }
                    else if (option == 2)
                    {
                        Console.Clear();
                        Print_Interface.Take_Input_For_Workers();
                        Console.ReadKey();
                    }
                    else if (option == 3)
                    {
                        Console.Clear();
                        All_Functions.Update_Salary_Of_Worker();
                        Console.ReadKey();
                    }
                    else if (option == 4)
                    {
                        Console.Clear();
                        All_Functions.Remove_Worker();
                        Console.ReadKey();
                    }
                    else if (option == 5)
                    {
                        Console.Clear();
                        All_Functions.Change_User_Username();
                        Console.ReadKey();
                    }
                    else if (option == 6)
                    {
                        Console.Clear();
                        All_Functions.Change_User_Password();
                        Console.ReadKey();
                    }
                    else if (option == 7)
                    {
                        Console.Clear();
                        Print_Interface.Take_Input_For_Policy();
                        Console.ReadKey();
                    }
                    else if (option == 8)
                    {
                        Console.Clear();
                        Print_Interface.See_All_Comments();
                        Console.ReadKey();
                    }
                    else if (option == 9)
                    {
                        Console.Clear();
                        All_Functions.Remove_Account();
                        Console.ReadKey();
                    }
                    else if (option == 10)
                    {
                        Console.Clear();
                        Print_Interface.See_Transaction_Histories();
                        Console.ReadKey();
                    }
                    else if (option == 11)
                    {
                        Console.Clear();
                        Print_Interface.Total_Amount_Of_Bank();
                        Console.ReadKey();
                    }
                    else if (option == 12)
                    {
                        Console.Clear();
                        Print_Interface.See_Tax();
                        Console.ReadKey();
                    }
                    else if (option == 13)
                    {
                        Console.Clear();
                        break;
                    }
                } while (true);
            }
            Console.ReadKey();
        }
    }
}
