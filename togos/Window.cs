using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace togos
{
    public class Window
    {
        public string storedName;
        public int storedX;
        public int storedY;
        public int storedWidth;
        public int storedHeight;
        Button exitButton;

        public Window(string name, int x, int y, int width, int height, Canvas canvas)
        {
            storedName = name;
            RenderWindow(x, y, width, height, canvas);
            exitButton = new Button(x, y, 30, 30, canvas);
        }

        public void MovePosition(int newX, int newY, Canvas canvas)
        {
            Pen pen = new Pen(Kernel.backgroundColor);
            canvas.DrawFilledRectangle(pen, new Cosmos.System.Graphics.Point(storedX, storedY), storedWidth, storedHeight);
            RenderWindow(newX, newY, storedWidth, storedHeight, canvas);
        }

        public void RenderWindow(int x, int y, int width, int height, Canvas canvas)
        {
            Pen pen = new Pen(Color.White);
            canvas.DrawFilledRectangle(pen, new Cosmos.System.Graphics.Point(x, y), width, height);
            //exitButton.TriggerButton(Kernel.ToPoint().X, Kernel.ToPoint().Y, delegate { CloseWindow(canvas); });
            storedX = x;
            storedY = y;
            storedWidth = width;
            storedHeight = height;
        }

        public void CloseWindow(Canvas canvas)
        {
            Pen pen = new Pen(Kernel.backgroundColor);
            exitButton = null;
            canvas.DrawFilledRectangle(pen, new Cosmos.System.Graphics.Point(storedX, storedY), storedWidth, storedHeight);
            WindowManager.CloseWindow(this, canvas);
        }
    }
}
