using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace togos
{
    public class ConsoleGraphics
    {
        public static void DrawRectangle(Point position, Point size)
        {
            for(int y = position.Y; y < size.Y; y++)
            {
                for(int x = position.X; x < size.X; x++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write("#");
                }
            }
        }

        public static void DrawRectangle(Point position, Point size, ConsoleColor colorText)
        {
            Console.ForegroundColor = colorText;
            DrawRectangle(position, size);
        }

        public static void DrawRectangle(int x, int y, int width, int height, ConsoleColor colorText)
        {
            Console.ForegroundColor = colorText;
            DrawRectangle(new Point(x, y), new Point(width, height));
        }

        public static void DrawRectangle(int x, int y, int width, int height)
        {
            DrawRectangle(new Point(x, y), new Point(width, height));
        }

        public static void ClearConsole()
        {
            Console.Clear();
        }
    }
}
