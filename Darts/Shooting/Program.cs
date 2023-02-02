//Задание 4.
//Создать игру «Попади в мишень» со следующими
//правилами:
//• Заданы размеры окна появления мишени.
//• Приложение генерирует мишень простой формы
//(прямоугольник или круг).
//• Игрок производит выстрел (вводит координаты X, Y).
//• Если выстрел удачный – игроку начисляется один балл,
//иначе – балл отнимается.
//• Для каждого выстрела координаты мишени меняются.
//• Если игрок из заданного количества возможных
//выстрелов N не попал K раз – он проиграл, иначе – выиграл.
//Реализовать генерацию и обработку событий «Произвести
//выстрел», «Выстрел произведен», «Игра закончена». 
using System;
using static System.Console;
using System.Collections;
using System.Collections.Generic;

namespace Event_
{
        public delegate void Handler(int a, int b);

    class ShootFil
    {
        
        int Shoots;
        public void ChTW()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.White;
        }
        public void ChTR()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.DarkRed;
        }
        public void ChTB()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void W(int count)
        {
            ChTW();
            for (int i = 0; i < count; i++)
            {
                Console.Write(" ");
            }
        }
        public void R(int count)
        {
            ChTR();
            for (int i = 0; i < count; i++)
            {
                Console.Write(" ");
            }
        }
        public void ShowFil(int a, int b)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.BackgroundColor = ConsoleColor.DarkGray;

            Console.SetCursorPosition(b, a); ChTB(); Console.Write(""); W(14); Console.WriteLine();
            Console.SetCursorPosition(b, a + 1); ChTB(); Console.Write(""); W(2); R(10); W(2); Console.WriteLine();
            Console.SetCursorPosition(b, a + 2); ChTB(); Console.Write(""); W(2); R(2); W(6); R(2); W(2); Console.WriteLine();
            Console.SetCursorPosition(b, a + 3); ChTB(); Console.Write(""); W(2); R(2); W(2); R(2); W(2); R(2); W(2); Console.WriteLine();
            Console.SetCursorPosition(b, a + 4); ChTB(); Console.Write(""); W(2); R(2); W(6); R(2); W(2); Console.WriteLine();
            Console.SetCursorPosition(b, a + 5); ChTB(); Console.Write(""); W(2); R(10); W(2); Console.WriteLine();
            Console.SetCursorPosition(b, a + 6); ChTB(); Console.Write(""); W(14); Console.WriteLine();



            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

        }




    }



    class Program
    {
        public static void Boom(int a, int b)
        {
            WMPLib.WindowsMediaPlayer axMusicPlayer = new WMPLib.WindowsMediaPlayer();
            string path = Path.GetFullPath("no.mp3");
            axMusicPlayer.URL = path;
            axMusicPlayer.settings.setMode("loop", false);
            axMusicPlayer.controls.play();
            Thread.Sleep(1000);
            Console.SetCursorPosition(a, b); Console.WriteLine("X");
        }
       
        public static void BoomSound(int a, int b)
        {
            
            WMPLib.WindowsMediaPlayer axMusicPlayer = new WMPLib.WindowsMediaPlayer();
            string path = Path.GetFullPath("yes.mp3");
            axMusicPlayer.URL = path;
            axMusicPlayer.settings.setMode("loop", false);
            axMusicPlayer.controls.play();
        }

        public static void Lifes(int a)
        {
            int totalCount = 10;
            Console.SetCursorPosition(45, 1);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("HP: ");
            for (int i = 1; i < totalCount; i++)
            {
                
                if (a > i)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write("  ");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("");
                }
                if (a <= i)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.Write("  ");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("");
                }

            }

            
        }

        static void Main(string[] args)
        {
            ShootFil File1 = new ShootFil();
           
            Handler Bo = new(Boom);
            int yes = 0;
            int no = 0;
            int lfs = 11;
            while (true)
            {
                while (yes + no != 10)
                {
                    Console.Clear();
                    Lifes(lfs);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(10, 27); Console.WriteLine("                                   Попадания: " + yes + " Промахм: " + no);
                    int x = new Random().Next(4, 21);
                    int y = new Random().Next(4, 100);
                    File1.ShowFil(x, y);
                    int x2 = new Random().Next(x - 3, x + 10);
                    int y2 = new Random().Next(y - 3, y + 15);
                    if (x2 >= x && x2 <= x + 6 && y2 >= y && y2 <= y + 13)
                    {

                        Bo += BoomSound;
                        yes++;
                        lfs -= 2;
                    }
                    else
                    {
                        no++;
                    }
                    Console.ReadKey();

                    Bo(y2, x2);
                   
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(10, 27); Console.WriteLine("                                   Попадания: " + yes + " Промахм: " + no);
                    Thread.Sleep(1000);
                    Bo -= BoomSound;
                    Lifes(lfs);
                    if (lfs <= 0)
                    {
                        break;
                    }


                }
                Console.Clear();
                if (lfs <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("                                                       ВЫ ПОБЕДИЛИ!");
                }
                if (lfs > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("                                                       ВЫ ПРОИГРАЛИ");
                }
                
                Console.ReadKey();
                yes = 0;
                no = 0;
                lfs = 10;

            }
           
           
        }
    }
    
}