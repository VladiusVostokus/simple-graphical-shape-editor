using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Lab5
{
    public abstract class Shape
    {
        protected Canvas drawCanvas;
        protected DoubleCollection dashArr;
        protected Point startPos, endPos;

        public Shape(Canvas canvas)
        {
            drawCanvas = canvas;
        }
        public abstract void OnMouseDown();
        public abstract void OnMouseMove(double offsetX1 = 0, double offsetY1 = 0, double offsetX2 = 0, double offsetY2 = 0);
        public abstract void OnMouseUp();

    }
}
