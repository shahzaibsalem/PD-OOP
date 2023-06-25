using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_Application.BL;
using System.IO;
using System.Threading;

namespace Bank_Application.DL
{

    public class All_Functions
    {
        public static List<All_Credentials> Credentials_List = new List<All_Credentials>();
        public static List<Added_Amount> added_amount_list = new List<Added_Amount>();
        public static List<Added_Amount> final_added_amount_list = new List<Added_Amount>();
        public static List<Deducted_Money> deducted_amount_list = new List<Deducted_Money>();
        public static List<Comments> comments_list = new List<Comments>();
        public static List<Message> message_list = new List<Message>();
        public static List<Workers_Data> workers_list = new List<Workers_Data>();
        public static List<string> policies = new List<string>();
        public static void Add_Users_Managers_To_List(All_Credentials s)
        {
            Credentials_List.Add(s);
            Save_Credentials_To_File();
        }

        public static void Save_Credentials_To_File()
        {
            string LogIn_Data_File = "C:\\Users\\hp\\Desktop\\OOP bank\\All_LogIn_Information_Of_Users_And_Manager.txt";
            StreamWriter write = new StreamWriter(LogIn_Data_File, false);

            foreach (All_Credentials credential in Credentials_List)
            {
                write.WriteLine(credential.username + "," + credential.password + "," + credential.IsAdmin);
            }
            write.Flush();
            write.Close();
        }

