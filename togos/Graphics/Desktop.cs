using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Cosmos.System.Graphics;
using IL2CPU.API.Attribs;

namespace togos
{
    public class Desktop
    {
        //I seriously think this needs to be re-written
        public static Mode mode;
        public static Color backgroundColor;
        public static WindowManager manager;
        [ManifestResourceStream(ResourceName = "togos.Resources.3.bmp")]
        public static byte[] three;

        public static void InitGraphics()
        {
            mode = new Mode(1280, 720, ColorDepth.ColorDepth32);
            //Load Colours
            backgroundColor = Color.Red;
            //aCanvas.Clear(backgroundColor);
            //Load Window Manager
            manager = new WindowManager();
            //Load Desktop
            DrawDesktop(mode);
            //Initialise the mouse
        }

        private static void DrawDesktop(Mode mode)
        {
            try
            {
                Console.WriteLine("Initialising Mouse");
                Graphics.MousePointer.InitMouse(mode);
                //Draw the desktop background
                API.DisplayDriver.DrawFilledRectangle(backgroundColor, new Cosmos.System.Graphics.Point(0, 0), mode.Columns, mode.Rows);
                /* A filled rectange */ //As the taskbar
                Console.WriteLine("Rendering Taskbar");
                Graphics.Taskbar.RenderTaskbar(mode);
                //CreateWindow("Program Manager", 60, 30, 500, 400, aCanvas);
                manager.CreateWindow("Testing Window", 40, 40, 500, 500, API.DisplayDriver.aCanvas);
                Bitmap map = new Bitmap(three);
                API.DisplayDriver.aCanvas.DrawImage(map, 10, 10);
                while (true)
                {
                    Run();
                }
            }
            catch (Exception e)
            {
                CustomConsole.ErrorLog(e.ToString());
            }
        }

        public void TaskManager()
        {
            API.DisplayDriver.DrawFilledRectangle(Color.White, 5, mode.Rows - 80 * 4, 160, 280);
            API.DisplayDriver.DrawFilledRectangle(Color.Green, 5, mode.Rows - 80 * 4, 160, 10);
            API.DisplayDriver.DrawFilledRectangle(Color.Red, 5, mode.Rows - 80 * 4, 80, 10);
        }

        public void CloseTaskManager()
        {
            API.DisplayDriver.DrawFilledRectangle(backgroundColor, 5, mode.Rows - 80 * 4, 160, 280);
        }

        public static void Run()
        {
            //API.DisplayDriver.Clear(Color.Green);
            Pen pen = new Pen(Color.Black);
            API.DisplayDriver.aCanvas.DrawPoint(pen, Graphics.MousePointer.ToPoint().X, Graphics.MousePointer.ToPoint().Y);
            /*Bitmap map = FontRenderer.CreateFont('K');
            API.DisplayDriver.aCanvas.DrawImage(map, 10, 20);*/
        }
    }
}
