using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.System.Graphics;
using System.Drawing;

namespace togos.Graphics
{
    public static class Taskbar
    {
        public enum TaskbarDirection
        {
            UP,DOWN,LEFT,RIGHT
        }
        public static TaskbarDirection directionTaskbar;

        public static void RenderTaskbar(Mode mode)
        {
            /* A filled rectange */ //As the taskbar
            Console.WriteLine("Rendering Taskbar");
            API.DisplayDriver.DrawFilledRectangle(Color.Green, 0, mode.Rows - 30, mode.Columns, 30);
            API.DisplayDriver.DrawFilledRectangle(Color.LightGreen, mode.Columns - 65, mode.Rows - 25, 60, 20);
        }
    }
}
