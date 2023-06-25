using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class Game_Cell
    {
        public int x;
        public int y;

        public Game_Object current;
        public Game_Grid Grid;

        public Game_Cell(int x, int y, Game_Grid Grid, Game_Object current)
        {
            this.x = x;
            this.y = y;
            this.Grid = Grid;
            this.current = current;
        }

        public Game_Cell(int x, int y, Game_Grid Grid)
        {
            this.x = x;
            this.y = y;
            this.Grid = Grid;
        }

        public Game_Cell()
        {

        }

        public Game_Cell Next_Cell(Game_Direction Direction)
        {
               if (Direction == Game_Direction.Up)
               {
                   if (this.y > 0)
                   {
                    Game_Cell cell = Game_Grid.Get_Cell(x - 1, y);

                        if (cell.current.Type != Object_Type.Wall)
                        {
                        return cell;
                        }
                   }
               }
                if (Direction == Game_Direction.Down)
                {
                    
                    if (this.x < 23)
                    {
                        Game_Cell cell = Game_Grid.Get_Cell(x + 1, y);

                        if (cell.current.Type != Object_Type.Wall)
                        {
                            return cell;
                        }

                    }
                }
                if (Direction == Game_Direction.Right)
                {

                    if (this.y >0)
                    {
                        Game_Cell cell = Game_Grid.Get_Cell(x, y+1);

                        if (cell.current.Type != Object_Type.Wall)
                        {
                            return cell;
                        }

                    }
                }
                if (Direction == Game_Direction.Left)
                {

                    if (this.y >0)
                    {
                        Game_Cell cell = Game_Grid.Get_Cell(x, y - 1);

                        if (cell.current.Type != Object_Type.Wall)
                        {
                            return cell;
                        }

                    }
                }
                return null;
            
        }
    }
}

