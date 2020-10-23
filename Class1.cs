using System;
///<summary>
///эта программа позволяет рисовать любые линии разных цветов и толщины. 
///</summary>
 
namespace Paint
{///<summary>
///этот класс создаёт профили цветов, устанавливая задний фон и цвет символа. 
///</summary>
///<remarks>
///если поставить полупрозрачный символ, и выбрать фон и цвет символа разных цветов, то можно получить новый цвет путем смешивания. 
///</remarks>
    public class ColorProfile
    { ///<value> BackGround устанавливает цвет заднего фона, и принимает значение ConsoleColor.Color</value>
        public ConsoleColor BackGround { get; set; }
      ///<value> ForeGround устанавливает цвет символа и принимает значение ConsoleColor.Color</value>
        public ConsoleColor ForeGround { get; set; }
     
      ///<remarks>
      ///конструктор класса принимает значения ConsoleColor.Color и устанавливает ForeGround и BackGround</param>
      ///</remarks> 
      public ColorProfile(ConsoleColor ForeGRound, ConsoleColor BackGround)
        {
            this.ForeGround = ForeGRound;
            this.BackGround = BackGround;
        }
    }

    public class SectorPaint
    {
        public static ColorProfile Black = new ColorProfile(ConsoleColor.Black, ConsoleColor.Black);
        public static ColorProfile White = new ColorProfile(ConsoleColor.White, ConsoleColor.Black);
        public static ColorProfile DarkMagenta = new ColorProfile(ConsoleColor.DarkMagenta, ConsoleColor.Black);
        public static ColorProfile Magenta = new ColorProfile(ConsoleColor.Magenta, ConsoleColor.Black);
        public static ColorProfile DarkCyan = new ColorProfile(ConsoleColor.DarkCyan, ConsoleColor.Black);
        public static ColorProfile Cyan = new ColorProfile(ConsoleColor.Cyan, ConsoleColor.Black);
        public static ColorProfile DarkGray = new ColorProfile(ConsoleColor.DarkGray, ConsoleColor.Black);
        public static ColorProfile Gray = new ColorProfile(ConsoleColor.Gray, ConsoleColor.Black);
        public static ColorProfile DarkYellow = new ColorProfile(ConsoleColor.DarkYellow, ConsoleColor.Black);
        public static ColorProfile Yellow = new ColorProfile(ConsoleColor.Yellow, ConsoleColor.Black);
        public static ColorProfile DarkGreen = new ColorProfile(ConsoleColor.DarkGreen, ConsoleColor.Black);
        public static ColorProfile Green = new ColorProfile(ConsoleColor.Green, ConsoleColor.Black);
        public static ColorProfile DarkBlue = new ColorProfile(ConsoleColor.DarkBlue, ConsoleColor.Black);
        public static ColorProfile Blue = new ColorProfile(ConsoleColor.Blue, ConsoleColor.Black);
        public static ColorProfile DarkRed = new ColorProfile(ConsoleColor.DarkRed, ConsoleColor.Black);
        public static ColorProfile Red = new ColorProfile(ConsoleColor.Red, ConsoleColor.Black);

        public static int lastLenght = 0;
        public static string symbol = " ";

        public void Point(int x, int y, ColorProfile color)
        {
            Console.SetCursorPosition(x, y);
            
            try
            {
                Console.ForegroundColor = color.BackGround;
                Console.BackgroundColor = color.ForeGround;
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nНеправильно указан цвет!");
                throw;
            }
            Console.Write(symbol);
        }

        public static void PrintLine(double StartLenght, double StartHeight, double FinishLenght, double FinishHeight, int LineLenght, ColorProfile color)
        {
            try
            {
                Console.ForegroundColor = color.BackGround;
                Console.BackgroundColor = color.ForeGround;
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nНеправильно указан цвет!");
                throw;
            }

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
                for (int i = 0; i < thickness(); i++) Console.Write(symbol);
            }

            void LineStamp(double Lenght, double Height)
            {
                Console.SetCursorPosition(Convert.ToInt32(Lenght), Convert.ToInt32(Height));
                for (int i = 0; i < thickness(); i++)
                {
                    Console.Write(symbol);
                    Console.SetCursorPosition(Convert.ToInt32(Lenght), Convert.ToInt32(Height++));
                }
            }
            //линия сбоку вбок (при одинаковой высоте)
            if (StartHeight == FinishHeight && StartLenght < FinishLenght)
            {
                for (double i = StartLenght; i <= FinishLenght; i++) { LineStamp(i, StartHeight); }
            }
            else if (StartHeight == FinishHeight && StartLenght > FinishLenght)
            {
                for (double i = FinishLenght; i >= StartLenght; i--) { LineStamp(i, StartHeight); }
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
            Console.ResetColor();
        }

    }

}
