using System.Windows;
using System.Windows.Input;

namespace Lab5.MyTable
{
    public partial class MyTable : Window
    {
        public MyTable()
        {
            InitializeComponent();
        }

        private Point shapeStart;
        private string? shapeType;
        private string point = "PointShape";

        public void SetStart(Point start)
        {
            shapeStart = start;
        }

        public void SetShapeType(Shape shape)
        {
            shapeType = shape.GetType().Name;
        }

        public void AddElem(Point shapeEnd)
        {
            if(shapeType != null)
            {
                int startX = (int)shapeStart.X;
                int startY = (int)shapeStart.Y;
                int endX = (int)shapeEnd.X;
                int endY = (int)shapeEnd.Y;

                if (shapeType == point)
                {
                    string elem = $"{shapeType}\t{startX}\t{startY}";
                    ListOfShapes.Items.Add(elem);
                }
                else {
                    if (shapeStart != shapeEnd)
                    {
                        string elem = $"{shapeType}\t{startX}\t{startY}\t{endX}\t{endY}";
                        ListOfShapes.Items.Add(elem);
                    }
                }
            }
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void MinimizeClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void MaximizeClick(object sender, RoutedEventArgs e)
        { 
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else WindowState = WindowState.Normal;
        }

        public void ClearList()
        {
            ListOfShapes.Items.Clear();
        }
    }
}
