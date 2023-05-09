using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZInput;

namespace Week_3_PD_game
{
    class Program
    {
        static string[,] map = new string[,] {
          {"_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_"},
          {"||" , " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","||"},
          {"||" , " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","||"},
          {"||" , " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","||"},
          {"||" , " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","||"},
          {"||" , " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","||"},
          {"||" , " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","||"},
          {"||" , " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","||"},
          {"||" , " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","||"},
          {"||" , " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","||"},
          {"||" , " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","||"},
          {"||" , " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","||"},
          {"||" , " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","||"},
          {"||" , " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","||"},
          {"||" , " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","||"},
          {"||" , " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","||"},
          {"||" , " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","||"},
          {"||" , " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","||"},
          {"||" , " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","||"},
          {"||" , " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","||"},
          {"||" , " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","||"},
          {"||" , " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","||"},
          {"||" , " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","||"},
          {"||" , " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","||"},
          {"||" , " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","||"},
          {"_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_"}
          };

        static void Main(string[] args)
        {
            Space obj = new Space(32, 28, 100, 0);
            string Enemy_direction = "Right";
            int EnemyX = 42;
            int EnemyY = 5;
            int Enemy_Health = 100;
            int[] bulletX = new int[1000];
            int[] bulletY = new int[1000];
            bool[] isBulletActive = new bool[1000];
            int bulletCount = 0;
            char[,] map = new char[27, 30];
            print_Map();
            Print_Ship(obj.shipX, obj.shipY);
            printEnemy1(EnemyX, EnemyY);
            do
            {
                Check_Collision_Detection(EnemyX, EnemyY, obj, Enemy_Health, bulletX, bulletY, bulletCount);
                Print_Credentials(obj);
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    Move_Right(obj.shipX, obj.shipY);
                }
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    Move_Left(obj.shipX, obj.shipY);
                }
                if (Keyboard.IsKeyPressed(Key.Space))
                {
                    Generate_Bullets(obj.shipX, obj.shipY, bulletX, bulletY, bulletCount, isBulletActive);
                }
                if(obj.health==0)
                {
                    break;
                }
                if (obj.score == 100)
                {
                    
                }
                if (Enemy_Health == 0)
                {
                    break;
                }
            } while (true);
            Console.ReadKey();
        }
        static void print_Map()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < 27; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    Console.WriteLine(map[i, j]);
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void printEnemy1(int EnemyX, int EnemyY)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(EnemyX, EnemyY);
            Console.WriteLine('E');
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void Print_Ship(int shipX,int shipY)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(shipX, shipY);
            Console.WriteLine('p');
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void Move_Right(int shipX, int shipY)
        {
            char next = ReadCharFromConsole(shipX + 1, shipY);
            if (next == ' ')
            {
                Console.SetCursorPosition(shipX, shipY);
                Erase_Ship(shipX, shipY);
                shipX++;
                Console.SetCursorPosition(shipX - 1, shipY);
                Print_Ship(shipX, shipY);
            }
        }
        static void Move_Left(int shipX, int shipY)
        {
            char next = ReadCharFromConsole(shipX - 1, shipY);
            if (next == ' ')
            {
                Console.SetCursorPosition(shipX, shipY);
                Erase_Ship(shipX, shipY);
                shipX--;
                Console.SetCursorPosition(shipX - 1, shipY);
                Print_Ship(shipX, shipY);
            }
        }
        static void Move_Enemy(int EnemyX, int EnemyY, string Enemy_direction)
        {
            if (Enemy_direction == "Left")
            {
                char next1 = ReadCharFromConsole(EnemyX - 1, EnemyY);
                
                if (next1 == ' ')
                {
                    Console.SetCursorPosition(EnemyX, EnemyY);
                    Erase_Enemy(EnemyX, EnemyY);
                    EnemyX = EnemyX - 1;
                    Console.SetCursorPosition(EnemyX, EnemyY);
                    printEnemy1(EnemyX, EnemyY);
                }
                else

                {
                    Console.SetCursorPosition(EnemyX, EnemyY);
                    Erase_Enemy(EnemyX, EnemyY);
                    Enemy_direction = "Right";
                }
            }
            if (Enemy_direction == "Right")
            {

                char next1 = ReadCharFromConsole(EnemyX + 1, EnemyY);
               
                if (next1 == ' ' )
                {
                    Console.SetCursorPosition(EnemyX, EnemyY);
                    Erase_Enemy(EnemyX, EnemyY);
                    EnemyX = EnemyX + 1;
                    Console.SetCursorPosition(EnemyX, EnemyY);
                    printEnemy1(EnemyX, EnemyY);
                }
                else
                {
                    Console.SetCursorPosition(EnemyX, EnemyY);
                    Erase_Enemy(EnemyX, EnemyY);
                    Enemy_direction = "Left";
                }
            }
        }

        static void Erase_Ship(int x, int y)
        {
            Console.WriteLine(" ");
        }
        static void Erase_Enemy(int x, int y)
        {
            Console.WriteLine(" ");
        }
        public static char ReadCharFromConsole(int x, int y)
        {
            // Save the current cursor position
            int origX = Console.CursorLeft;
            int origY = Console.CursorTop;

            // Set the cursor position to the desired location
            Console.SetCursorPosition(x, y);

            // Read the character at the current cursor position
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            // Get the character from the ConsoleKeyInfo object
            char c = keyInfo.KeyChar;
            // Restore the original cursor position
            Console.SetCursorPosition(origX, origY);
            // Return the character
            return c;
        }
        static void Print_Bullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("^");
        }
        static void makeBulletInActive(int index, bool[] isBulletActive)
        {
            isBulletActive[index] = false;
        }
        static void Print_Enemy_Bullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("|");
        }
        static void Move_Bullet(int[] bulletX, int[] bulletY, int bulletCount, bool[] isBulletActive)
        {
            for (int x = 0; x < bulletCount; x++)
            {
                if (isBulletActive[x] == true)
                {
                    char next = ReadCharFromConsole(bulletX[x], bulletY[x] - 1);
                    if (next != ' ')
                    {
                        Erase_Bullet(bulletX[x], bulletY[x]);
                        makeBulletInActive(x, isBulletActive);
                    }
                    else if (next == ' ')
                    {
                        Erase_Bullet(bulletX[x], bulletY[x]);
                        bulletY[x] = bulletY[x] - 1;
                        Print_Bullet(bulletX[x], bulletY[x]);
                    }
                }
            }
        }
        static void Move_Enemy_Bullet(int x, int y)
        {
            
        }
        static void Erase_Enemy_Bullet(int x, int y)
        {
        }
        static void Erase_Bullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(" ");
        }
        static void Generate_Bullets(int shipX, int shipY, int[] bulletX, int[] bulletY, int bulletCount, bool[] isBulletActive)
        {
            bulletX[bulletCount] = shipX + 3;
            bulletY[bulletCount] = shipY - 1;
            isBulletActive[bulletCount] = true;
            Print_Bullet(shipX, shipY);
            bulletCount++;
        }
        static void Print_Credentials(Space obj)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(30, 0);
            Console.WriteLine(obj.score + " " + obj.health);
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void Check_Collision_Detection(int x , int y , Space obj,int Enemy_Health, int[] bulletX, int[] bulletY, int bulletCount)
        {
            if(x== bulletX[bulletCount] && y== bulletY[bulletCount])
            {
                obj.score++;
                Enemy_Health--;
            }         
        }
        static int startMenu()
        {
            int option;
            Console.WriteLine("1.Start!!!!");
            Console.WriteLine("2.Previous record!!!!");
            Console.WriteLine("3.Exit!!!!");
            option = int.Parse(Console.ReadLine());
            return option;
        }
    }
}
