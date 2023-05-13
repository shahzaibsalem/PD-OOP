using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using My_game.UI;
using My_game.DL;
using System.IO;
using EZInput;
using My_game;

namespace My_game.BL
{

    public class Functions
    {


        public static void Print_Ship(ref int x, ref int y, ref char[,] shape)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(x, y + i);
                for (int j = 0; j < 5; j++)
                {

                    Console.Write(shape[i, j]);
                }
            }
            /*Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(x,y);
             Console.WriteLine("S");*/
        }
        public static void Move_Right(ref int shipX, ref int shipY, ref char[,] shape)
        {
            string next1 = Map.map[shipY, shipX + 5];
            string next2 = Map.map[shipY + 1, shipX + 5];
            string next3 = Map.map[shipY + 2, shipX + 5];
            string next4 = Map.map[shipY + 3, shipX + 5];
            string next5 = Map.map[shipY + 4, shipX + 5];
            if (next1 == " " && next2 == " " && next3 == " " && next4 == " " && next5 == " ")
            {
                Console.SetCursorPosition(shipX, shipY);
                Erase_Ship(ref shipX, ref shipY);
                shipX++;
                Console.SetCursorPosition(shipX, shipY);
                Print_Ship(ref shipX, ref shipY, ref shape);
            }
        }

        public static void Move_Left(ref int shipX, ref int shipY, ref char[,] shape)
        {
            string next1 = Map.map[shipY, shipX - 5];
            string next2 = Map.map[shipY + 1, shipX - 5];
            string next3 = Map.map[shipY + 2, shipX - 5];
            string next4 = Map.map[shipY + 3, shipX - 5];
            string next5 = Map.map[shipY + 4, shipX - 5];
            if (next1 == " " && next2 == " " && next3 == " " && next4 == " " && next5 == " ")
            {
                Console.SetCursorPosition(shipX, shipY);
                Erase_Ship(ref shipX, ref shipY);
                shipX--;
                Console.SetCursorPosition(shipX, shipY);
                Print_Ship(ref shipX, ref shipY, ref shape);
            }
        }

        public static void Move_Up(ref int shipX, ref int shipY, ref char[,] shape)
        {
            string next1 = Map.map[shipY - 1, shipX];
            string next2 = Map.map[shipY - 1, shipX + 1];
            string next3 = Map.map[shipY - 1, shipX + 2];
            string next4 = Map.map[shipY - 1, shipX + 3];
            string next5 = Map.map[shipY - 1, shipX + 4];
            if (next1 == " " && next2 == " " && next3 == " " && next4 == " " && next5 == " ")
            {
                Console.SetCursorPosition(shipX, shipY);
                Erase_Ship(ref shipX, ref shipY);
                shipY--;
                Console.SetCursorPosition(shipX, shipY);
                Print_Ship(ref shipX, ref shipY, ref shape);
            }
        }

        public static void Move_Down(ref int shipX, ref int shipY, ref char[,] shape)
        {
            string next1 = Map.map[shipY + 5, shipX];
            string next2 = Map.map[shipY + 5, shipX + 1];
            string next3 = Map.map[shipY + 5, shipX + 2];
            string next4 = Map.map[shipY + 5, shipX + 3];
            string next5 = Map.map[shipY + 5, shipX + 4];
            if (next1 == " " && next2 == " " && next3 == " " && next4 == " " && next5 == " ")
            {
                Console.SetCursorPosition(shipX, shipY);
                Erase_Ship(ref shipX, ref shipY);
                shipY++;
                Console.SetCursorPosition(shipX, shipY);
                Print_Ship(ref shipX, ref shipY, ref shape);
            }
        }

        public static void Erase_Ship(ref int x, ref int y)
        {
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(x, y + i);
                for (int j = 0; j < 5; j++)
                {

                    Console.Write(" ");
                }
            }
            // Console.SetCursorPosition(x, y);
            //Console.WriteLine(" ");
        }

        public static void Print_Enemy(ref int x, ref int y, ref char[,] Enemy)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(x, y + i);
                for (int j = 0; j < 5; j++)
                {

                    Console.Write(Enemy[i, j]);
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Erase_Enemy(ref int x, ref int y)
        {

            Console.SetCursorPosition(x, y);
            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(x, y + i);
                for (int j = 0; j < 5; j++)
                {

                    Console.Write(" ");
                }
            }
        }

        public static void Move_Enemy(ref string dir, ref int x, ref int y, ref char[,] Enemy)
        {
            if (dir == "Left")
            {
                string next1 = Map.map[ y, x - 1];
                string next2 = Map.map[ y + 1, x - 1];
                string next3 = Map.map[ y + 2, x - 1];
                string next4 = Map.map[y + 3, x - 1];
                string next5 = Map.map[ y + 4, x - 1];
                if (next1 == " " && next2 == " " && next3 == " " && next4 == " " && next5 == " ")
                {
                    Console.SetCursorPosition(x, y);
                    Erase_Enemy(ref x, ref y);
                    x = x - 1;
                    Console.SetCursorPosition(x, y);
                    Print_Enemy(ref x, ref y, ref Enemy);
                }
                else
                {
                    dir = "Right";
                }
            }
            if (dir == "Right")
            {

                string next1 = Map.map[y, x + 5];
                string next2 = Map.map[y + 1, x + 5];
                string next3 = Map.map[y + 2, x + 5];
                string next4 = Map.map[y + 3, x + 5];
                string next5 = Map.map[y + 4, x + 5];
                if (next1 == " " && next2 == " " && next3 == " " && next4 == " " && next5 == " ")
                {
                    Console.SetCursorPosition(x, y);
                    Erase_Enemy(ref x, ref y);
                    x = x + 1;
                    Console.SetCursorPosition(x, y);
                    Print_Enemy(ref x, ref y, ref Enemy);

                }
                else
                {
                    dir = "Left";
                }

            }


        }

        public static void Print_Bullet(ref int x, ref int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("^");
        }

        static void Erase_Bullet(ref int x, ref int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(" ");
        }

        public static void Move_Bullet(ref bool[] isBulletActive, ref int[] bulletX, ref int[] bulletY, ref int bulletCount, ref int health, ref int Enemyx, ref int Enemyy)
        {

            for (int x = 0; x < bulletCount; x++)
            {
                if (isBulletActive[x] == true)
                {
                    string next1 = Map.map[bulletY[x] - 1, bulletX[x]];
                    if (next1 == " ")
                    {
                        Erase_Bullet(ref bulletX[x], ref bulletY[x]);
                        bulletY[x] = bulletY[x] - 1;
                        Print_Bullet(ref bulletX[x], ref bulletY[x]);
                    }
                    else if (next1 != " ")
                    {
                        Erase_Bullet(ref bulletX[x], ref bulletY[x]);
                        MakeBullet_InActive(x, isBulletActive);

                    }

                    if (bulletX[x] == Enemyx && bulletY[x] - 1 == Enemyy)
                    {
                        health = health - 10;
                    }
                }
            }
        }
        public static void MakeBullet_InActive(int index, bool[] isBulletActive)
        {
            isBulletActive[index] = false;
        }

        public static void Generate_Bullet(ref int x, ref int y, ref bool[] isBulletActive, ref int bulletCount, ref int[] bulletX, ref int[] bulletY)
        {
            bulletX[bulletCount] = x + 3;
            bulletY[bulletCount] = y - 1;
            isBulletActive[bulletCount] = true;
            Console.SetCursorPosition(x + 3, y - 1);
            Console.WriteLine("^");
            bulletCount++;

        }

        public static void Print_Credentials(ref int health)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 28);
            Console.WriteLine(health + " ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Collision_Detection(ref int x, ref int y, ref bool[] isBulletActive, ref int bulletCount, ref int[] bulletX, ref int[] bulletY, ref int health, ref int score)
        {
            for (int i = 0; i < bulletCount; i++)
            {
                if (y + 5 == bulletY[x] && (x == bulletX[x] || x + 1 == bulletX[x] || x + 2 == bulletX[x] || x + 3 == bulletX[x] || x + 4 == bulletX[x]))
                {
                    if (health > 0)
                    {
                        score = score + 2;
                        health = health - 5;
                    }
                }
            }
        }
        public static void Print_Enemy2(ref int x, ref int y, ref char[,] Enemy1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(x, y + i);
                for (int j = 0; j < 5; j++)
                {

                    Console.Write(Enemy1[i, j]);
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Erase_Enemy2(ref int x, ref int y)
        {

            Console.SetCursorPosition(x, y);
            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(x, y + i);
                for (int j = 0; j < 5; j++)
                {

                    Console.Write(" ");
                }
            }
        }

        public static void Collision_Detection2(ref int x, ref int y, ref bool[] isBulletActive, ref int bulletCount, ref int[] bulletX, ref int[] bulletY, ref int health, ref int score)
        {
            for (int i = 0; i < bulletCount; i++)
            {
                if (y + 5 == bulletY[x] && (x == bulletX[x] || x + 1 == bulletX[x] || x + 2 == bulletX[x] || x + 3 == bulletX[x] || x + 4 == bulletX[x]))
                {
                    if (health > 0)
                    {
                        score = score + 2;
                        health = health - 5;
                    }
                }
            }
        }

        public static void Move_Enemy2(ref string dir, ref int x, ref int y, ref char[,] Enemy)
        {
            if (dir == "Left")
            {
                string next1 = Map.map[y, x - 1];
                string next2 = Map.map[y + 1, x - 1];
                string next3 = Map.map[y + 2, x - 1];
                string next4 = Map.map[y + 3, x - 1];
                string next5 = Map.map[y + 4, x - 1];
                if (next1 == " " && next2 == " " && next3 == " " && next4 == " " && next5 == " ")
                {
                    Console.SetCursorPosition(x, y);
                    Erase_Enemy2(ref x, ref y);
                    x = x - 1;
                    Console.SetCursorPosition(x, y);
                    Print_Enemy2(ref x, ref y, ref Enemy);
                }
                else
                {
                    dir = "Right";
                }
            }
            if (dir == "Right")
            {

                string next1 = Map.map[y, x + 5];
                string next2 = Map.map[y + 1, x + 5];
                string next3 = Map.map[y + 2, x + 5];
                string next4 = Map.map[y + 3, x + 5];
                string next5 = Map.map[y + 4, x + 5];
                if (next1 == " " && next2 == " " && next3 == " " && next4 == " " && next5 == " ")
                {
                    Console.SetCursorPosition(x, y);
                    Erase_Enemy2(ref x, ref y);
                    x = x + 1;
                    Console.SetCursorPosition(x, y);
                    Print_Enemy2(ref x, ref y, ref Enemy);

                }
                else
                {
                    dir = "Left";
                }

            }


        }

        public static void Genrate_Enemy_Bullet1(ref int x,ref int y,ref int[] Enemy1bulletX, ref int[] Enemy1bulletY, ref bool[] isEnemy1BulletActive, ref int Enemy1BulletCount)
        {
           

            Enemy1bulletX[Enemy1BulletCount] = x + 2;
            Enemy1bulletY[Enemy1BulletCount] =y + 5;
            isEnemy1BulletActive[Enemy1BulletCount] = true;
            Enemy1BulletCount++;
            Console.SetCursorPosition(x + 2, y + 5);
            Console.Write("|");
            
        }

        public static void Genrate_Enemy_Bullet2(ref int x, ref int y, ref int[] Enemy2bulletX, ref int[] Enemy2bulletY, ref bool[] isEnemy2BulletActive, ref int Enemy2BulletCount)
        {


            Enemy2bulletX[Enemy2BulletCount] = x + 2;
            Enemy2bulletY[Enemy2BulletCount] = y + 5;
            isEnemy2BulletActive[Enemy2BulletCount] = true;
            Enemy2BulletCount++;
            Console.SetCursorPosition(x + 2, y + 5);
            Console.Write("|");

        }

        public static void Move_Bullet_Of_Enemy1(ref int x, ref int y, ref int[] Enemy1bulletX, ref int[] Enemy1bulletY, ref bool[] isEnemy1BulletActive, ref int Enemy1BulletCount)
        {
            for (int i = 0; i < Enemy1BulletCount; i++)
            {
                if (isEnemy1BulletActive[x] == true)
                {
                    string next = Map.map[Enemy1bulletY[x] + 1, Enemy1bulletX[x]];
                    if (next != " ")
                    {
                        Erase_Bullet1(ref Enemy1bulletX[x], ref Enemy1bulletY[x]);
                        isEnemy1BulletActive[x] = false;
                    }
                    else if (next == " ")
                    {
                        Erase_Bullet1(ref Enemy1bulletX[x], ref Enemy1bulletY[x]);
                        Enemy1bulletY[x] = Enemy1bulletY[x] + 1;
                        Print_Bullet1(ref Enemy1bulletX[x], ref Enemy1bulletY[x]);
                    }
                }
            }

        }

        public static void Move_Bullet_Of_Enemy2(ref int x, ref int y, ref int[] Enemy2bulletX, ref int[] Enemy2bulletY, ref bool[] isEnemy2BulletActive, ref int Enemy2BulletCount)
        {
            for (int i = 0; i < Enemy2BulletCount; i++)
            {
                if (isEnemy2BulletActive[x] == true)
                {
                    string next = Map.map[Enemy2bulletY[x] + 1, Enemy2bulletX[x]];
                    if (next != " ")
                    {
                        Erase_Bullet2(ref Enemy2bulletX[x], ref Enemy2bulletY[x]);
                        isEnemy2BulletActive[x] = false;
                    }
                    else if (next == " ")
                    {
                        Erase_Bullet2(ref Enemy2bulletX[x], ref Enemy2bulletY[x]);
                        Enemy2bulletY[x] = Enemy2bulletY[x] + 1;
                        Print_Bullet2(ref Enemy2bulletX[x], ref Enemy2bulletY[x]);
                    }
                }
            }

        }

        public static void Erase_Bullet1(ref int x, ref int y)
        {
            Console.SetCursorPosition(x , y );
            Console.Write(" ");
        }
        public static void Print_Bullet1(ref int x, ref int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("|");
        }

        public static void Erase_Bullet2(ref int x, ref int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
        public static void Print_Bullet2(ref int x, ref int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("|");
        }

    }
}
