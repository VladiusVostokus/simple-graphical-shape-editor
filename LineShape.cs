using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lab5
{
    class LineShape : Shape
    {
        public LineShape(Canvas canvas) : base(canvas)
        {
            dashArr = new DoubleCollection() { 3, 3 };
        }

        private Line l;
        public override void OnMouseDown()
        {
            l = new Line();
            startPos.X = Mouse.GetPosition(drawCanvas).X;
            startPos.Y = Mouse.GetPosition(drawCanvas).Y;
            drawCanvas.Children.Add(l);
        }

        public override void OnMouseMove(double offsetX1 = 0, double offsetY1 = 0, double offsetX2 = 0, double offsetY2 = 0)
        {
            endPos.X = Mouse.GetPosition(drawCanvas).X;
            endPos.Y = Mouse.GetPosition(drawCanvas).Y;

            l.X1 = startPos.X - offsetX1;
            l.Y1 = startPos.Y - offsetY1;
            l.X2 = endPos.X - offsetX2;
            l.Y2 = endPos.Y - offsetY2;
            l.Stroke = Brushes.Black;
            l.StrokeThickness = 3;
            l.StrokeDashArray = dashArr;
        }

        public override void OnMouseUp()
        {
            if (startPos != endPos) l.StrokeDashArray = null; 
            else drawCanvas.Children.Remove(l);
        }
    }
}
