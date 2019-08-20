using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using CGS = Cosmos.System.Graphics;

namespace togos.API
{
    public class DisplayDriver
    {
        public static CGS.Canvas aCanvas;

        //Draw Unfilled rectangle
        public static void DrawRectangle(CGS.Pen color, CGS.Point position, int width, int height)
        {
            if (GraphicsInitialised())
            {
                aCanvas.DrawRectangle(color, position, width, height);
            }
            else
            {
                InitialiseGraphics();
                DrawRectangle(color, position, width, height);
            }
        }
        
        public static void DrawRectangle(Color color, CGS.Point position, int width, int height)
        {
            if (GraphicsInitialised())
            {
                CGS.Pen pen = new CGS.Pen(color);
                aCanvas.DrawRectangle(pen, position, width, height);
            }
            else
            {
                InitialiseGraphics();
                DrawRectangle(color, position, width, height);
            }
        }

        public static void DrawRectangle(Color color, int x, int y, int width, int height)
        {
            if (GraphicsInitialised())
            {
                CGS.Pen pen = new CGS.Pen(color);
                aCanvas.DrawRectangle(pen, x, y, width, height);
            }
            else
            {
                InitialiseGraphics();
                DrawRectangle(color, x, y, width, height);
            }
        }

        public static void DrawRectangle(CGS.Pen pen, int x, int y, int width, int height)
        {
            if (GraphicsInitialised())
            {
                aCanvas.DrawRectangle(pen, x, y, width, height);
            }
            else
            {
                InitialiseGraphics();
                DrawRectangle(pen, x, y, width, height);
            }
        }

        //Draw Filled Rectangle
        public static void DrawFilledRectangle(CGS.Pen color, CGS.Point position, int width, int height)
        {
            if (GraphicsInitialised())
            {
                aCanvas.DrawFilledRectangle(color, position, width, height);
            }
            else
            {
                InitialiseGraphics();
                DrawFilledRectangle(color, position, width, height);
            }
        }

        public static void DrawFilledRectangle(Color color, CGS.Point position, int width, int height)
        {
            if (GraphicsInitialised())
            {
                CGS.Pen pen = new CGS.Pen(color);
                aCanvas.DrawFilledRectangle(pen, position, width, height);
            }
            else
            {
                InitialiseGraphics();
                DrawFilledRectangle(color, position, width, height);
            }
        }

        public static void DrawFilledRectangle(Color color, int x, int y, int width, int height)
        {
            if (GraphicsInitialised() == true)
            {
                CGS.Pen pen = new CGS.Pen(color);
                aCanvas.DrawFilledRectangle(pen, x, y, width, height);
            }
            else
            {
                InitialiseGraphics();
                DrawFilledRectangle(color, x, y, width, height);
            }
        }

        public static void DrawFilledRectangle(CGS.Pen pen, int x, int y, int width, int height)
        {
            if (GraphicsInitialised() == true)
            {
                aCanvas.DrawFilledRectangle(pen, x, y, width, height);
            }
            else
            {
                InitialiseGraphics();
                DrawFilledRectangle(pen, x, y, width, height);
            }
        }

        //Clear
        public static void Clear(Color color)
        {
            if (GraphicsInitialised() == true)
            {
                CGS.Pen pen = new CGS.Pen(color);
                aCanvas.DrawFilledRectangle(pen, new CGS.Point(0, 0), aCanvas.Mode.Rows, aCanvas.Mode.Columns);
            }
            else
            {
                InitialiseGraphics();
                Clear(color);
            }
        }

        public static void InitialiseGraphics()
        {
            try
            {
                if (aCanvas == null)
                {
                    aCanvas = CGS.FullScreenCanvas.GetFullScreenCanvas(new CGS.Mode(1280, 720, CGS.ColorDepth.ColorDepth32));
                    Console.WriteLine("Initiated Graphics!");
                }
                else
                {
                    CustomConsole.WarningLog("Graphics already initialised");
                }
            }
            catch (Exception e)
            {
                CustomConsole.ErrorLog(e.ToString());
            }
        }

        public static bool GraphicsInitialised()
        {
            bool init = false;
            if(aCanvas != null)
            {
                init = true;
            }
            return init;
        }
    }
}
