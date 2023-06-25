using System;
using System.Collections.Generic;

namespace MoveToRight
{
    class Menu
    {
        public List<int> screens;
        public  int x;
        public Menu(List<int> screens)
        {
            this.screens = screens;
            this.x = 0;
        }
        public void to_the_right()
        {

            if(x<screens.Count-1)
            {
                x++;
            }
            else
            {
                x = 0;
            }
            string record = "[";
           
             for(int i =0; i<screens.Count;i++)
             {
                if(x==i)
                {
                    record = record + "[" + screens[i] + "]";
                }
                else
                {
                    record = record + screens[i] + ",";
                }
             }
        }

        public string display()
        {
            string record = "[";

            for (int i = 0; i < screens.Count; i++)
            {
                if (x == i)
                {
                    record = record + "[" + screens[i] + "]";
                }
                else
                {
                    record = record + screens[i] + ",";
                }
            }
            record = record + "]";
            return record;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int size;
            size = int.Parse(Console.ReadLine());
            List<int> screens = new List<int>();
            for (int x = 0; x < size; x++)
            {
                screens.Add(int.Parse(Console.ReadLine()));
            }
            Menu menu = new Menu(screens);
            int times = int.Parse(Console.ReadLine());
            for (int x = 0; x < times; x++)
            {
                menu.to_the_right();
            }
            Console.WriteLine(menu.display());
            Console.ReadKey();
        }

    }
}
