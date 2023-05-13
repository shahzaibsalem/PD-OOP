using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_game.DL
{
   public class Credentials
    {
       public int score;
       public int life;
       public int health;

        public Credentials(int score, int life, int health)
        {
            this.score = score;
            this.life = life;
            this.health = health;
        }
   }
}
