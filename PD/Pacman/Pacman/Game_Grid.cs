using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pacman
{
    public class Game_Grid
    {
        public static  Game_Cell [,] All_Cells;

        public  int Rows;
        public int Columns;

        public Game_Grid(string filename,int Rows,int Columns)
        {
            this.Rows = Rows;
            this.Columns = Columns;

            All_Cells = new Game_Cell[Rows, Columns];

            Load_Grid(filename);
        }

        public Game_Grid()
        {

        }

        void Load_Grid(string filename)
        {

            StreamReader filevariable = new StreamReader(filename);
            string record;
            for(int j = 0 ; j < this.Rows ; j++)
            {
                record = filevariable.ReadLine();
                for (int i = 0; i < this.Columns; i++)
                {
                    Game_Cell cell = new Game_Cell(j, i, this);
                    Char Cell_Character = record[i];

                    Object_Type type = Game_Object.Get_Game_Objet(Cell_Character);

                    Game_Object gameobject = new Game_Object(Cell_Character, type);

                    cell.current = gameobject;

                    All_Cells[j, i] = cell;
                }
            }
            filevariable.Close();
        }

        public static Game_Cell Get_Cell(int x , int y)
        {
            return All_Cells[x, y];
        }
    }
}
