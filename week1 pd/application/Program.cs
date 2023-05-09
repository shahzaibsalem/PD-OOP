using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace application
{
    class Program
    {
        public static void Main(string[] args)
        {
            string bankPolicy = "HBL as part of the The League Management Trainee Programme in 2017 and was placed in Human Resources. The rigorous Professional Development and Customized Learning & Development opportunities provided as part of the programme offer unparalleled learning opportunities. This has made my transition to the corporate world smooth and exciting.";
            string[] names = new string[5];
            string[] passwords = new string[5];
            string path = "C:\\OOP week 1\\week1 pd\\user.txt";
            string mpath = "C:\\OOP week 1\\week1 pd\\manager.txt";
            string ctach;
            string receive;
            string manageru="manager";
            string managerp="123789";
            string u;
            string p;
            string c;
            readData(path, names, passwords);
            ReadManagerlogInData( mpath, ref manageru, ref managerp);
            receive = checkuser();
            if (receive == "user")
            {
                ctach = menuBar();
                while (true)
                {
                    if (ctach == "1")
                    {
                        int back = 0;
                        Console.Clear();
                        SignUp(names, passwords, path);
                        while (back != 4)
                        {
                            Console.WriteLine("Enter 4 to go back!!!!");
                            back = int.Parse(Console.ReadLine());
                            if (back != 4)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid Input!!!!");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        if (back == 4)
                        {
                            Console.Clear();
                            ctach = menuBar();

                        }
                    }
                    if (ctach == "2")
                    {

                        Console.Clear();
                        int back = 0;
                        bool check;
                        check = SignIn(names, passwords, path);
                        if (check == true)
                        {
                            Console.WriteLine("Success!!!!");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid username or password!!!!");
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        while (back != 4)
                        {
                            Console.WriteLine("Enter 4 to go back!!!!");
                            back = int.Parse(Console.ReadLine());
                            if (back != 4)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid Input!!!!");
                                Console.ForegroundColor = ConsoleColor.Black;
                            }
                        }
                        if (back == 4)
                        {
                            Console.Clear();
                            ctach = menuBar();

                        }
                    }
                    if (ctach == "3")
                    {
                        break;
                    }
                    Console.ReadKey();
                }
            }
      
                if (receive == "manager")
                {
                    Console.Clear();
                    c = managerLogInMenu();
                    if (c == "1")
                    {
                        Console.Clear();
                        Console.WriteLine("Enter username!!!!");
                        u = Console.ReadLine();
                        Console.WriteLine("Enter password!!!!");
                        p = Console.ReadLine();

                        if (u == manageru && p == managerp)
                        {
                            storeManagerLoginRecord(u, p, mpath);
                            Console.Clear();
                            while (true)
                            {
                                Console.Clear();
                                string r;
                                r = managermenubar();
                                if (r == "1")
                                {
                                    Console.Clear();
                                    Console.WriteLine(bankPolicy);
                                    Console.ReadKey();
                                }
                                if (r == "2")
                                {
                                    Console.Clear();
                                    string m;
                                    Console.WriteLine("Enter old username!!!!");
                                    m = Console.ReadLine();
                                    if (m == manageru)
                                    {
                                        Console.WriteLine("Enter new username!!!!");
                                        manageru = Console.ReadLine();
                                        storeManagerLoginRecord(manageru, managerp, mpath);
                                    }
                                }
                                if (r == "3")
                                {
                                    Console.Clear();
                                    string m;
                                    Console.WriteLine("Enter old password!!!!");
                                    m = Console.ReadLine();
                                    if (m == managerp)
                                    {
                                        Console.WriteLine("Enter new password!!!!");
                                        managerp = Console.ReadLine();
                                        storeManagerLoginRecord(manageru, managerp, mpath);
                                    }
                                }
                                if(r=="4")
                                {
                                  break;
                                }
                            }
                        }
                        else if (u != manageru || p != managerp)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid username or password!!!!");
                            Console.ForegroundColor = ConsoleColor.Black;
                            c = managerLogInMenu();
                        }

                    }
                if (c == "2")
                {
                    Console.WriteLine("Thanks for using our application!!!!");
                }
            }
       
            else
            {
                Console.WriteLine("Invalid Input!!!!");
                Console.Clear();
                receive = checkuser();
            }
            Console.Clear();
            Console.WriteLine("Thanks for using our application!!!!");
            Console.ReadKey();
        }
        static string checkuser()
        {
            Console.Clear();
            string option;
            Console.WriteLine("Are you manager or a user?");
            option = Console.ReadLine();
            return option;
        }
        static string menuBar()
        {
            Console.Clear();
            string option;
            Console.WriteLine("1:Sign Up!!!!!");
            Console.WriteLine("2:Sign In!!!!!");
            Console.WriteLine("3:Exit");
            Console.WriteLine("Enter your option!!!!");
            option= Console.ReadLine();
            return option;
        }
           static void SignUp(string[] names, string[] passwords , string path)
            {
            Console.Clear();
            bool flage=true;
            string name;
            string password;
            Console.WriteLine("Enter your new name!!!!");
            name = Console.ReadLine();
            Console.WriteLine("Enter your new password!!!!");
            password = Console.ReadLine();
            for(int i =0; i<5; i++)
            {
                if (name == names[i])
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("User Alreday Exists!!!!");
                    Console.ForegroundColor = ConsoleColor.Black;
                    flage = false;
                }
            }
            if(flage==true)
            {
                
                    Console.WriteLine("Success!!!!");
                StreamWriter file = new StreamWriter(path, false);                  
                    file.WriteLine(name + "," + password);
                    file.Flush();
                    file.Close();
               
            }
            }
        static bool SignIn(string[] names, string[] passwords, string path)
        {
            Console.Clear();
            bool found=false;
            string n;
            string p;
            Console.WriteLine("Enter your log in username!!!!");
            n = Console.ReadLine();
            Console.WriteLine("Enter your log in password!!!!");
            p = Console.ReadLine();
                for(int x=0; x <5; x++)
            {
                if(names[x]==n && passwords[x]==p)
                {
                    found = true;
                    break;
                }
                
            }
            return found;
        }
        static string ParseData(string record , int field)
        {
           
            int comma = 1;
            string item = "";
            for(int  x=0; x<record.Length; x++)
            {
                if(record[x]==',')
                {
                    comma++;
                }
                else if(comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        static void readData(string path,string[]names,string[]passwords)
        {
            int x = 0;
            if(File.Exists(path))
            {
                StreamReader filevariable = new StreamReader(path);
                string record;
                while((record=filevariable.ReadLine())!=null)
                {
                    names[x] = ParseData(record, 1);
                    passwords[x] = ParseData(record, 2);
                    x++;
                    if (x >= 5)
                    {
                        break;
                    }
                }
                filevariable.Close();
            }
        }
        static void removeUser(string[] names, string[] passwords, string path)
        {
            bool flage = false;
            string user;
            Console.WriteLine("Which user you want to remove?");
            user = Console.ReadLine();
            for(int x =0; x<5; x++)
            {
                if(user==names[x])
                {
                    names[x] = " ";
                    passwords[x] = " ";
                    Console.WriteLine("Removes Successfully!!!!");
                    flage = true;
                    for (int i=x;  i < 5 ; i++)
                    {
                        names[i] = names[i + 1];
                        passwords[i] = passwords[i + 1];
                        StoreToFile(names, passwords, path);
                    }
                }
            }
            if(flage==false)
            {
                Console.WriteLine("User NOT FOUND!!!!");
            }
        }
       static void StoreToFile(string[] names, string[] passwords,string path)
        {
            StreamWriter file1 = new StreamWriter(path, false);
            for (int x = 0; x < 5; x++)
            {
                file1.WriteLine(names[x] + "," + passwords[x]);
            }
            file1.Flush();
            file1.Close();
        }
        static void storeManagerLoginRecord(string u , string p,string mpath)
        {
            StreamWriter file2 = new StreamWriter(mpath, false);
            file2.WriteLine(u + "," + p);
            file2.Flush();
            file2.Close();
        }
        static void ReadManagerlogInData(string mpath, ref string manageru, ref string managerp)
        {
            if (File.Exists(mpath))
            {
                StreamReader filevariable = new StreamReader(mpath);
                string record;
                record = filevariable.ReadLine();
                manageru = ParseData(record, 1);
                managerp = ParseData(record, 2);
                filevariable.Close();
            }
        }
        static string managerLogInMenu()
        {
            Console.Clear();
            string option;
            Console.WriteLine("1:Sign In!!!!!");
            Console.WriteLine("2:Exit");
            Console.WriteLine("Enter your option!!!!");
            option = Console.ReadLine();
            return option;
        }
        static string managermenubar()
        {
            string option;
            Console.WriteLine("1.See policy!!!!");
            Console.WriteLine("2.Change usernam!!!!");
            Console.WriteLine("3.Change password!!!!");
            Console.WriteLine("4.Exit!!!!");
            option = Console.ReadLine();
            return option;
        }
    }
}
