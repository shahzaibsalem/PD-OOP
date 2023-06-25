using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class Random_Ghost:Ghost
    {
        public Random_Ghost(int x, int y, char Ghost_Character) : base(x, y,Ghost_Character)
        {

        }
        public override Game_Cell Move(int x, int y, string direction)
        {
            return null;
        }
    }
}
