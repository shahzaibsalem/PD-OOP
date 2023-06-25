using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_1
{
   public class Cell
   {
        
        public  int x;
        public  int y;
        public  char value;

        public Cell(int x , int y,char value)
        {
            this.x = x;
            this.y = y;
            this.value = value;
        }    
   }
}
