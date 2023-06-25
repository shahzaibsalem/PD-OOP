using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class Horizonol_Ghost:Ghost
    {
        public Horizonol_Ghost(int x , int y, char Ghost_Character) :base( x , y,Ghost_Character)
        {

        }

        public override Game_Cell Move(int x , int y,string direction)
        {
            if(direction=="Right")
            {
                Game_Cell cell = Game_Grid.Get_Cell(x + 1, y);
                return cell;
            }

            else if (direction == "Left")
            {
                Game_Cell cell = Game_Grid.Get_Cell(x - 1, y);
                return cell;
            }
            return null;
        }

    }
}
