using System;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using System.Drawing;
using Point = Cosmos.System.Graphics.Point;
using System.IO;
using System.Collections.Generic;
using CMouse = Cosmos.System.MouseManager;
using Keyboard = Cosmos.HAL.KeyboardBase;

namespace togos
{
    public class Kernel : Sys.Kernel
    {
        public static Point ToPoint() => new Point((int)CMouse.X, (int)CMouse.Y);
        Canvas aCanvas;
        Color backgroundColor;
        WindowManager manager;
        public string ComputerName;

        //Button
        Button button;

        CommandExecutor execute;
        FileSystem newFileSystem;

        protected override void BeforeRun()
        {
            try
            {

                //Initiate Console Mode
                Console.WriteLine("Initiating Console Mode");
                execute = new CommandExecutor(this);
                Console.WriteLine("Initiate File System");
                newFileSystem = new FileSystem();
            }
            catch (Exception e)
            {
                mDebugger.Send("Error: " + e);
            }
        }

        public void keyPressed(byte ScanCode, bool Released)
        {
            if(ScanCode == 0x21 )
            {
                Console.WriteLine("Switching to Console Mode");
                
            }
        }

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

            Console.WriteLine("Initialising Keyboard");
            //Initiate Keyboards
            foreach (Keyboard KeyboardM in Cosmos.HAL.Global.GetKeyboardDevices())
            {
                Console.WriteLine("Connected Keyboard: " + KeyboardM.ToString());
                KeyboardM.Initialize();
                KeyboardM.OnKeyPressed = keyPressed;
            }
        }

        private void DrawDesktop(Mode mode)
        {
            try
            {
                aCanvas = FullScreenCanvas.GetFullScreenCanvas(mode);

                //Draw the desktop background
                aCanvas.DrawFilledRectangle(new Pen(backgroundColor), new Point(0, 0), aCanvas.Mode.Columns, aCanvas.Mode.Rows);
                /* A red Point */ //With the mouse
                Pen pen = new Pen(Color.Green);
                /* A filled rectange */ //As the taskbar
                Console.WriteLine("Rendering Taskbar");
                aCanvas.DrawFilledRectangle(pen, 0, mode.Rows - 30, mode.Columns, 30);

                pen.Color = Color.GreenYellow;
                aCanvas.DrawFilledRectangle(pen, mode.Columns - 65, mode.Rows - 25, 60, 20);

                button = new Button(5, mode.Rows - 25, 20, 20, aCanvas);

                Console.WriteLine("Rendering Font");
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
            manager.CreateWindow(name, x, y, width, height, canvas, backgroundColor);
        }

        protected override void Run()
        {
            if (aCanvas != null)
            {
                //Since the graphics are supposevely initated lets draw a mouse
                Pen pen = new Pen(Color.White);
                //aCanvas.DrawRectangle(pen, new Point(ToPoint().X - 2, ToPoint().Y - 2), 4, 4);
                aCanvas.DrawPoint(pen, ToPoint().X, ToPoint().Y);
                button.TriggerButton(ToPoint().X, ToPoint().Y, delegate { TaskManager(); }, delegate { CloseTaskManager(); });
            }
            else
            {
                execute.ExecuteCommand(newFileSystem);
            }
        }
    }
}
