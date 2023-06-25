using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacman;

namespace Pacman.DL
{
    public class All_Functions
    {
        public static void Print_Ghost_Horizontal(Horizonol_Ghost horizontol)
        {
            Console.SetCursorPosition(horizontol.x, horizontol.y);
            Console.Write(horizontol.Ghost_Character);
        }
        public static void Print_Ghost_Vertical(Vertical_Ghost horizontol)
        {
            Console.SetCursorPosition(horizontol.x, horizontol.y);
            Console.Write(horizontol.Ghost_Character);
        }

        public static void Erase_Ghost_Horizontal(Horizonol_Ghost horizontol)
        {
            Console.SetCursorPosition(horizontol.x, horizontol.y);
            Console.Write(" ");
        }
        public static void Erase_Ghost_Vertical(Vertical_Ghost vertical)
        {
            Console.SetCursorPosition(vertical.x, vertical.y);
            Console.Write(" ");
        }

       public static void Move_Ghost_Horizontally(ref string direction, ref Horizonol_Ghost horizontol)
       {
            if (direction == "Left")
            {
                Game_Cell cell = horizontol.Move(horizontol.x - 1, horizontol.y, direction);

                if (cell.current.Type != Object_Type.Wall)
                {
                    Erase_Ghost_Horizontal(horizontol);
                    horizontol.x = horizontol.x - 1;
                    Print_Ghost_Horizontal(horizontol);
                }

                else
                {
                    direction = "Right";
                }
            }
            if (direction == "Right")
            {
                Game_Cell cell = horizontol.Move(horizontol.x + 1, horizontol.y, direction);

                if (cell.current.Type != Object_Type.Wall)
                {
                    Erase_Ghost_Horizontal(horizontol);
                    horizontol.x = horizontol.x + 1;
                    Print_Ghost_Horizontal(horizontol);
                }

                else
                {
                    direction = "Left";
                }
            }
       }

        public static void Move_Vertically(ref Vertical_Ghost vertical, ref string direction)
        {
            if (direction == "Up")
            {
                Game_Cell cell = vertical.Move(vertical.x, vertical.y, direction);

                if (cell.current.Type != Object_Type.Wall)
                {
                    Erase_Ghost_Vertical(vertical);
                    vertical.y = vertical.y - 1;
                    Print_Ghost_Vertical(vertical);
                }

                else
                {
                    direction = "Down";
                }
            }
            if (direction == "Down")
            {
                Game_Cell cell = vertical.Move(vertical.x, vertical.y, direction);

                if (cell.current.Type != Object_Type.Wall)
                {
                    Erase_Ghost_Vertical(vertical);
                    vertical.y = vertical.y + 1;
                    Print_Ghost_Vertical(vertical);
                }

                else
                {
                    direction = "Up";
                }
            }
        }
    }
}
