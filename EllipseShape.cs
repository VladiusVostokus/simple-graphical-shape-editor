using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lab5
{
    class EllipseShape : Shape
    {
        private int strThickness;
        public EllipseShape(Canvas canvas) : base(canvas)
        {
            dashArr = new DoubleCollection() { 3, 3 };
            strThickness = 3;
        }

        private Ellipse ell;
        public override void OnMouseDown()
        {
            ell = new Ellipse();
            startPos.X = Mouse.GetPosition(drawCanvas).X;
            startPos.Y = Mouse.GetPosition(drawCanvas).Y;
            drawCanvas.Children.Add(ell);
        }

        public override void OnMouseMove(double offsetX1 = 0, double offsetY1 = 0, double offsetX2 = 0, double offsetY2 = 0)
        {
            endPos.X = Mouse.GetPosition(drawCanvas).X;
            endPos.Y = Mouse.GetPosition(drawCanvas).Y;
            
            ell.Width = Math.Abs(endPos.X - startPos.X);
            ell.Height = Math.Abs(endPos.Y - startPos.Y);
            ell.Stroke = Brushes.Black;
            ell.StrokeThickness = strThickness;
            ell.StrokeDashArray = dashArr;

            Canvas.SetLeft(ell, Math.Min(endPos.X, startPos.X));
            Canvas.SetTop(ell, Math.Min(endPos.Y, startPos.Y));
        }

        public override void OnMouseUp()
        {
            if (startPos != endPos) ell.StrokeDashArray = null;
            else drawCanvas.Children.Remove(ell);
        }
    }
}
