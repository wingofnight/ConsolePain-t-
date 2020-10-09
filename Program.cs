using System;
using PaintAndPain2077;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace zetetest
{
    public class SectorPaint: Paint
    {
       public bool ex = true;
        public void Point(int x, int y,int z)
        {
            Console.SetCursorPosition(x, y);
            Black(z);
        }
        public int thickness(int Lenght, double Start)
        {
            int x = 1;
            int StartLenght = Convert.ToInt32(Start);
            int lastLenght = 0;
            if (Lenght == 0)
            {
                if (StartLenght - lastLenght > 1)
                {
                    x = StartLenght - lastLenght;
                }
                lastLenght = StartLenght;
            }
            else
            {
                x = Lenght;
            }
            return x;
        }
        public void PrintLine(double StartLenght, double StartHeight, double FinishLenght, double FinishHeight, int LineLenght)
        {  
            int lasLenght;
            double coefficient;
            int x = 1;
            //сверху вниз слева направо.
            if (StartLenght < FinishLenght && StartHeight < FinishHeight)
            {               
                lasLenght = Convert.ToInt32(StartLenght);
                coefficient = (FinishLenght - StartLenght) / (FinishHeight - StartHeight); 
                for (double i = StartHeight; i <= FinishHeight; i++)
                {
                    Console.SetCursorPosition(Convert.ToInt32(StartLenght), Convert.ToInt32(i));
                    if (LineLenght == 0)
                    {
                        if (Convert.ToInt32(StartLenght) - lasLenght > 1)
                        {
                            x = Convert.ToInt32(StartLenght) - lasLenght;
                        }
                        lasLenght = Convert.ToInt32(StartLenght);
                    }
                    else { x = LineLenght; }

                    Gray(x);
                    x = 1;
                    StartLenght += coefficient;
                }
            }
            //снизу вверх слева направо
            else if (StartLenght < FinishLenght && StartHeight > FinishHeight)
            {
                if (LineLenght > 0)
                {
                    x = LineLenght;
                }
                coefficient = (FinishLenght - StartLenght) / (StartHeight- FinishHeight);
                for (double i = StartHeight; i >= FinishHeight; i--)
                {
                    Console.SetCursorPosition(Convert.ToInt32(StartLenght), Convert.ToInt32(i));
                    Gray(x);
                    StartLenght += coefficient;
                }
            }
            //сверху вниз справа налево 
            else if (StartLenght > FinishLenght && StartHeight < FinishHeight)
            {
                if (LineLenght > 0)
                {
                    x = LineLenght;
                }
                coefficient = (FinishHeight - StartHeight) / (StartLenght - FinishLenght);//возможно тут ошибка, так как должна быть обратная формула.
                for (double i = StartHeight; i <= FinishHeight; i++)
                {
                    Console.SetCursorPosition(Convert.ToInt32(StartLenght), Convert.ToInt32(i));
                    Gray(x);
                    StartLenght -= coefficient;
                }
            }
            //снизу вверх справа налево 
            else if (StartLenght > FinishLenght && StartHeight > FinishHeight)
            {
                if (LineLenght > 0)
                {
                    x = LineLenght;
                }
                coefficient = (FinishLenght - StartLenght) / (FinishHeight - StartHeight);
                for (double i = StartHeight; i >= FinishHeight; i--)
                {
                    Console.SetCursorPosition(Convert.ToInt32(StartLenght), Convert.ToInt32(i));
                    DarckBlue(x); 
                    StartLenght -= coefficient;
                }
            }
            //линия Слева Направо
            else if (StartHeight == FinishHeight)
            {//if(длина больше длины) то тогда то то , если нет то то то  лучше делать циклы в цикле.
                if (LineLenght > 0)
                {
                    x = LineLenght;
                }
                if (StartLenght<=FinishLenght) {
                for (double i = StartLenght; i < FinishLenght; i++)
                {
                    Console.SetCursorPosition(Convert.ToInt32(i), Convert.ToInt32(StartHeight));
                    DarckRed(x);                    
                }
                }
                else if(StartHeight<FinishHeight){
                    for (double i = StartLenght; i > FinishLenght; i--)
                    {
                        Console.SetCursorPosition(Convert.ToInt32(i), Convert.ToInt32(StartHeight));
                        DarckRed(x);
                    }
                }
            }
            //линия сверху вниз
            else if (StartLenght == FinishLenght)
            {
               
               
                for (double i = StartHeight; i <= FinishHeight; i++)
                {
                    Console.SetCursorPosition(Convert.ToInt32(StartLenght), Convert.ToInt32(i));
                     DarckRed(thickness(LineLenght, StartLenght)); 
                }
            }
        }

    class Program
        {

            static void Main(string[] args)
            {
                
                var line = new SectorPaint();
                line.PrintLine(0, 0, 0,21, 0);
                /* line.PrintLine(0, 0, 21, 0, 1);
                 line.Point(4, 0, 2);
                 line.Point(9, 0, 2);
                 line.Point(14, 0, 2);
                 line.Point(20, 0, 2);
                 line.PrintLine(0, 0, 0, 5, 1);
                 line.PrintLine(0, 5, 3, 5, 1);
                 line.PrintLine(5, 0, 5, 5, 1);
                 line.PrintLine(8, 0, 8, 5, 1);
                 line.PrintLine(10, 0, 10, 5, 1);
                 line.PrintLine(13, 0, 13, 5, 1);
                 line.PrintLine(17, 0, 17, 5, 1);
                 line.PrintLine(21, 0, 21, 5, 1);
                 line.PrintLine(10, 2, 13, 2, 1);
                 line.PrintLine(21, 3, 21, 5, 3);
                 line.Point(22, 4,1);

                 line.PrintLine(26, 0, 26, 5, 1);
                 line.PrintLine(26, 5, 29, 0, 1);
                 line.PrintLine(29, 0, 29, 5, 1);
                 Console.SetCursorPosition(31, 5);
                 DarckRed();
                 line.PrintLine(32, 0, 32, 5, 1);
                 line.PrintLine(32, 0, 34, 0, 1);
                 line.PrintLine(34, 0, 34, 15, 1);
                 line.PrintLine(26, 0, 26, 5, 1);

                 line.PrintLine(36, 0, 36, 5, 1);
                 line.PrintLine(36, 5, 39, 0, 1);
                 line.PrintLine(39, 0, 39, 5, 1);

                 line.PrintLine(42, 0, 42, 5, 1);
                 line.PrintLine(44, 0, 44, 5, 1);
                 line.PrintLine(42, 3, 44, 3, 1);

                 line.PrintLine(46, 0, 46, 5, 1);
                 line.PrintLine(46, 5, 50, 5, 1);
                 line.PrintLine(46, 3, 48, 3, 1);
                 line.PrintLine(46, 0, 49, 0, 1);

                 line.PrintLine(51, 0, 72, 0, 1);
                 line.Point(55, 0, 2);
                 line.Point(60, 0, 2);
                 line.Point(65, 0, 2);
                 line.Point(71, 0, 2);
                 line.PrintLine(51, 0, 51, 5, 1);
                 line.PrintLine(51, 5, 54, 5, 1);
                 line.PrintLine(56, 0, 56, 5, 1);
                 line.PrintLine(59, 0, 59, 5, 1);
                 line.PrintLine(61, 0, 61, 5, 1);
                 line.PrintLine(64, 0, 64, 5, 1);
                 line.PrintLine(68, 0, 68, 5, 1);
                 line.PrintLine(72, 0, 72, 5, 1);
                 line.PrintLine(61, 2, 64, 2, 1);
                 line.PrintLine(72, 3, 72, 5, 3);
                 line.Point(73, 4, 1);

                 line.PrintLine(0, 12, 75, 12, 1);

                 line.PrintLine(90, 3, 120, 3, 1);
                 line.PrintLine(90, 4, 120, 4, 1);
                 line.PrintLine(90, 5, 120, 5, 1);//поработать с толщиной линии
                 line.PrintLine(90, 3, 90,40, 6);

                 line.PrintLine(130, 3, 150, 23, 6);
                 //line.PrintLine(150, 3, 150, 35, 6);
                 line.PrintLine(150, 35, 145, 40, 6);
                 line.PrintLine(160, 3, 60, 40, 6);

                 line.PrintLine(170, 3, 200, 3, 1);
                 line.PrintLine(170, 4, 200, 4, 1);
                 line.PrintLine(170, 5, 200, 5, 1);//поработать с толщиной линии
                 line.PrintLine(170, 3, 170, 40, 6);
                 line.PrintLine(170, 38, 200, 38, 1);
                 line.PrintLine(170, 39, 200, 39, 1);
                 line.PrintLine(170, 40, 200, 40, 1);//п



                 line.PrintLine(210, 3, 210, 40, 6);
                 for (int i = 40; i >= 25; i--)
                 {
                     line.PrintLine(210, i, 240, i, 1);
                 }
                 line.ex = false;
                 line.PrintLine(216, 31, 216, 36, 18);
                */
                Console.ReadLine();
                //Parallel.Invoke(first,last);
                //first();
                //first();
                void first()
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Console.Beep(40, 1000);
                        Console.Beep(17767, 50);
                        Console.Beep(50, 500);
                        Console.Beep(40, 500);
                        //Console.Beep(27767, 50);
                        Console.Beep(60, 300);
                        Console.Beep(70, 70);
                        Thread.Sleep(200);
                    }
                }




                ConsoleKeyInfo getch;
                while (true)
                {
                    getch = Console.ReadKey(true);
                    switch (getch.Key)
                    {
                        case ConsoleKey.LeftArrow:

                            break;
                        case ConsoleKey.UpArrow:

                            break;
                        case ConsoleKey.RightArrow:

                            break;
                        case ConsoleKey.DownArrow:
                            break;
                        default:
                            break;
                    }

                    Black(40);
                }
            } }
    }
}
