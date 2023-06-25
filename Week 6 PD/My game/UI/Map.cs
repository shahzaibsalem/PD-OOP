using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_game.UI
{
    public class Map
    {
        public static string[,] map = new string[32, 104]; 
     
        public static void Print_Map()
        {
            for (int x = 0; x < 32; x++)
            {
                for(int y = 0;y<104;y++)
                {
                    if(x == 1|| x== 30)
                    {
                        map[x, y] = "-";
                    }
                    else if (y == 1 || y == 102)
                    {
                        map[x, y] = "#";
                    }
                    else
                    {
                        map[x, y] = " ";
                    }
                }
            }
                Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 104; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.WriteLine(map[i, j]);
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
      
    }
}
