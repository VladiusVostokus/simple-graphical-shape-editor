using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lab5
{
    class LineOOShape : LineShape
    {
        private Ellipse ell1,ell2;
        private int ellSize, elloffSet, strThickness;

        public LineOOShape(Canvas canvas) : base(canvas)
        {
            dashArr = new DoubleCollection() { 3, 3 };
            ellSize = 20;
            elloffSet = ellSize / 2;
            strThickness = 3;
        }

        public override void OnMouseDown()
        {   
            ell1 = new Ellipse();
            ell2 = new Ellipse();
            startPos.X = Mouse.GetPosition(drawCanvas).X;
            startPos.Y = Mouse.GetPosition(drawCanvas).Y;
            drawCanvas.Children.Add(ell1);
            drawCanvas.Children.Add(ell2);
            base.OnMouseDown();
        }

        public override void OnMouseMove(double offsetX1 = 0, double offsetY1 = 0, double offsetX2 = 0, double offsetY2 = 0)
        {
            ell1.Height = ellSize;
            ell1.Width = ellSize;
            ell2.Height = ellSize;
            ell2.Width = ellSize;

            ell1.Stroke = Brushes.Black;
            ell1.StrokeThickness = strThickness;
            ell1.StrokeDashArray = dashArr;

            ell2.Stroke = Brushes.Black;
            ell2.StrokeThickness = strThickness;
            ell2.StrokeDashArray = dashArr;

            Canvas.SetLeft(ell1, startPos.X - elloffSet);
            Canvas.SetTop(ell1, startPos.Y - elloffSet);
            Canvas.SetLeft(ell2, endPos.X - elloffSet);
            Canvas.SetTop(ell2, endPos.Y - elloffSet);

            base.OnMouseMove();
        }

        public override void OnMouseUp()
        {
            ell1.StrokeDashArray = null;
            ell2.StrokeDashArray = null;
            ell1.Fill = Brushes.Black;
            ell2.Fill = Brushes.Black;
            base.OnMouseUp();
        }
    }
}
