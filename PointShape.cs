using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lab5
{
    class PointShape : Shape
    {
    private int size, strThickness;
        public PointShape(Canvas canvas) : base(canvas)
        {
            size = 5;
            strThickness = 3;
            
        }
        public override void OnMouseDown()
        {
            Ellipse p = new Ellipse()
            {
                Height = size,
                Width = size,
                StrokeThickness = strThickness,
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
