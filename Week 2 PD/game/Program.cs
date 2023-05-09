using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZInput;


namespace game
{
    class Program
    {
        static void Main(string[] args)
        {
            int plaerHealth = 100;
            int enemy1Health = 100;
            int life = 3;
            int shipX = 32;
            int shipY = 28;
            int EnemyX = 42;
            int EnemyY = 5;
            int Enemy2X = 35;
            int Enemy2Y = 7;
            int[] bulletX = new int[1000];
            int[] bulletY = new int[1000];
            bool[] isBulletActive = new bool[1000];
            int bulletCount = 0;
            string enemyDirection1 = "Left";
            char[,] shape = new char[5, 5] {
    {' ', ' ', 'o', ' ', ' '},
    {' ', ' ', '|', ' ', ' '},
    {' ', '-', '-', '-', ' '},
    {'|', '-', '-', '-', '|'},
    {'|', '|', ' ', '|', '|'}
};
            char [,]enemy1=new char[5,5]
                {
   {'|', '|', ' ', '|', '|'},
    {'|', '-', '-', '-', '|'},
     {' ', '-', '-', '-', ' '},
     {' ', ' ', '|', ' ', ' '},
    {' ', ' ', 'o', ' ', ' '},
};
            char[,] enemy2 = new char[5, 5]
               {
   {'|', '|', ' ', '|', '|'},
    {'|', '-', '-', '-', '|'},
     {' ', '-', '-', '-', ' '},
     {' ', ' ', '|', ' ', ' '},
    {' ', ' ', 'o', ' ', ' '},
};
  string[,] map = new string[27, 30] {
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
                int receive;
                receive=startMenu();
                if (receive == 1)
                {
                printmap();
                printShip(shipX,shipY,shape);
                printEnemy1(EnemyX, EnemyY, enemy1);
                /*printEnemy2(Enemy2X,Enemy2Y,enemy2);*/
                while (true)
                {
                    moveBullet(isBulletActive, bulletX, bulletY, bulletCount);
                    moveEnemy(EnemyX, EnemyY, enemyDirection1, enemy1);
                    if (Keyboard.IsKeyPressed(Key.RightArrow))
                    {
                        moveShaperight(shipX, shipY, shape);
                    }
                    if (Keyboard.IsKeyPressed(Key.LeftArrow))
                    {
                        moveShapeleft(shipX, shipY, shape);
                    }
                    if (Keyboard.IsKeyPressed(Key.Space))
                    {
                        generateBullet(shipX, shipY, shape, bulletX, bulletY, bulletCount, isBulletActive);
                    }
                    if(life==0)
                    {
                        break;
                    }
                    if(plaerHealth==0)
                    {
                        life--;
                        plaerHealth = 100;
                    }
                    if(enemy1Health==0)
                    {
                        break;

                    }                   
                }
                if (receive == 2)
                {

                }
                if (receive == 3)
                {

                }
            
            Console.ReadKey();
        }
        static int startMenu()
        {
            int option;
            Console.WriteLine("1.Start!!!!");
            Console.WriteLine("2.Previous record!!!!");
            Console.WriteLine("3.Exit!!!!");
            option=int.Parse(Console.ReadLine());
            return option;
        }
        static void printmap()
        {
            Console.ForegroundColor = ConsoleColor.Red;
             for(int i =0 ; i<27 ; i++)
            {
                for(int j =0 ; j <30 ; j++)
                {
                    Console.WriteLine(map[i,j]);
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void printShip(int shipX , int shipY , char[,] shape)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(shipX, shipY);
            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(shipX, shipY+i);
                for (int j = 0; j < 5; j++)
                {

                   Console.Write(shape[i,j]);
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void printEnemy1(int EnemyX, int EnemyY ,char[,]enemy1)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(EnemyX, EnemyY);
            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(EnemyX, EnemyY + i);
                for (int j = 0; j < 5; j++)
                {

                    Console.Write(enemy1[i, j]);
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void printEnemy2(int Enemy2X, int Enemy2Y, char[,] enemy2)
        {
            Console.SetCursorPosition(Enemy2X, Enemy2Y);
            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(Enemy2X, Enemy2Y + i);
                for (int j = 0; j < 5; j++)
                {

                    Console.Write(enemy2[i, j]);
                }
            }
        }
       static void eraseShape(int shipX , int shipY)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(shipX, shipY + i);
                for (int j = 0; j < 5; j++)
                {

                    Console.Write(" ");
                }
            }
        }
        static void erasEnemy1(int EnemyX , int EnemyY)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(EnemyX, EnemyY + i);
                for (int j = 0; j < 5; j++)
                {

                    Console.Write(" ");
                }
            }
        }
        static void moveShaperight(int shipX, int shipY, char[,] shape)
        {
            char next = ReadCharFromConsole(shipX + 5, shipY + 4);
            if (next == ' ')
            {
                Console.SetCursorPosition(shipX, shipY);
                eraseShape(shipX, shipY);
                shipX++;
                Console.SetCursorPosition(shipX, shipY);
                printShip(shipX, shipY, shape);
            }
        }
        static void moveShapeleft(int shipX , int shipY, char[,] shape)
        {
            char next = ReadCharFromConsole(shipX - 5, shipY + 4);
            if (next == ' ')
            {
                Console.SetCursorPosition(shipX, shipY);
                eraseShape(shipX,shipY);
                shipX--;
                Console.SetCursorPosition(shipX-1, shipY);
                printShip(shipX, shipY,shape);
            }
        }
        static void generateBullet(int shipX, int shipY, char[,] shape,int [] bulletX, int[] bulletY,int bulletCount,bool [] isBulletActive)
        {
            bulletX[bulletCount] = shipX + 3;
            bulletY[bulletCount] = shipY - 1;
            isBulletActive[bulletCount] = true;
            Console.SetCursorPosition(shipX + 3, shipY - 1);
            Console.WriteLine( "^");
            bulletCount++;
        }
        static void moveBullet(bool[] isBulletActive, int[] bulletX, int[] bulletY, int bulletCount)
        {
            for (int x = 0; x < bulletCount; x++)
            {
                if (isBulletActive[x] == true)
                {
                    char next = ReadCharFromConsole(bulletX[x], bulletY[x] - 1);
                    if (next != ' ')
                    {
                        eraseBullet(bulletX[x], bulletY[x]);
                        makeBulletInActive(x, isBulletActive);
                    }
                    else if (next == ' ')
                    {
                        eraseBullet(bulletX[x], bulletY[x]);
                        bulletY[x] = bulletY[x] - 1;
                        printBullet(bulletX[x], bulletY[x]);
                    }
                }
            }
        }
        static void printBullet(int x, int y)
        {
            Console.SetCursorPosition(x,y);
            Console.WriteLine("^");
        }
        static void eraseBullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(" ");
        }
        static void makeBulletInActive(int index,bool [] isBulletActive)
        {
            isBulletActive[index] = false;
        }
        static void moveEnemy(int EnemyX , int EnemyY,string enemyDirection1, char[,] enemy1)
        {
            if (enemyDirection1 == "Left")
            {
                char next1 = ReadCharFromConsole(EnemyX - 1, EnemyY);
                char next2 = ReadCharFromConsole(EnemyX - 1, EnemyY + 1);
                char next3 = ReadCharFromConsole(EnemyX - 1, EnemyY + 2);
                char next4 = ReadCharFromConsole(EnemyX - 1, EnemyY + 3);
                char next5 = ReadCharFromConsole(EnemyX - 1, EnemyY + 4);
                if (next1 == ' ' && next2 == ' ' && next3 == ' ' && next4 == ' ' && next5 == ' ')
                {
                    Console.SetCursorPosition(EnemyX, EnemyY);
                    erasEnemy1(EnemyX, EnemyY);
                    EnemyX = EnemyX - 1;
                    Console.SetCursorPosition(EnemyX, EnemyY);
                    printEnemy1(EnemyX, EnemyY, enemy1);
                }
                else

                {
                    Console.SetCursorPosition(EnemyX, EnemyY);
                    erasEnemy1(EnemyX, EnemyY);
                    enemyDirection1 = "Right";
                }
            }
            if (enemyDirection1 == "Right")
            {

                char next1 = ReadCharFromConsole(EnemyX + 5, EnemyY);
                char next2 = ReadCharFromConsole(EnemyX + 5, EnemyY + 1);
                char next3 = ReadCharFromConsole(EnemyX + 5, EnemyY + 2);
                char next4 = ReadCharFromConsole(EnemyX + 5, EnemyY + 3);
                char next5 = ReadCharFromConsole(EnemyX + 5, EnemyY + 4);
                if (next1 == ' ' && next2 == ' ' && next3 == ' ' && next4 == ' ' && next5 == ' ')
                {
                    Console.SetCursorPosition(EnemyX, EnemyY);
                    erasEnemy1(EnemyX, EnemyY);
                    EnemyX = EnemyX + 1;
                    Console.SetCursorPosition(EnemyX, EnemyY);
                    printEnemy1(EnemyX, EnemyY, enemy1);
                }
                else
                {
                    Console.SetCursorPosition(EnemyX, EnemyY);
                    erasEnemy1(EnemyX, EnemyY);
                    enemyDirection1 = "Left";
                }
            }
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
    }
}

