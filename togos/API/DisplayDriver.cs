using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using CGS = Cosmos.System.Graphics;

namespace togos.API
{
    public class DisplayDriver
    {
        //Draw Unfilled rectangle
        public static void DrawRectangle(CGS.Pen color, CGS.Point position, int width, int height)
        {
            Kernel.aCanvas.DrawRectangle(color, position, width, height);
        }
        
        public static void DrawRectangle(Color color, CGS.Point position, int width, int height)
        {
            CGS.Pen pen = new CGS.Pen(color);
            Kernel.aCanvas.DrawRectangle(pen, position, width, height);
        }

        public static void DrawRectangle(Color color, int x, int y, int width, int height)
        {
            CGS.Pen pen = new CGS.Pen(color);
            Kernel.aCanvas.DrawRectangle(pen, x, y, width, height);
        }

        public static void DrawRectangle(CGS.Pen pen, int x, int y, int width, int height)
        {
            Kernel.aCanvas.DrawRectangle(pen, x, y, width, height);
        }

        //Draw Filled Rectangle
        public static void DrawFilledRectangle(CGS.Pen color, CGS.Point position, int width, int height)
        {
            Kernel.aCanvas.DrawFilledRectangle(color, position, width, height);
        }

        public static void DrawFilledRectangle(Color color, CGS.Point position, int width, int height)
        {
            CGS.Pen pen = new CGS.Pen(color);
            Kernel.aCanvas.DrawFilledRectangle(pen, position, width, height);
        }

        public static void DrawFilledRectangle(Color color, int x, int y, int width, int height)
        {
            CGS.Pen pen = new CGS.Pen(color);
            Kernel.aCanvas.DrawFilledRectangle(pen, x, y, width, height);
        }

        public static void DrawFilledRectangle(CGS.Pen pen, int x, int y, int width, int height)
        {
            Kernel.aCanvas.DrawFilledRectangle(pen, x, y, width, height);
        }

        //Clear
        public static void Clear(Color color)
        {
            CGS.Canvas canvas = Kernel.aCanvas;
            CGS.Pen pen = new CGS.Pen(color);
            canvas.DrawFilledRectangle(pen, new CGS.Point(0, 0), canvas.Mode.Rows, canvas.Mode.Columns);
        }
    }
}
