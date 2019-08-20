using System;
using System.Collections.Generic;
using System.Text;

namespace togos
{
    public static class CustomConsole
    {
        public enum MessageQuality { WARNING, ERROR, SUCESS }

        public static void WarningLog(string data)
        {
            SendLogType(data, MessageQuality.WARNING);
        }

        public static void ErrorLog(string data)
        {
            SendLogType(data, MessageQuality.ERROR);
        }

        public static void SuccessLog(string data)
        {
            SendLogType(data, MessageQuality.SUCESS);
        }

        public static void SendLogType(string message, MessageQuality qualityMessage)
        {
            Console.Write(DateTime.Now.Hour + ":" + DateTime.Now.Minute + " ");
            switch (qualityMessage)
            {
                case MessageQuality.ERROR:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[ERROR] ");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case MessageQuality.SUCESS:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[SUCESS] ");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case MessageQuality.WARNING:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("[WARNING] ");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            Console.Write(message);
        }
    }
}
