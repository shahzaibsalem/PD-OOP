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
        public static string path = "C:\\OOP Week 5\\Week 5 PD\\Application\\User_login_data.txt";
        public static  string path1 = "C:\\OOP Week 5\\Week 5 PD\\Application\\Manager_Login_data.txt";
        public static string addpath = "C:\\OOP Week 5\\Week 5 PD\\Application\\addmoeny record.txt";
        public static string dedpath = "C:\\OOP Week 5\\Week 5 PD\\Application\\dedmoney record.txt";
        public static List<User_Login_Data> Credentials = new List<User_Login_Data>();
        public static List<Admin_Login_Data> Admin_Credentials = new List<Admin_Login_Data>();
        public static List<Added_moeny> Add = new List<Added_moeny>();
        public static List<Deducted_Money> Ded = new List<Deducted_Money>();
       
        public static void Load_User()
        {
            Load_User_Credential_Data(ref path, ref Credentials);
        }
        public static void Load_Admin()
        {
            Load_Admin_Credential_Data(ref path1, ref Admin_Credentials);
        }
        public static void Load_Added_Money()
        {
              if (File.Exists(addpath))
              {
                StreamReader fileVariable = new StreamReader(addpath);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    string MPIN = getField(record, 1);
                    int add = int.Parse(getField(record, 2));
                    Added_moeny a = new Added_moeny(MPIN, add);
                    Add.Add(a);
                }
                fileVariable.Close();
              }
        }
        public static void Load_Deducted_Money()
        {
            if (File.Exists(dedpath))
            {
                StreamReader fileVariable = new StreamReader(dedpath);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    string MPIN = getField(record, 1);
                    int ded = int.Parse(getField(record, 2));
                    Deducted_Money a = new Deducted_Money(MPIN, ded);
                    Ded.Add(a);
                }
                fileVariable.Close();
            }
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
                Console.ReadKey();
                Console.Clear();
                do
                {
                    Console.Clear();
                    int Input = Interface.User_Menu();
                    if (Input == 1)
                    {
                        Console.Clear();
                        Takeinput_for_added_moeny();
                    }
                    else if (Input == 2)
                    {
                        Console.Clear();
                        Takeinput_for_deducted_moeny();
                    }
                    else if (Input == 3)
                    {
                        Console.Clear();
                    }
                    else if (Input == 4)
                    {
                        Console.Clear();
                    }
                    else if (Input == 5)
                    {
                        Console.Clear();
                    }
                    else if (Input == 6)
                    {
                        Console.Clear();
                    }
                    else if (Input == 7)
                    {
                        Console.Clear();
                    }
                    else if (Input == 8)
                    {
                        Console.Clear();
                    }
                    else if (Input == 9)
                    {
                        Console.Clear();
                    }
                    else if (Input == 10)
                    {
                        Console.Clear();
                    }
                    else if (Input == 11)
                    {
                        Console.Clear();
                    }
                    else if (Input == 12)
                    {
                        Console.Clear();
                        break;
                    }

                } while (true);

            }
           else if(flage==false)
           {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("______________________________________________");
                Console.WriteLine("Wrong Credentials!!!!");
                Console.ForegroundColor = ConsoleColor.White;
           }
         }

        public static void Takeinput_for_added_moeny()
        {
            bool flag = false;
            string p;
            
            Console.WriteLine("Enter your MPIN plzzzzz:");
            p = Console.ReadLine();
            foreach(User_Login_Data a in Credentials)
            {
                if(p==a.MPIN)
                {
                    flag = true;
                    break;
                }
            }
            if(flag==true)
            {
                int add;
                Console.WriteLine("Enter how much money you wany to add?");
                add = int.Parse(Console.ReadLine());
                Console.WriteLine("___________________________________________");
                Console.WriteLine(add + " has been added to your bank account:");
                StreamWriter write = new StreamWriter(addpath, true);
                write.WriteLine(p + "," + add);
                write.Flush();
                write.Close();
                Added_moeny a = new Added_moeny(p, add);
                Add_Addedmoney_to_list(a);
            }
            else if(flag==false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong MPIN!!!!");
                Console.ForegroundColor = ConsoleColor.Black;
            }
           
        }
        public static void Takeinput_for_deducted_moeny()
        {
            bool flag = false;
            string p;

            Console.WriteLine("Enter your MPIN plzzzzz:");
            p = Console.ReadLine();
            foreach (User_Login_Data a in Credentials)
            {
                if (p == a.MPIN)
                {
                    flag = true;
                    break;
                }
            }
            if (flag == true)
            {
                int ded;
                Console.WriteLine("Enter how much money you wany to deducted?");
                ded = int.Parse(Console.ReadLine());
                Console.WriteLine("___________________________________________");
                Console.WriteLine(ded + " has been deducted from your bank account:");
                StreamWriter write = new StreamWriter(dedpath, true);
                write.WriteLine(p + "," + ded);
                write.Flush();
                write.Close();
                Deducted_Money d = new Deducted_Money(p, ded);
                Add_Deductedmoney_to_list(d);
            }
            else if (flag == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong MPIN!!!!");
                Console.ForegroundColor = ConsoleColor.Black;
            }

        }
        public static void Add_Addedmoney_to_list(Added_moeny a)
        {
            Add.Add(a);
        }
        public static void Add_Deductedmoney_to_list(Deducted_Money a)
        {
            Ded.Add(a);
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
        public static void Admin_Sign_Up()
        {
            Console.WriteLine("Enter your new username:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your new password:");
            string password = Console.ReadLine();
            bool flag = Check_Validity_Admin(name);
            if(flag==true)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Username already exists!!!!");
                Console.WriteLine("______________________________________________");
                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if(flag==false)
            {
                Admin_Login_Data a = new Admin_Login_Data(name, password);
                Add_Admin_to_List(a);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Success!!!!");
                Console.WriteLine("______________________________________________");
                Console.ReadKey();
                StreamWriter write = new StreamWriter(path1, true);
                write.WriteLine(name + "," + password);
                write.Flush();
                write.Close();
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }

        public static bool Check_Validity_Admin(string name)
        {
            bool flag = false;
            foreach(Admin_Login_Data a in Admin_Credentials)
            {
                if(name==a.username)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        public static void Add_Admin_to_List(Admin_Login_Data a)
        {
            Admin_Credentials.Add(a);
        }
        public static void Load_Admin_Credential_Data(ref string path1, ref List<Admin_Login_Data> Admin_Credentials)
        {


            if (File.Exists(path1))
            {
                StreamReader fileVariable = new StreamReader(path1);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    string username = getField(record, 1);
                    string password = getField(record, 2);

                    Admin_Login_Data s = new Admin_Login_Data(username, password);
                    Admin_Credentials.Add(s);
                }
                fileVariable.Close();
            }

        }
        public static void Take_Admin_Sign_In_Info()
        {
            bool flag = false;
            Console.WriteLine("Enter your log_in username:");
            string n = Console.ReadLine();
            Console.WriteLine("Enter your log_in password:");
            string p = Console.ReadLine();
            foreach(Admin_Login_Data a in Admin_Credentials)
            {
                if(a.username==n && a.password==p)
                {
                    flag = true;
                    break;
                }
            }
            if(flag==true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("______________________________________________");
                Console.WriteLine("Success!!!!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
                do
                {
                    Console.Clear();
                    int Input = Interface.Admin_Menu();
                    if (Input == 1)
                    {
                        Console.Clear();
                    }
                    else if (Input == 2)
                    {
                        Console.Clear();
                    }
                    else if (Input == 3)
                    {
                        Console.Clear();
                    }
                    else if (Input == 4)
                    {
                        Console.Clear();
                    }
                    else if (Input == 5)
                    {
                        Console.Clear();
                    }
                    else if (Input == 6)
                    {
                        Console.Clear();
                    }
                    else if (Input == 7)
                    {
                        Console.Clear();
                    }
                    else if (Input == 8)
                    {
                        Console.Clear();
                    }
                    else if (Input == 9)
                    {
                        Console.Clear();
                    }
                    else if (Input == 10)
                    {
                        Console.Clear();
                    }
                    else if (Input == 11)
                    {
                        Console.Clear();
                    }
                    else if (Input == 12)
                    {
                        Console.Clear();
                        break;
                    }

                } while (true);
            }
            else if(flag==false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("______________________________________________");
                Console.WriteLine("Wrong Credentials!!!!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
       

    }
}
