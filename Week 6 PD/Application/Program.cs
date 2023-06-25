using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DL;
using Application.UI;
using Application.BL;
using System.IO;
using EZInput;

namespace Application
{
    class Program
    {         
        static void Main(string[] args)
        {
            string path = "C:\\OOP Week 5\\Week 5 PD\\Application\\User_login_data.txt";
         string path1 = "C:\\OOP Week 5\\Week 5 PD\\Application\\Manager_Login_data.txt";
        string addpath = "C:\\OOP Week 5\\Week 5 PD\\Application\\addmoeny record.txt";
        string dedpath = "C:\\OOP Week 5\\Week 5 PD\\Application\\dedmoney record.txt";
             
            string select = " ";
            Functions.Load_User();
            Functions.Load_Admin();
            Functions.Load_Added_Money();
            Functions.Load_Deducted_Money();
            do
            {
                Console.Clear();
                string choice = Interface.Is_User_Admin();
                if(choice=="user" || choice=="USER")
                {
                    select = "user";
                    break;
                }
                else if(choice=="admin" || choice=="ADMIN")
                {
                    select = "admin";
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong Input!!!!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (true);
            Console.ReadKey();
            if (select == "user")
            {

                do
                {
                    Console.Clear();
                    int input = Interface.Credentials_Menu();
                    
                    if (input == 1)
                    {
                        Console.Clear();
                        Functions.signUp(path);
                        Console.ReadKey();
                    }
                    else if (input == 2)
                    {
                        Console.Clear();
                        Functions.Check_signIn();
                       
                    }
                    else if (input == 3)
                    {
                        Console.Clear();
                        break;
                    }

                } while (true);
                Console.ReadKey();
            }
            else if(select=="admin")
            {
                do
                {
                    Console.Clear();
                    int option = Interface.Credentials_Admin_Menu();
                    if(option==1)
                    {
                        Console.Clear();
                        Functions.Admin_Sign_Up();
                    }
                    else if(option==2)
                    {
                        Console.Clear();
                        Functions.Take_Admin_Sign_In_Info();
                    }
                    else
                    {
                        Console.Clear();
                        break;
                    }

                } while (true);
            }

        }
       
    }

}
