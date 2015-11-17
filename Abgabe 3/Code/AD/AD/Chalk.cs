using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AD
{
    public class Chalk
    {
        public static void Write(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        public static void Write(string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            Console.BackgroundColor = backgroundColor;
            Write(text, foregroundColor);
        }
    }
}
