using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Maze.load_map();
            Maze.print_map();
            Console.ReadKey();
        }
    }
}
