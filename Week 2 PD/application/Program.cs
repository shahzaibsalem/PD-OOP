using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using EZInput;

namespace application
{
    class Program
    {
        static void Main(string[] args)
        {
            int add=0;
            int deducted=0;
            bool login = false;
            string n;
            string p;
            int Catch;
            string path = "C:\\OOP week2\\Week 2 PD\\record.txt";
            string path1 = "C:\\OOP week2\\Week 2 PD\\user.txt";
            List<users> s = new List<users>();
            List<functionality> s1 = new List<functionality>();
            loadDataFromFile(path, s);
            do
            {
                loadDataFromFile(path, s);
                Console.Clear();
                Catch = menu();
                if (Catch == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Enter new username!!!!");
                    n = Console.ReadLine();
                    Console.WriteLine("Enter new password!!!!");
                    p = Console.ReadLine();
                    bool flag;
                    flag = validuser(n, p, s);
                    if(flag==true)
                    {
                        Console.WriteLine("User already exists!!!!");
                    }
                    else
                    {
                        Console.WriteLine("Suuccess!!!!");
                        storeDatatoFile(path, n, p);
                    }
                    Console.ReadKey();
                }
                else if (Catch == 2)
                {
                    bool flag;
                    Console.Clear();
                    Console.WriteLine("Enter  username!!!!");
                    n = Console.ReadLine();
                    Console.WriteLine("Enter  password!!!!");
                    p = Console.ReadLine();
                    flag = validuser(n, p, s);
                    if (flag == false)
                    {
                        Console.WriteLine("Error wrong input!!!!");
                    }
                    else if (flag == true)
                    {
                        Console.WriteLine("Suuccess!!!!");
                        login = true;
                        break;
                    }
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                    break;
                }
            } while (true);
            if(login==true)
            {
                Console.Clear();
                int choice;
                Console.Clear();
                do
                {
                    Console.Clear();
                    loadUserData(path1,s1);
                    choice = userMenuBar();
                    Console.Clear();
                    if (choice == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("How much money you want to add?");
                        add = int.Parse(Console.ReadLine());
                        Console.WriteLine("Added successfully!!!!");
                        storeUserData(path1, add, deducted);
                        Console.ReadKey();
                    }
                    else if (choice == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("How much money you want to deducted?");
                        deducted = int.Parse(Console.ReadLine());
                        Console.WriteLine("Deducted successfully!!!!");
                        storeUserData(path1, add, deducted);
                        Console.ReadKey();
                    }
                    else if (choice == 3)
                    {
                        Console.Clear();
                        string n1;
                        Console.WriteLine("Enter old username!!!!");
                        n1 = Console.ReadLine();
                        for (int x = 0; x < s.Count; x++)
                        {
                            if (n1 == s[x].name)
                            {
                                Console.WriteLine("Success!!!!");
                                Console.WriteLine("Enter your new username!!!!");
                                n1 = Console.ReadLine();
                                s[x].name = n1;
                                Console.WriteLine("Changed!!!!");
                                storeDatatoFile(path, s[x].name, s[x].password);
                            }
                        }
                        Console.ReadKey();
                    }
                    else if (choice == 4)
                    {
                        Console.Clear();
                        string p1;
                        Console.WriteLine("Enter  password!!!!");
                        p1 = Console.ReadLine();
                        for (int x = 0; x < s.Count; x++)
                        {
                            if (p1 == s[x].name)
                            {
                                Console.WriteLine("Success!!!!");
                                Console.WriteLine("Enter your new password!!!!");
                                p1 = Console.ReadLine();
                                Console.WriteLine("Changed!!!!");
                                s[x].password = p1;
                                storeDatatoFile(path, s[x].name, s[x].password);
                            }
                        }
                        Console.ReadKey();
                    }
                    else if (choice == 5)
                    {
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        break;
                    }
                } while (true);
            }
            else
            {
                Console.WriteLine("Error!!!!");
            }
            Console.WriteLine("Thanks for using our application!!!!");
            Console.ReadKey();
        }
        static int menu()
        {
            int opt;
            Console.WriteLine("1.SIGN UP!!!!");
            Console.WriteLine("2.SIGN IN!!!!");
            Console.WriteLine("3.EXIT!!!!");
            opt = int.Parse(Console.ReadLine());
            return opt;
        }
        static int userMenuBar()
        {
            int opt;
            Console.WriteLine("1.Add money to account!!!!");
            Console.WriteLine("2.Withdraw moeny!!!!");
            Console.WriteLine("3.Change username!!!!");
            Console.WriteLine("4.Change password!!!!");
            Console.WriteLine("5.Exit!!!!");
            opt = int.Parse(Console.ReadLine());
            return opt;
        }

        static void signIn(string n, string p, string[] name, string[] password)
        {
            bool flage = false;
            for (int x = 0; x < 8; x++)
            {
                if (n == name[x] && p == password[x])
                {
                    Console.WriteLine("Valid user!!!!");
                    flage = true;
                }
            }
            if (flage == false)
            {
                Console.WriteLine("Invalid user!!!!");
            }
        }
        static void signUp(string n, string p, string path)
        {
            StreamWriter ccc = new StreamWriter(path, true);
            ccc.WriteLine(n + " " + p);
            ccc.Flush();
            ccc.Close();
        }
        static string getField(string record, int field)
        {
            int comma = 1;
            string item = " ";
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
        static bool validuser(string n, string p , List<users> s)
        {
            bool flag = false;
            for(int i =0; i<s.Count;i++)
            {
                if(n==s[i].name)
                {
                    if (p == s[i].password)
                    {
                        flag = true;
                        break;
                    }
                }
            }
            return flag;
        }
        static void storeDatatoFile(string path, string n , string p)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(n + "," + p);
            file.Flush();
            file.Close();
        }
        static void loadDataFromFile(string path, List<users> s)
        {
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    users info = new users();
                    info.name = getField(record, 1);
                    info.password = getField(record, 2);
                    s.Add(info);
                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("Not Exists");
            }
        }
        static void storeUserData(string path1, int add, int deduct)
        {
            StreamWriter file = new StreamWriter(path1, false);
            file.WriteLine(add + "," + deduct);
            file.Flush();
            file.Close();
        }
        static void loadUserData(string path1, List<functionality> s1)
        {
            if (File.Exists(path1))
            {
                StreamReader fileVariable = new StreamReader(path1);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    functionality info = new functionality();
                    info.addedMoney = getField(record, 1);
                    info.deductedMoney = getField(record, 2);
                    s1.Add(info);
                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("Not Exists");
            }
        }
     }
}
