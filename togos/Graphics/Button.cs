using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using System.Drawing;

namespace togos
{
    class Button
    {
        int sizeButtonX;
        int sizeButtonY;
        int minSizeButtonX;
        int minSizeButtonY;
        Canvas storedCanvas;

        public Button(int minX, int minY, int maxX, int maxY, Canvas canvas, Action actionPressed, Action actionReleased)
        {
            sizeButtonX = maxX;
            sizeButtonY = maxY;
            minSizeButtonX = minX;
            minSizeButtonY = minY;
            CreateButton(canvas);
            while (true)
            {
                TriggerButton(Graphics.MousePointer.ToPoint().X, Graphics.MousePointer.ToPoint().Y, actionPressed, actionReleased);
            }
        }

        public void CreateButton(Canvas canvas)
        {
            Pen pen = new Pen(Color.Gray);
            canvas.DrawFilledRectangle(pen, minSizeButtonX, minSizeButtonY, sizeButtonX, sizeButtonY);
            pen.Color = Color.Black;
            canvas.DrawRectangle(pen, minSizeButtonX, minSizeButtonY, sizeButtonX, sizeButtonY);
            storedCanvas = canvas;
        }

        public void TriggerButton(int mousex, int mousey, Action actionPressed, Action actionReleased)
        {
            Pen pen = new Pen(Color.Blue);
            if (mousex > minSizeButtonX && mousex < minSizeButtonX + sizeButtonX && mousey > minSizeButtonY && mousey < minSizeButtonY + sizeButtonY)
            {
                //When the user hovers the mouse over the button
                //Try something else
                pen.Color = Color.Blue;
                storedCanvas.DrawRectangle(pen, minSizeButtonX, minSizeButtonY, sizeButtonX, sizeButtonY);
                actionPressed();
            }
            else
            {
                //When the button releases
                pen.Color = Color.Black;
                storedCanvas.DrawRectangle(pen, minSizeButtonX, minSizeButtonY, sizeButtonX, sizeButtonY);
                actionReleased();
            }
        }
    }
}
