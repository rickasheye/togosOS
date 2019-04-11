using System;
using System.Collections.Generic;
using System.Text;

namespace togos
{
    public static class CustomConsole
    {
        public static void WarningLog(string data)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[WARNING]" + data);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void ErrorLog(string data)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[ERROR]" + data);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void SuccessLog(string data)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[SUCESS]" + data);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
