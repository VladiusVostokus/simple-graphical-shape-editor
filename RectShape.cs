using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lab5
{
    class RectShape : Shape
    {
        public RectShape(Canvas canvas) : base(canvas)
        {
            dashArr = new DoubleCollection() { 3, 3 };
        }

        private Rectangle rect;

        public override void OnMouseDown()
        {
            rect = new Rectangle();
            startPos.X = Mouse.GetPosition(drawCanvas).X;
            startPos.Y = Mouse.GetPosition(drawCanvas).Y;
            drawCanvas.Children.Add(rect);
        }

        public override void OnMouseMove(double offsetX1 = 0, double offsetY1 = 0, double offsetX2 = 0, double offsetY2 = 0)
        {
            endPos.X = Mouse.GetPosition(drawCanvas).X;
            endPos.Y = Mouse.GetPosition(drawCanvas).Y;

            double left = startPos.X * 2 - endPos.X - offsetX1;
            double top = startPos.Y * 2 - endPos.Y + offsetX1;

            rect.Width = Math.Abs(endPos.X - startPos.X) * 2;
            rect.Height = Math.Abs(endPos.Y - startPos.Y) * 2;
            rect.Stroke = Brushes.Black;
            rect.StrokeThickness = 3;
            rect.StrokeDashArray = dashArr;

            Canvas.SetLeft(rect, Math.Min(endPos.X - offsetX1, left));
            Canvas.SetTop(rect, Math.Min(endPos.Y + offsetX1, top));
        }

        public override void OnMouseUp()
        {
            if (startPos != endPos)
            {
                rect.StrokeDashArray = null;
                rect.Fill = Brushes.LightGreen;
            }
            else drawCanvas.Children.Remove(rect);
        }

        public void setNullFill() {
            rect.Fill = null;
        }
    }
}
