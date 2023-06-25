using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using EZInput;
using Pacman.DL;

namespace Pacman
{
    class Program
    {
        static void Main(string[] args)
        {
            string hdirection = "Right";
            string vdirection = "Down";
       
            Game_Grid grid = new Game_Grid("C:\\OOP Week 11\\Maze.txt",24,70);
            Game_Cell start = new Game_Cell(12,22,grid);
            Pacman_Player pacman = new Pacman_Player('p',start);
            Horizonol_Ghost horizontol = new Horizonol_Ghost(5, 5, 'G');
            Vertical_Ghost vertical = new Vertical_Ghost(7,9,'G');

            Print_Maze(grid);
            printGameObject(pacman);
           

            bool gameRunning = true;
            while (gameRunning)
            {
                 All_Functions. Print_Ghost_Horizontal(horizontol);
                 All_Functions.Print_Ghost_Vertical(vertical);
                 All_Functions. Move_Ghost_Horizontally(ref hdirection, ref horizontol);
                 All_Functions. Move_Vertically(ref vertical, ref vdirection);

                Thread.Sleep(90);
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    moveGameObject(pacman, Game_Direction.Up);
                }

                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    moveGameObject(pacman, Game_Direction.Down);
                }

                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    moveGameObject(pacman, Game_Direction.Right);
                }

                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    moveGameObject(pacman, Game_Direction.Left);
                }
            }

            Console.ReadKey();
        }

        static void Print_Maze(Game_Grid grid)
        {
            for (int x = 0; x < grid.Rows; x++)
            {
               
                for (int y = 0; y < grid.Columns; y++)
                {
                    Game_Cell cell = Game_Grid.Get_Cell(x, y);
                    printCell(cell);
                }

            }
        }
        static void printCell(Game_Cell cell)
        {
            Console.SetCursorPosition(cell.y, cell.x);
            Console.Write(cell.current.Cell_Character);
        }

        static void moveGameObject(Game_Object gameobject,Game_Direction direction)
        {
            Game_Cell nextCell = gameobject.Current_Cell.Next_Cell(direction);
            if (nextCell != null)
            {
                Game_Object newGO = new Game_Object( ' ', Object_Type.None);
                Game_Cell currentCell = gameobject.Current_Cell;
                clearGameCellContent(currentCell, newGO);
                gameobject.Current_Cell = nextCell;
                printGameObject(gameobject);
            }
        }
        static void clearGameCellContent(Game_Cell gameCell, Game_Object newGameObject)
        {
            gameCell.current = newGameObject;
            Console.SetCursorPosition(gameCell.y, gameCell.x);
            Console.Write(newGameObject.Cell_Character);

        }
        static void printGameObject(Game_Object gameObject)
        {
            Console.SetCursorPosition(gameObject.Current_Cell.y, gameObject.Current_Cell.x);
            Console.Write(gameObject.Cell_Character);

        }       
    }
}
