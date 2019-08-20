using System;
using System.Collections.Generic;
using System.Text;
using CMouse = Cosmos.System.MouseManager;

namespace togos.Graphics
{
    public static class MousePointer
    {
        public static Cosmos.System.Graphics.Point ToPoint() => new Cosmos.System.Graphics.Point((int)CMouse.X, (int)CMouse.Y);

        public static void InitMouse(Cosmos.System.Graphics.Mode mode)
        {
            CMouse.ScreenHeight = (uint)mode.Rows;
            CMouse.ScreenWidth = (uint)mode.Columns;
        }
    }
}
