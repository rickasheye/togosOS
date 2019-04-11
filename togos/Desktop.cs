using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using CMouse = Cosmos.System.MouseManager;

namespace togos
{
    public class Desktop : Kernel
    {
        public void InitGraphics()
        {
            //Load Colours
            backgroundColor = Color.Red;
            //aCanvas.Clear(backgroundColor);
            //Load Window Manager
            manager = new WindowManager();
            //Load Desktop
            DrawDesktop(new Mode(1280, 720, ColorDepth.ColorDepth32));

            Console.WriteLine("Initialising Mouse");
            //Initialise the mouse
            CMouse.ScreenHeight = (uint)aCanvas.Mode.Rows;
            CMouse.ScreenWidth = (uint)aCanvas.Mode.Columns;
        }

        private void DrawDesktop(Mode mode)
        {
            try
            {
                aCanvas = FullScreenCanvas.GetFullScreenCanvas(mode);

                //Draw the desktop background
                aCanvas.DrawFilledRectangle(new Pen(backgroundColor), new Cosmos.System.Graphics.Point(0, 0), aCanvas.Mode.Columns, aCanvas.Mode.Rows);
                /* A red Point */ //With the mouse
                Pen pen = new Pen(Color.Green);
                /* A filled rectange */ //As the taskbar
                Console.WriteLine("Rendering Taskbar");
                aCanvas.DrawFilledRectangle(pen, 0, mode.Rows - 30, mode.Columns, 30);

                pen.Color = Color.GreenYellow;
                aCanvas.DrawFilledRectangle(pen, mode.Columns - 65, mode.Rows - 25, 60, 20);

                //FontRenderer.FontRender("01234", 15, 15, aCanvas);
                //CreateWindow("Program Manager", 60, 30, 500, 400, aCanvas);
            }
            catch (Exception e)
            {
                Console.WriteLine("Debug: Error: " + e);
            }
        }

        public void TaskManager()
        {
            Pen pen = new Pen(Color.White);
            aCanvas.DrawFilledRectangle(pen, 5, aCanvas.Mode.Rows - 80 * 4, 160, 280);
            pen.Color = Color.Green;
            aCanvas.DrawFilledRectangle(pen, 5, aCanvas.Mode.Rows - 80 * 4, 160, 10);
            pen.Color = Color.Red;
            aCanvas.DrawFilledRectangle(pen, 5, aCanvas.Mode.Rows - 80 * 4, 80, 10);
        }

        public void CloseTaskManager()
        {
            Pen pen = new Pen(backgroundColor);
            aCanvas.DrawFilledRectangle(pen, 5, aCanvas.Mode.Rows - 80 * 4, 160, 280);
        }

        public void CreateWindow(string name, int x, int y, int width, int height, Canvas canvas)
        {
            manager.CreateWindow(name, x, y, width, height, canvas);
        }

        protected override void Run()
        {
            if (aCanvas != null)
            {
                //Since the graphics are supposevely initated lets draw a mouse
                Pen pen = new Pen(Color.White);
                //aCanvas.DrawRectangle(pen, new Point(ToPoint().X - 2, ToPoint().Y - 2), 4, 4);
                aCanvas.DrawPoint(pen, ToPoint().X, ToPoint().Y);
            }
            else
            {
                InitGraphics();
            }
        }
    }
}
