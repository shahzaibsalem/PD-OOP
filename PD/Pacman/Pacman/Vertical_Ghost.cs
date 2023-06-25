using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class Vertical_Ghost:Ghost
    {
        public Vertical_Ghost(int x, int y, char Ghost_Character) : base(x, y,Ghost_Character)
        {

        }
        public override Game_Cell Move(int x, int y, string direction)
        {
            if(direction=="Up")
            {
                Game_Cell cell = Game_Grid.Get_Cell(x, y - 1);
                return cell;
            }

           else if (direction == "Down")
           {
                Game_Cell cell = Game_Grid.Get_Cell(x, y + 1);
                return cell;
           }

            return null;
        }
    }
}
