using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public abstract class Ghost
    {

        public static Game_Cell[,]  cells;
        public int x;
        public int y;
        public char Ghost_Character;

        public Ghost(int x , int y, char Ghost_Character)
        {
            this.x = x;
            this.y = y;
            this.Ghost_Character = Ghost_Character;
            cells = new Game_Cell[24,70];
        }

        public abstract Game_Cell Move(int x, int y, string direction);
    }
}
