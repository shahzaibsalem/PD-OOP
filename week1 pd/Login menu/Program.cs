using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Login_menu
{
    class Program
    {
        static void Main(string[] args)
        {
            int Catch;
            string path = "C:\\OOP week 1\\Login menu\\log.txt";
            string n;
            string p;
            string[] name = new string[8];
            string[] password = new string[8];
            loadData(path, name, password);
           
            Catch = menu();
            while (true)
            {
                if (Catch == 1)
                {
                    Console.WriteLine("ENTER NEW USERNAME!!!!");
                    n = Console.ReadLine();
                    Console.WriteLine("ENTER NEW PASSWORD!!!!");
                    p = Console.ReadLine();
                    signUp(n,p, path);
                }
                if (Catch == 2)
                {
                    Console.WriteLine("ENTER USERNAME!!!!");
                    n = Console.ReadLine();
                    Console.WriteLine("ENTER PASSWORD!!!!");
                    p = Console.ReadLine();
                    signIn(n, p, name, password);
                }
                if (Catch == 3)
                {
                    break;
                }

            }
            Console.ReadKey();
        }
        static int menu()
        {
            int opt;
            Console.WriteLine("1.SIGN UP!!!!");
            Console.WriteLine("2.SIGN IN!!!!");
            Console.WriteLine("3.EXIT!!!!");
            opt=int.Parse(Console.ReadLine());
            return opt;
        }
        static string getField(string record , int field)
        {
            int comma = 1;
            string item = " ";
            for(int x =0; x<record.Length; x++)
            {
                if(record[x]== ',')
                {
                    comma++;
                }
                else if(comma==field)
                {
                    item = item + record[x];
                }

            }
            return item;
        }
        static void loadData(string path, string[]name,string[]password)
        {
            int x = 0;
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while((record = fileVariable.ReadLine())!=null)
                {
                    name[x] = getField(record, 1);
                    password[x] = getField(record, 2);
                    x++;
                    if(x>=8)
                    {
                        break;
                    }
                }
                fileVariable.Close();
            }
            else
            {
                Console.Write("NOT EXIST!!!!");
            }

        }
        static void signIn(string n , string p , string[]name , string[]password)
        {
            bool flage = false;
            for(int x=0; x<8; x++)
            {
                if(n==name[x] && p==password[x])
                {
                    Console.WriteLine("Valid user!!!!");
                  flage = true;
                }
            }
            if(flage == false)
            {
                Console.WriteLine("Invalid user!!!!");
            }
        }
        static void signUp(string n , string p , string path)
        {
            StreamWriter ccc = new StreamWriter("C:\\OOP week 1\\Login menu\\log.txt", true);
            ccc.WriteLine(n + " " + p);
            ccc.Flush();
            ccc.Close();
        }
    }
}
