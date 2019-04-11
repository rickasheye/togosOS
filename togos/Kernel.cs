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
        public static Canvas aCanvas;
        public static Color backgroundColor;
        public static WindowManager manager;

        public static Sys.FileSystem.CosmosVFS fs;

        protected override void BeforeRun()
        {
        }

        public static  void KernelShutdown()
        {
            CustomConsole.WarningLog("Shutting Down!");
            Sys.Power.Shutdown();
        }

        public static void KernelRestart()
        {
            CustomConsole.WarningLog("Recieved Restart Command");
            Sys.Power.Reboot();
        }

        protected override void Run()
        {
            CommandExecutor.ExecuteCommand();
        }
    }
}