        public static void Load_Credentials_From_File()
        {
            string LogIn_Data_File = "C:\\Users\\hp\\Desktop\\OOP bank\\All_LogIn_Information_Of_Users_And_Manager.txt";
            if (File.Exists(LogIn_Data_File))
            {
                StreamReader fileVariable = new StreamReader(LogIn_Data_File);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    string username = getField(record, 1);
                    string password = getField(record, 2);
                    string IsAdmin = (getField(record, 3));

                    All_Credentials s = new All_Credentials(username, password, IsAdmin);
                    Credentials_List.Add(s);
                }
                fileVariable.Close();
            }
        }
        public static string getField(string record, int field)
        {
            int comma = 1;
            string item = "";
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

        public static bool Check_valid_User(string username)
        {
            bool flag = false;

            foreach (All_Credentials credentials in Credentials_List)
            {
                if (credentials.username == username)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        public static All_Credentials Check_Is_LogIn_info_Correct(string username, string password)
        {

            string IsAdmin = "";
            bool flag = false;

            foreach (All_Credentials credentials in Credentials_List)
            {
                if (credentials.username == username && credentials.password == password)
                {
                    flag = true;
                    IsAdmin = credentials.IsAdmin;
                }
            }
            if (flag == false)
            {
                
            }
            All_Credentials credential = new All_Credentials(username, password, IsAdmin);
            return credential;
        }

        public static void Take_Input_For_Added_Money()
        {
            string username = "";
            string password = "";
            string Money = "0";
            int amount = 0;
            int count = 0;
            bool flag = false;

            count = Credentials_List.Count();

            if (count == 0)
            {
                Console.WriteLine("No bank account found");
            }
            else
            {

                Console.WriteLine("How much amount you want to add?");
                Money = (Console.ReadLine());

                amount = int.Parse(Money);

                if (amount <= 0)
                {
                    Console.WriteLine("Wrong Amount Entered!!!!");
                }

                else
                {
                    Console.WriteLine("Enter your password:");
                    password = Console.ReadLine();
                    foreach (All_Credentials credentials in Credentials_List)
                    {
                        if (credentials.password == password)
                        {
                            flag = true;
                            username = credentials.username;
                            break;
                        }
                    }
                    if (flag == true)
                    {
                        Added_Amount added = new Added_Amount(username, password, Money);

                        added.Set_Added_Amount(Money);
                        added.Set_Password(password);
                        added.Set_Username(username);

                        added_amount_list.Add(added);
                        Add_Added_Money_To_The_File();

                        Console.WriteLine("Success!!!!");
                    }
                    else
                    {
                        Console.WriteLine("Wrong Input!!!!");
                    }

                }
            }
        }

        public static void Add_Added_Money_To_The_File()
        {
            string Added_Amount_path = "C:\\Users\\hp\\Desktop\\OOP bank\\Added_Money_Of_Users.txt";
            StreamWriter write = new StreamWriter(Added_Amount_path, false);
            foreach (Added_Amount added in added_amount_list)
            {
                write.WriteLine(added.Get_Username() + "," + added.Get_Password() + "," + added.Get_Added_Amount());
            }
            write.Flush();
            write.Close();

        }

        public static void Load_Added_Amount_From_File()
        {
            string Added_Amount_path = "C:\\Users\\hp\\Desktop\\OOP bank\\Added_Money_Of_Users.txt";

            if (File.Exists(Added_Amount_path))
            {
                StreamReader fileVariable = new StreamReader(Added_Amount_path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    string username = getField(record, 1);
                    string password = getField(record, 2);
                    string amount = getField(record, 3);

                    Added_Amount added = new Added_Amount(username, password, amount);

                    added.Set_Added_Amount(amount);
                    added.Set_Password(password);
                    added.Set_Username(username);

                    added_amount_list.Add(added);

                }
                fileVariable.Close();
            }
        }
        public static bool Check_Valid_User_ForDeducted(string password, string username)
        {
            bool flag = false;

            foreach (Added_Amount added in added_amount_list)
            {
                if (added.Get_Password() == password)
                {
                    flag = true;
                }
            }
            return flag;
        }

        public static void Check_Valid_Amount(int amount, string username, string password)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid Input!!!!");
            }
            else if (amount > 0)
            {
                foreach (Added_Amount added in added_amount_list)
                {
                    if (password == added.Get_Password())
                    {
                        int price = int.Parse(added.Get_Added_Amount());
                        price = price - amount;
                        username = added.Get_Username();

                        added.Set_Added_Amount(price.ToString());

                        Deducted_Money deducted = new Deducted_Money(username, password, amount);
                        deducted.Set_Username(username);
                        deducted.Set_Password(password);
                        deducted.Set_Deducted_Money(amount);

                        deducted_amount_list.Add(deducted);

                        Add_Deducted_Money_To_File();
                        Add_Added_Money_To_The_File();
                      
                        Console.WriteLine("Success!!!!");
                    }
                }

            }
        }
        public static void Add_Deducted_Money_To_File()
        {
            string Deducted_Path = "C:\\Users\\hp\\Desktop\\OOP bank\\Deducted_Money_Of_User.txt";

            StreamWriter write = new StreamWriter(Deducted_Path, true);

            foreach(Deducted_Money deducted in deducted_amount_list)
            {
                write.WriteLine(deducted.Get_Username() + "," + deducted.Get_Password() + "," + deducted.Get_Password());
            }
           
            write.Flush();
            write.Close();
        }

        public static void Load_Deducted_Moeny_From_List()
        {
            string Deducted_Path = "C:\\Users\\hp\\Desktop\\OOP bank\\Deducted_Money_Of_User.txt";

            if (File.Exists(Deducted_Path))
            {
                StreamReader fileVariable = new StreamReader(Deducted_Path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    string username = getField(record, 1);
                    string password = getField(record, 2);
                    string amount = getField(record, 3);

                    int price = int.Parse(amount);

                    Deducted_Money deducted = new Deducted_Money(username, password, price);

                    deducted.Set_Username(username);
                    deducted.Set_Password(password);
                    deducted.Set_Deducted_Money(price);

                    deducted_amount_list.Add(deducted);

                }
                fileVariable.Close();
            }
        }
    
        public static void Change_User_Username()
        {
            string password;
            bool flag = false;
            string username;
            Console.WriteLine("Enter your old password:");
            password = Console.ReadLine();
            foreach (All_Credentials credential in Credentials_List)
            {
                if (password == credential.password)
                {
                    flag = true;
                }
            }

            if (flag)
            {
                Console.WriteLine("Enter your new username:");
                username = Console.ReadLine();

                bool Catch = Check_valid_User(username);

                if (!Catch)
                {
                    foreach (All_Credentials credential in Credentials_List)
                    {
                        if (password == credential.password)
                        {
                            credential.username = username;
                            Save_Credentials_To_File();
                            Console.WriteLine("Success!!!!");
                        }
                    }
                }
                else if (Catch)
                {
                    Console.WriteLine("Username already exists");
                }

            }

            else
            {
                Console.WriteLine("Wrong Input!!!!");
            }
        }

        public static void Change_User_Password()
        {
            string password;
            bool flag = false;
            string password1;
            Console.WriteLine("Enter your old password:");
            password = Console.ReadLine();
            foreach (All_Credentials credential in Credentials_List)
            {
                if (password == credential.password)
                {
                    flag = true;
                }
            }

            if (flag)
            {
                Console.WriteLine("Enter your new password:");
                password1 = Console.ReadLine();

                foreach (All_Credentials credential in Credentials_List)
                {
                    if (password == credential.password)
                    {
                        credential.password = password1;
                        Save_Credentials_To_File();
                        Console.WriteLine("Success!!!!");
                    }
                }

            }
            else if (!flag)
            {
                Console.WriteLine("Wrong Input!!!!");
            }
        }

        public static void Input_For_Comments()
        {
            bool flag = false;
            string username="";
            string password;
            string comment;

            Console.WriteLine("Enter your password:");
            password = Console.ReadLine();

            foreach (All_Credentials credential in Credentials_List)
            {
                if (password == credential.password)
                {
                    username = credential.username;
                    flag = true;
                    break;
                }
            }

            if(flag)
            {
                Console.WriteLine("Enter your comment:");
                comment = Console.ReadLine();

                Comments cre = new Comments(username, password, comment);

                cre.Set_Username(username);
                cre.Set_Password(password);
                cre.Set_Comment(comment);

                comments_list.Add(cre);
                Add_Comments_ToFile();       
                
                Console.WriteLine("Success!!!!");
            }
        }

        public static void Add_Comments_ToFile()
        {
            string path = "C:\\Users\\hp\\Desktop\\OOP bank\\Comments.txt";

            StreamWriter write = new StreamWriter(path, false);

            foreach (Comments cre in comments_list)
            {
                write.WriteLine(cre.Get_Username() + "," + cre.Get_Password() + "," + cre.Get_Comment());
            }
            write.Flush();
            write.Close();

        }

        public static void Load_Comments_From_File()
        {
            string path = "C:\\Users\\hp\\Desktop\\OOP bank\\Comments.txt";

            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    string username = getField(record, 1);
                    string password = getField(record, 2);
                    string comments = getField(record, 3);



                    Comments cre = new Comments(username, password, comments);

                    cre.Set_Username(username);
                    cre.Set_Password(password);
                    cre.Set_Comment(comments);

                    comments_list.Add(cre);

                }
                fileVariable.Close();
            }
        }

        public static void Delete_Bank_Account()
        {
            string username;
            string password;
            bool flag = false;

            Console.WriteLine("Enter your username:");
            username = Console.ReadLine();
            Console.WriteLine("Entr your password:");
            password = Console.ReadLine();

            foreach (All_Credentials credentials in Credentials_List)
            {
                if (credentials.username == username && credentials.password == password)
                {
                    Credentials_List.Remove(credentials);
                    Save_Credentials_To_File();
                    flag = true;
                    break;
                }
            }

            if(flag)
            {
                Console.Clear();
                Console.WriteLine("Deleting your account");
                for(int x =0; x<8; x++)
                {
                    Thread.Sleep(200);
                    Console.Write(".");
                }
                Console.Clear();
                Console.WriteLine("Account deleted successfully!!!!");
            }
            else if(!flag)
            {
                Console.WriteLine("Wrong Input!!!!");
            }
        }

        public static void Drop_Message()
        {
            string password = "";
            string username = "";
            string message = "";
            bool flag = false;

            Console.WriteLine("Enter your password:");
            password = Console.ReadLine();

            foreach (All_Credentials credentials in Credentials_List)
            {
                if (credentials.password == password)
                {
                    password = credentials.password;
                    username = credentials.username;
                    flag = true;
                    break;
                }
            }

            if(flag)
            {
                Console.WriteLine("Enter your message for the manager:");
                message = Console.ReadLine();

                Message messages = new Message(username,password,message);

                messages.Set_Username(username);
                messages.Set_Password(password);
                messages.Set_Message(message);

                message_list.Add(messages);
                Add_Message_ToList();

                Console.WriteLine("Success!!!!");
            }

            else if(!flag)
            {
                Console.WriteLine("Wrong Input!!!!");
            }
        }

        public static void Add_Message_ToList()
        {
            string path = "C:\\Users\\hp\\Desktop\\OOP bank\\Messages.txt";

            StreamWriter write = new StreamWriter(path, false);

            foreach (Message messages in message_list)
            {
                write.WriteLine(messages.Get_Username() + "," + messages.Get_Password() + "," + messages.Get_Comment());
            }
            write.Flush();
            write.Close();
        }

        public static void Load_Messages_From_List()
        {
            string path = "C:\\Users\\hp\\Desktop\\OOP bank\\Messages.txt";

            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    string username = getField(record, 1);
                    string password = getField(record, 2);
                    string messages = getField(record, 3);



                   Message message = new Message(username, password, messages);

                   message.Set_Username(username);
                   message.Set_Password(password);
                   message.Set_Message(messages);

                   message_list.Add(message);

                }
                fileVariable.Close();
            }
        }

        public static bool Valid_Salary(int salary,string name,string city,string post)
        {
            bool flag = false;

            if (salary > 0)
            {
                Workers_Data workers = new Workers_Data(name, city, salary, post);
                workers.Set_Name(name);
                workers.Set_City(city);
                workers.Set_Salary(salary);
                workers.Set_Post(post);

                workers_list.Add(workers);
                Add_Workers_To_File();
                flag = true;
                return flag;
            }

            else if(salary<=0)
            {
                flag = false;
            }

            return flag;
        }

        public static void Add_Workers_To_File()
        {
            string path = "C:\\Users\\hp\\Desktop\\OOP bank\\Workers_Data.txt";

            StreamWriter write = new StreamWriter(path, false);

            foreach (Workers_Data worker in workers_list)
            {
                write.WriteLine(worker.Get_Name() + "," + worker.Get_City() + "," + worker.Get_Salary()+","+worker.Get_Post());
            }
            write.Flush();
            write.Close();
        }

        public static void Load_Workers_From_File()
        {
            string path = "C:\\Users\\hp\\Desktop\\OOP bank\\Workers_Data.txt";

            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    string name = getField(record, 1);
                    string city = getField(record, 2);
                    int salary =int.Parse(getField(record, 3));
                    string post = getField(record, 4);

                    Workers_Data workers = new Workers_Data(name, city, salary, post);
                    workers.Set_Name(name);
                    workers.Set_City(city);
                    workers.Set_Salary(salary);
                    workers.Set_Post(post);

                    workers_list.Add(workers);

                }
                fileVariable.Close();
            }
        }

        public static void Update_Salary_Of_Worker()
        {
            int salary;
            bool flag = false;
            string password;
            bool update = false;

           

            Console.WriteLine("Enter your password:");
            password = Console.ReadLine();

            foreach (All_Credentials credential in Credentials_List)
            {
                if (password == credential.password)
                {
                    flag = true;
                    break;
                }
            }

            if (flag)
            {
                Console.WriteLine("Enter name of worker:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter the new salary:");
                salary = int.Parse(Console.ReadLine());

                if (salary > 0)
                {



                    foreach (Workers_Data worker in workers_list)
                    {
                        if (worker.Get_Name() == name)
                        {
                            worker.Set_Salary(salary);
                            Add_Workers_To_File();
                            update = true;
                            break;
                        }
                    }
                    if (update)
                    {
                       
                        Console.Write("Updating Salary");

                        for (int i = 0; i < 8; i++)
                        {
                            Thread.Sleep(200);
                            Console.Write(".");
                            Thread.Sleep(200);
                        }

                        Console.Clear();

                        Console.WriteLine("Salary update successfully!!!!");
                    }

                    else if (!update)
                    {
                        Console.WriteLine("Worker do not found!!!!");
                    }

                }

                else if (salary <= 0)
                {
                    Console.WriteLine("Wrong amount entered!!!!");
                }
            }
            else if (!flag)
            {
                Console.WriteLine("Wrong Input!!!!");
            }

        }

        public static void Remove_Worker()
        {
            Console.WriteLine("Enter name of worker:");
            string name = Console.ReadLine();
            bool flag = false;

            foreach (Workers_Data workers in workers_list)
            {

                if (workers.Get_Name() == name)
                {
                    workers_list.Remove(workers);
                    Add_Workers_To_File();

                    Console.Write("Removing worker");


                    for (int i = 0; i < 8; i++)
                    {
                        Thread.Sleep(200);
                        Console.Write(".");
                        Thread.Sleep(200);
                    }

                    Console.Clear();

                    Console.WriteLine("Worker removed successfully!!!!");

                    flag = true;
                    break;
                }

               
            }

           if(flag==false)
           {
                Console.WriteLine("Worker not found!!!!");
           }
            
        }

        public static void Add_Policy_To_File()
        {
            string path = "C:\\Users\\hp\\Desktop\\OOP bank\\Policy.txt";
            StreamWriter write = new StreamWriter(path, false);

            for (int x = 0; x < policies.Count; x++)
            {
                write.WriteLine(policies[x]);
            }
            write.Flush();
            write.Close();
        }
        public static void Load_Policy_From_File()
        {
            string path = "C:\\Users\\hp\\Desktop\\OOP bank\\Policy.txt";

            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    string policy = getField(record, 1);

                    policies.Add(policy);
                }
                fileVariable.Close();
            }
        }

        public static void Remove_Account()
        {
            string name;

            Console.WriteLine("Enter name to remove:");
            name = Console.ReadLine();

            bool flag = Check_valid_User(name);

            if (flag)
            {

                foreach(All_Credentials credential in Credentials_List)
                {
                    if(name == credential.username)
                    {
                        Credentials_List.Remove(credential);
                        Save_Credentials_To_File();
                    }
                }

                foreach (Added_Amount added in added_amount_list)
                {
                    if (name == added.Get_Username())
                    {
                        added_amount_list.Remove(added);
                        Add_Added_Money_To_The_File();
                    }
                }

                foreach (Deducted_Money deducted in deducted_amount_list)
                {
                    if (name == deducted.Get_Username())
                    {
                        deducted_amount_list.Remove(deducted);
                        Add_Deducted_Money_To_File();
                    }
                }
                Console.Write("Deleting account");


                for (int i = 0; i < 8; i++)
                {
                    Thread.Sleep(200);
                    Console.Write(".");
                    Thread.Sleep(200);
                }

                Console.Clear();

                Console.WriteLine("Account deleted successfully!!!!");
            }

            else if(!flag)
            {
                Console.WriteLine("Wrong Input!!!!");
            }
        }

        public static double Calculate_Tax()
        {
            double tax = 0.0;

            foreach(Added_Amount added in added_amount_list)
            {
                
                tax = tax + added.Tax();
            }

            return tax;
        }

    }
}
