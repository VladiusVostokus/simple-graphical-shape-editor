using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lab5
{
    class PointShape : Shape
    {
        public PointShape(Canvas canvas) : base(canvas)
        {
        }
        public override void OnMouseDown()
        {
            Ellipse p = new Ellipse()
            {
                Height = 5,
                Width = 5,
                StrokeThickness = 3,
                Stroke = Brushes.Black,
            };

            Canvas.SetLeft(p, Mouse.GetPosition(drawCanvas).X);
            Canvas.SetTop(p, Mouse.GetPosition(drawCanvas).Y);
            drawCanvas.Children.Add(p);
        }
        public override void OnMouseMove(double offsetX1 = 0, double offsetY1 = 0, double offsetX2 = 0, double offsetY2 = 0) { }
        public override void OnMouseUp() { }
    }
}
