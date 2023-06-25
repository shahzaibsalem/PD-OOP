using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_1
{
   public class Maze
   {
        public static int row = 20;
        public static Cell[,] maze=new Cell[row,46];
        public static void load_map()
        {
            string path = "C:\\OOP Week 7\\Week 7 PD\\maze.txt";
            StreamReader file = new StreamReader(path);
            if (File.Exists(path))
            {
                string record ;
                    int r = 0;
                while ((record = file.ReadLine()) != null)
                {
                    for (int i = 0; i < 46; i++)
                    {
                        Cell c = new Cell(i, r, record[i]);
                        maze[r, i] = c;
                    }
                    r++;
                }                       
            }
        }
        public static void print_map()
        {
           for(int i =0; i<20;i++)
           {
                for(int j =0; j <46; j++)
                {
                    Console.SetCursorPosition(maze[i, j].x, maze[i, j].y);
                    Console.Write(maze[i, j].value);
                }
                
           }
        }

    }
}
