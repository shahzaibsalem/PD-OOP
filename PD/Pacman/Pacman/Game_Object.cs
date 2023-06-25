using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class Game_Object
    {
        public char Cell_Character;

        public Game_Cell Current_Cell = new Game_Cell();

        public Object_Type Type;

        public Game_Object(char Cell_Character, Object_Type Type)
        {
            this.Cell_Character = Cell_Character;
            this.Type = Type;
        }

        public Game_Object()
        {

        }

        public static Object_Type Get_Game_Objet(char display)
        {

            if(display=='|' || display=='#' || display=='%')
            {
                return Object_Type.Wall;
            }

            else if(display=='.')
            {
                return Object_Type.Reward;
            }

            return Object_Type.None;
        }
    }
}
