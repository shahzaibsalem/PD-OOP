using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class Pacman_Player:Game_Object
    {
        public Pacman_Player(char Cell_Character,Game_Cell start):base(Cell_Character, Pacman.Object_Type.Player)
        {
            this.Current_Cell = start;
        }
    }
}
