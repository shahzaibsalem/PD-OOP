using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZInput;
using System.IO;
using Application.BL;
using Application.UI;
using Application;

namespace Application.DL
{
    
    public class Functions
    {
        public static string path = "C:\\OOP Week 5\\PD\\Application\\User_login_data.txt";
        
        public static List<User_Login_Data> Credentials = new List<User_Login_Data>();
       
        public static void Load_User()
        {
            Load_User_Credential_Data(ref path, ref Credentials);
        }
        public static void signUp(string path)
        {
            
            Console.WriteLine("Enter your new username:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your new password:");
            string password = Console.ReadLine();
            Console.WriteLine("Enter your new MPIN:");
            string MPIN = Console.ReadLine();
            bool flag = Check_Validity(name);
                       
            if(flag==true)
            {
                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("User already exists!!!!");
                Console.WriteLine("______________________________________________");
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if(flag==false)
            {
                User_Login_Data s = new User_Login_Data(name, password, MPIN);
                Add_User_to_list(s);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Success!!!!");
                Console.WriteLine("______________________________________________");
                StreamWriter write = new StreamWriter(path, true);
                write.WriteLine(s.username + "," + s.password + "," + s.MPIN);
                write.Flush();
                write.Close();
                Console.ForegroundColor = ConsoleColor.Black;
            }
           
          }
        public static void Add_User_to_list(User_Login_Data s)
        {
            Credentials.Add(s);
        }

         public static void Check_signIn()
         {
            bool flage = false;
            LogIn p = Take_Sign_In_Info();
            foreach(User_Login_Data q in Credentials)
            {
                if(q.username==p.username && q.password==p.password )
                {
                    flage = true;
                    break;
                }
            }
           if(flage==true)
           {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("______________________________________________");
                Console.WriteLine("Success!!!!");
                Console.ForegroundColor = ConsoleColor.White;

           }
           else if(flage==false)
           {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("______________________________________________");
                Console.WriteLine("Wrong Credentials!!!!");
                Console.ForegroundColor = ConsoleColor.White;
           }
         }
       
        public static LogIn Take_Sign_In_Info()
        {
            Console.WriteLine("Enter your log_in username:");
            string n = Console.ReadLine();
            Console.WriteLine("Enter your log_in password:");
            string p = Console.ReadLine();
            LogIn l = new LogIn(n,p);
            return l;
        }

        public static bool Check_Validity(string name)
        {
            bool flag = false;
            foreach(User_Login_Data u in Credentials)
            {
                if(u.username==name)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        public static bool IsIntegerBetweenOneAndTwelve(string input)
        {
            int result;
            if (int.TryParse(input, out result))
            {
                if (result >= 1 && result <= 12)
                {
                    return true;
                }
            }

            return false;
        }
       public static void Load_User_Credential_Data(ref string path,ref List<User_Login_Data> Credentials)
        {
            

            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {                 
                    string username = getField(record, 1);
                    string password = getField(record, 2);
                    string MPIN = getField(record, 3);

                    User_Login_Data s = new User_Login_Data(username,password,MPIN);
                    Credentials.Add(s);
                }
                fileVariable.Close();
            }           

        }
        public static string getField(string record, int field)
        {
            int comma = 1;
            string item="";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }

            }
            return item;
        }

    }
}
