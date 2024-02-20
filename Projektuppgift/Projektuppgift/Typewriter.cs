using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektuppgift
{
    internal class Typewriter
    {
        public static void TypewriterEffect(string message)
        {
            TypewriterEffect(message, true);
        }
        public static void TypewriterEffect(string message, bool newLine)
        {
            if (message.Length < Console.WindowWidth)
            {
                int offset = (Console.WindowWidth - message.Length) / 2;
                Console.Write(string.Concat(Enumerable.Repeat(" ", offset)));
            }
            foreach (Char c in message)
            {
                Console.Write(c);
                Thread.Sleep(10);
            }
            if (newLine == true)
            {
                Console.WriteLine();
            }
        }

        public static void TypewriterEffect(string message, bool newLine, int offset)
        {
            if (message.Length < Console.WindowWidth)
            {
                Console.Write(string.Concat(Enumerable.Repeat(" ", offset)));
            }
            foreach (Char c in message)
            {
                Console.Write(c);
                Thread.Sleep(10);
            }
            if (newLine == true)
            {
                Console.WriteLine();
            }
        }
    }
}
