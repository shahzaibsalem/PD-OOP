using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using My_game.DL;
using My_game.UI;
using My_game.BL;
using EZInput;
using System.IO;
using System.Threading;


namespace My_game
{
    class Program
    {
        static void Main(string[] args)
        {
            int E_health = 100;
            int E_health2 = 100;
            int P_Health = 100;
            int score = 0;

            int[] bulletX = new int[1000];
            int[] bulletY = new int[1000];
            bool[] isBulletActive = new bool[1000];
            int bulletCount = 0;


            int [] Enemy1bulletX=new int [1000];
            int[] Enemy1bulletY = new int[1000];
            int[] Enemy1bullet2X = new int[1000];
            int[] Enemy1bullet2Y = new int[1000];
            bool [] isEnemy1BulletActive=new bool[1000];
            bool [] isEnemy2BulletActive=new bool[1000];

            int Enemy1BulletCount = 0;
            int Enemy2BulletCount = 0;
            
            int shipx = 25;
            int shipy = 25;
            int Enemy_X = 10;
            int Enemy_Y = 5;

            int Enemy_2X = 12;
            int Enemy_2Y = 12;
            string Direction = "Left";
            string dir2 = "Right";

            int timer = 0;


            char[,] shape = new char[5,5] {
    {' ', ' ', 'o', ' ', ' '},
    {' ', ' ', '|', ' ', ' '},
    {' ', '-', '-', '-', ' '},
    {'|', '-', '-', '-', '|'},
    {'|', '|', ' ', '|', '|'}
            };

            char[,] Enemy = new char[5, 5]
                     {
   {'|', '|', ' ', '|', '|'},
    {'|', '-', '-', '-', '|'},
     {' ', '-', '-', '-', ' '},
     {' ', ' ', '|', ' ', ' '},
    {' ', ' ', 'o', ' ', ' '},
     };
            char[,] Enemy1 = new char[5, 5]
                    {
   {'|', '|', ' ', '|', '|'},
    {'|', '-', '-', '-', '|'},
     {' ', '-', '-', '-', ' '},
     {' ', ' ', '|', ' ', ' '},
    {' ', ' ', 'o', ' ', ' '},
    };

            Map.Print_Map();
            Functions.Print_Ship(ref shipx,ref shipy,ref shape);
            Functions.Print_Enemy(ref Enemy_X, ref Enemy_Y,ref Enemy);
           Functions. Print_Enemy2(ref Enemy_2X, ref  Enemy_2Y, ref Enemy1);
            do
            {

               Functions. Collision_Detection(ref Enemy_X, ref Enemy_Y, ref isBulletActive, ref bulletCount, ref bulletX, ref bulletY, ref E_health, ref score);
               Functions.Collision_Detection2(ref Enemy_2X, ref Enemy_2Y, ref isBulletActive, ref bulletCount, ref bulletX, ref bulletY, ref E_health2, ref score);
               Functions.Move_Bullet_Of_Enemy1(ref Enemy_X, ref Enemy_X, ref Enemy1bulletX, ref Enemy1bulletY, ref isEnemy1BulletActive, ref Enemy1BulletCount);
               Functions.Move_Bullet_Of_Enemy1(ref Enemy_2X, ref Enemy_2X, ref Enemy1bullet2X, ref Enemy1bullet2Y, ref isEnemy2BulletActive, ref Enemy2BulletCount);
               Functions.Print_Credentials(ref E_health);
               Functions.Move_Enemy(ref Direction, ref Enemy_X, ref Enemy_Y,ref Enemy);
               Functions. Move_Enemy2(ref  dir2, ref Enemy_2X, ref Enemy_2Y, ref Enemy1);
               Functions.Move_Bullet(ref isBulletActive, ref bulletX, ref bulletY, ref bulletCount,ref E_health,ref Enemy_X,ref Enemy_Y);
               if (timer % 15 == 0)
                {
                    Functions.Genrate_Enemy_Bullet1(ref Enemy_X, ref Enemy_Y, ref Enemy1bulletX, ref Enemy1bulletY, ref isEnemy1BulletActive, ref Enemy1BulletCount);
                    Functions.Genrate_Enemy_Bullet2(ref Enemy_2X, ref Enemy_2Y, ref Enemy1bullet2X, ref Enemy1bullet2Y, ref isEnemy2BulletActive, ref Enemy2BulletCount);
                }

                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    Functions.Move_Right(ref shipx, ref shipy,ref shape);
                }

                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    Functions.Move_Left(ref shipx, ref shipy,ref shape);
                }

                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    Functions.Move_Up(ref shipx, ref shipy,ref shape);
                }

                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    Functions.Move_Down(ref shipx, ref shipy,ref shape);
                }
                if (Keyboard.IsKeyPressed(Key.Space))
                {
                    Functions.Generate_Bullet(ref shipx,ref shipy,ref isBulletActive,ref bulletCount,ref bulletX,ref bulletY);
                }
                if(E_health==0)
                {
                    break;
                }
                    Thread.Sleep(50);

            } while (true);
           

        }
    }
}
