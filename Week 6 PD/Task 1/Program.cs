using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Ship
    {
       public char Ship_Location;
       public string Ship_Serial_Number;
        public List<Angle> add_Ship = new List<Angle>();
       
        public Ship()
        {

        }
        public void Add_All_Info(char Ship_Location,string Ship_Serial_Number, Angle a)
        {
            this.Ship_Location = Ship_Location;
            this.Ship_Serial_Number = Ship_Serial_Number;
            add_Ship.Add(a);
        }
    }
    class Angle
    {
        public int Latitude_Degree;
        public float Latitude_Minutes;
        public int Longitude_Degree;
        public float Longitude_Minutes;
        public void Add_All_Angle_Info(int Latitude_Degree , float Latitude_Minutes, int Longitude_Degree, float Longitude_Minutes)
        {
            this.Latitude_Degree = Latitude_Degree;
            this.Latitude_Minutes = Latitude_Minutes;
            this.Longitude_Degree = Longitude_Degree;
            this.Longitude_Minutes = Longitude_Minutes;
        }
        public Angle()
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\OOP Week 5\\PD\\Task 1\\ship.txt";
            int latitude_D;
            float latitude_Min;
            int longitude_D;
            float longitude_Min;
            char location;
            string serial_number;
            List<Ship> s1 = new List<Ship>();
            do
            {
                Console.Clear();
                int receive = Menu_Bar();
                if(receive==1)
                {

                    Ship s = new Ship();
                    Angle a = new Angle();
                    Console.Clear();
                    Console.WriteLine("Enter ship latitude degree!!!!");
                    latitude_D = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter ship latitude minutes!!!!");
                    latitude_Min = float.Parse(Console.ReadLine());
                    Console.WriteLine("Enter ship longitude degree!!!!");
                    longitude_D = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter ship longitude minutes!!!!");
                    longitude_Min = float.Parse(Console.ReadLine());
                    a.Add_All_Angle_Info(latitude_D, latitude_Min, longitude_D, longitude_Min);
                    Console.WriteLine("Enter location of the ship!!!!");
                    location = char.Parse(Console.ReadLine());
                    Console.WriteLine("Enter serial number!!!!");
                    serial_number = Console.ReadLine();
                    s.Add_All_Info(location, serial_number,a);
                    s1.Add(s);
                }
                if(receive==2)
                {
                    Console.Clear();
                    string sr;
                    Console.WriteLine("Enter ship serial number to find!!!!");
                    sr = Console.ReadLine();
                    for (int i = 0; i < s1.Count; i++)
                    {
                        if(s1[i].Ship_Serial_Number==sr)
                        {
                            Console.WriteLine(s1[i].add_Ship[i].Latitude_Degree);
                            Console.WriteLine(s1[i].add_Ship[i].Latitude_Minutes);
                            Console.WriteLine(s1[i].add_Ship[i].Longitude_Degree);
                            Console.WriteLine(s1[i].add_Ship[i].Longitude_Minutes);
                            Console.WriteLine(s1[i].Ship_Location);
                            Console.ReadKey();
                        }
                    }
                }
                if(receive==3)
                {
                    Console.Clear();
                    int latitude_degree;
                    float latitude_min;
                    Console.WriteLine("Enter location to see serial number");
                    Console.WriteLine("Enter latitude degree!!!!");
                    latitude_degree = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter latitude minutes!!!!");
                    latitude_min = float.Parse(Console.ReadLine());
                    for (int i = 0; i < s1.Count; i++)
                    {
                        if (latitude_degree==s1[i].add_Ship[i].Latitude_Degree)
                        {
                            Console.WriteLine(s1[i].Ship_Serial_Number);
                            
                            Console.ReadKey();
                        }
                    }
                }
                if(receive==4)
                {
                    Console.Clear();
                    string serial;
                    Console.WriteLine("Enter ship serial number!!!!");
                    serial = Console.ReadLine();
                    for (int i = 0; i < s1.Count; i++)
                    {
                        if (s1[i].Ship_Serial_Number == serial)
                        {
                            int ld;
                            float lm;
                            int ld1;
                            float lm1;
                            Console.WriteLine("Enter new latitude angle!!!!");
                            ld = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter new latitude angle!!!!");
                            lm = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter new longitude angle!!!!");
                            ld1 = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter new longitude angle!!!!");
                            lm1 = int.Parse(Console.ReadLine());
                            s1[i].add_Ship[i].Latitude_Degree=ld;
                            s1[i].add_Ship[i].Latitude_Minutes=lm;
                            s1[i].add_Ship[i].Longitude_Degree=ld1;
                            s1[i].add_Ship[i].Longitude_Minutes=lm1;
                            Console.ReadKey();
                        }
                    }
                }
                if(receive==5)
                {
                    Console.Clear();
                    break;
                }

            } while (true);
            Console.ReadKey();
        }
        static int Menu_Bar()
        {
            Console.Clear();
            int option;
            Console.WriteLine("Enter your choice!!!!");
            Console.WriteLine("___________________________________");
            Console.WriteLine("1.Add ship!!!!");
            Console.WriteLine("2.View ship position!!!!");
            Console.WriteLine("3.View ship serial number!!!!");
            Console.WriteLine("4.Change ship position!!!!");
            Console.WriteLine("5.Exit!!!!");
            Console.WriteLine("______________________________________");
            option = int.Parse(Console.ReadLine());
            return option;
        }
    }
}
