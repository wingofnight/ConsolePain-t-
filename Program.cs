using System;
using PaintAndPain2077;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace zetetest
{
    public class SectorPaint : Paint
    {
        int lastLenght = 0;
        public bool ex = true;
        public void Point(int x, int y, int z)
        {
            Console.SetCursorPosition(x, y);
            Black(z);
        }

        public void PrintLine(double StartLenght, double StartHeight, double FinishLenght, double FinishHeight, int LineLenght)
        {
            lastLenght = Convert.ToInt32(StartLenght);
            double coefficient;

            int thickness()
            {
                int x = 1;
                int Start = Convert.ToInt32(StartLenght);

                if (LineLenght == 0)
                {
                    if (StartLenght - lastLenght > 1)
                    {
                        x = Start - lastLenght;
                    }
                    lastLenght = Start;
                }
                else
                {
                    x = LineLenght;
                }
                return x;
            }
            void Stamp(double Lenght, double Height)
            {
                Console.SetCursorPosition(Convert.ToInt32(Lenght), Convert.ToInt32(Height));
                DarckRed(thickness());
            }
            //линия сбоку вбок (при одинаковой высоте)
            if (StartHeight == FinishHeight && StartLenght < FinishLenght)
            {
                for (double i = StartLenght; i <= FinishLenght; i++) { Stamp(i, StartHeight); }
            }
            else if (StartHeight == FinishHeight && StartLenght > FinishLenght)
            {
                for (double i = FinishLenght; i >= StartLenght; i--) { Stamp(i, StartHeight); }
            }
            //линия сверху вниз и снизу вверх (при одинаковой длинне)
            else if (StartLenght == FinishLenght && StartHeight < FinishHeight)
            {
                for (double i = StartHeight; i <= FinishHeight; i++) { Stamp(StartLenght, i); }
            }
            else if (StartLenght == FinishLenght && StartHeight > FinishHeight)
            {
                for (double i = FinishHeight; i >= StartHeight; i--) { Stamp(StartLenght, i); }
            }
            else if (StartLenght < FinishLenght && StartHeight < FinishHeight)
            { //сверху вниз слева направо.
                coefficient = (FinishLenght - StartLenght) / (FinishHeight - StartHeight);
                for (double i = StartHeight; i <= FinishHeight; i++)
                {
                    Stamp(StartLenght, i);
                    StartLenght += coefficient;
                }
            }
            else if (StartLenght < FinishLenght && StartHeight > FinishHeight)
            {//снизу вверх слева направо 
                coefficient = (FinishLenght - StartLenght) / (StartHeight - FinishHeight);
                for (double i = StartHeight; i >= FinishHeight; i--)
                {
                    Stamp(StartLenght, i);
                    StartLenght += coefficient;
                }
            }
            else if (StartLenght > FinishLenght && StartHeight < FinishHeight)
            {//сверху вниз справа налево 
                coefficient = (FinishHeight - StartHeight) / (StartLenght - FinishLenght);
                for (double i = StartHeight; i <= FinishHeight; i++)
                {
                    Stamp(StartLenght, i);
                    StartLenght -= coefficient;
                }
            }
            else if (StartLenght > FinishLenght && StartHeight > FinishHeight)
            {//снизу вверх справа налево 
                coefficient = (FinishLenght - StartLenght) / (FinishHeight - StartHeight);
                for (double i = StartHeight; i >= FinishHeight; i--)
                {
                    Stamp(StartLenght, i);
                    StartLenght -= coefficient;
                }
            }
        }

    }
    
    

    class Program
        {

            static void Main(string[] args)
            {

                var line = new SectorPaint();

            line.PrintLine(0, 0, 80, 50, 5);
            line.PrintLine(80, 50, 120, 50, 5);
            line.PrintLine(80, 51, 92, 51, 5);
            line.PrintLine(110, 51, 120, 51, 5);
            line.PrintLine(80, 52, 85, 52, 5);
            line.PrintLine(115, 52, 120, 52, 5);
            line.PrintLine(120, 50, 200, 0, 5);
            line.PrintLine(80, 50, 80, 70, 5);
            line.PrintLine(200, 0, 200, 70, 5);
            line.PrintLine(78, 50, 78, 150, 5);
            line.PrintLine(205, 0, 205, 150, 5);
            line.PrintLine(120, 50, 120, 70, 5);
            line.PrintLine(122, 50, 122, 150, 5);
            line.PrintLine(115, 49, 120, 49, 5);
            line.PrintLine(80, 49, 85, 49, 5);
            line.PrintLine(118, 48, 125, 48, 1);
            line.PrintLine(80, 48, 82, 48, 5);
            line.PrintLine(122, 47, 125, 47, 1);
            line.PrintLine(80, 47, 82, 47, 1);
            line.PrintLine(40, 25, 160, 25, 1);
            line.PrintLine(52, 30, 155, 30, 1);
            line.PrintLine(114, 35, 148, 35, 1);
            line.PrintLine(128, 40, 140, 40, 1);
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
             line.Point(22, 4, 1);

             line.PrintLine(26, 0, 26, 5, 1);
             line.PrintLine(26, 5, 29, 0, 1);
             line.PrintLine(29, 0, 29, 5, 1);
             Console.SetCursorPosition(31, 5);
             //DarckRed();
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
             line.PrintLine(90, 3, 90, 40, 6);

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
            }
        } 
}
