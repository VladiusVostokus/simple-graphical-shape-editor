using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Lab5
{
    class CubeShape : Shape
    {
        public CubeShape(Canvas canvas) : base(canvas)
        {
            dashArr = new DoubleCollection() { 3, 3 };
        }

        private RectShape rect1, rect2;

        private LineShape l1, l2, l3, l4;

        public override void OnMouseDown()
        {
            startPos.X = Mouse.GetPosition(drawCanvas).X;
            startPos.Y = Mouse.GetPosition(drawCanvas).Y;

            l1 = new LineShape(drawCanvas);
            l2 = new LineShape(drawCanvas);
            l3 = new LineShape(drawCanvas);
            l4 = new LineShape(drawCanvas);

            rect1 = new RectShape(drawCanvas);
            rect2 = new RectShape(drawCanvas);

            l1.OnMouseDown();
            l2.OnMouseDown();
            l3.OnMouseDown();
            l4.OnMouseDown();
            rect1.OnMouseDown();
            rect2.OnMouseDown();
        }

        public override void OnMouseMove(double offsetX1 = 0, double offsetY1 = 0, double offsetX2 = 0, double offsetY2 = 0)  
        {
            endPos.X = Mouse.GetPosition(drawCanvas).X;
            endPos.Y = Mouse.GetPosition(drawCanvas).Y;

            double offsetForX1 = Math.Abs(endPos.X - startPos.X);
            double offsetForY1 = Math.Abs(endPos.Y - startPos.Y);
            double offsetForX2 = offsetForY1;
            double offsetForY2 = offsetForY1;
            double rectOffset = offsetForY1;
            double altX2;

            rect1.OnMouseMove();
            rect2.OnMouseMove(rectOffset);

            if (startPos.X < endPos.X) offsetForX2 += (offsetForX1 * 2);
            if (startPos.Y > endPos.Y) offsetForY2 -= (offsetForY1 * 2);

            l1.OnMouseMove(offsetForX1, offsetForY1 , offsetForX2, offsetForY2);

            altX2 = offsetForX2 - offsetForX1 * 2;
            l2.OnMouseMove(-offsetForX1,offsetForY1 , altX2, offsetForY2);

            if(startPos.Y > endPos.Y) offsetForY2 -= offsetForY2 * 4;
            l3.OnMouseMove(offsetForX1, -offsetForY1, offsetForX2, -offsetForY2);

            offsetForX2 -= offsetForX1 * 2;
            l4.OnMouseMove(-offsetForX1, -offsetForY1, offsetForX2, -offsetForY2);
        }

        public override void OnMouseUp()
        {
            rect1.OnMouseUp();
            rect1.setNullFill();
            rect2.OnMouseUp();
            rect2.setNullFill();

            l1.OnMouseUp();
            l2.OnMouseUp();
            l3.OnMouseUp();
            l4.OnMouseUp();
        }
    }
}
