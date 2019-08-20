using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace togos
{
    public class WindowManager
    {
        static List<Window> windows = new List<Window>();

        static WindowManager()
        {

        }

        public void CreateWindow(string nameWindow, int x, int y, int width, int height, Canvas canvas)
        {
            Window newWindow = new Window(nameWindow, x, y, width, height, canvas);
            windows.Add(newWindow);
        }

        public void MoveWindow(Window selectedWindow, int x, int y, Canvas canvas)
        {
            selectedWindow.MovePosition(x, y, canvas);
        }

        public static void CloseWindow(Window selectedWindow, Canvas canvas)
        {
            selectedWindow.CloseWindow(canvas);
            windows.Remove(selectedWindow);
        }
    }
}
