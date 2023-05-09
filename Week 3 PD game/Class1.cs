using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_3_PD_game
{
    public class Space
    {
       public int shipX = 32;
       public int shipY = 28;
       public int health = 100;
       public int score = 0;

        public Space()
        {
            shipX = 32;
            shipY = 28;
            health = 100;
            score = 0;
        }
        public Space(int x, int y, int health, int score)
        {
            shipX = x;
            shipY = y;
            this.health = health;
            this.score = score;
        }
    }
}
