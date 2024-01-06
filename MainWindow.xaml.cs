using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Lab5
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private readonly MyEditor editor = MyEditor.Instance();
        private MyTable.MyTable mytable = new MyTable.MyTable(); 
        private Shape settedShape;
   
        private void OnLButtonDown(object sender, MouseButtonEventArgs e)
        {
            editor.OnMouseDown(settedShape,e.GetPosition(this));
            mytable.SetStart(e.GetPosition(this));
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            editor.OnMouseMove(settedShape);
        }

        private void OnLButtonUp(object sender, MouseButtonEventArgs e)
        {
            editor.OnMouseUp(settedShape, e.GetPosition(this));
            mytable.AddElem(e.GetPosition(this));
        }
        private void ChoosePoint(object sender, RoutedEventArgs e)
        {
            Title = "Малювання точки";
            ChooseShape(new PointShape(drawCanvas));
        }
        private void ChooseLine(object sender, RoutedEventArgs e)
        {
            Title = "Малювання лінії";
            ChooseShape(new LineShape(drawCanvas));
        }
        private void ChooseRectangle(object sender, RoutedEventArgs e)
        {
            Title = "Малювання прямокутника";
            ChooseShape(new RectShape(drawCanvas));
        }
        private void ChooseEllipse(object sender, RoutedEventArgs e)
        {
            Title = "Малювання еліпса";
            ChooseShape(new EllipseShape(drawCanvas));
        }
        private void ChooseOOLine(object sender, RoutedEventArgs e)
        {
            Title = "Малювання гантелі";
            ChooseShape(new LineOOShape(drawCanvas));
        }

        private void ChooseCube(object sender, RoutedEventArgs e)
        {
            Title = "Малювання куба";
            ChooseShape(new CubeShape(drawCanvas));
        }

        private void ChooseShape(Shape shape)
        {
            settedShape = shape;
            mytable.SetShapeType(shape);
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            drawCanvas.Children.Clear();
            mytable.ClearList();
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            editor.CloseFile();
            mytable.Close();
        }

        private void TableClick(object sender, RoutedEventArgs e)
        {
            mytable.Show(); 
            if (mytable.WindowState == WindowState.Minimized)
                mytable.WindowState = WindowState.Normal;
        }
    }
}
