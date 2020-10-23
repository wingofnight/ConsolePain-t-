using System;

using Painter;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {
            var painter = new Painter.Painter();
            painter.Point(10,10, new ColorProfile(ConsoleColor.White,ConsoleColor.Black));
            Console.ReadKey();
        }
    }
}
