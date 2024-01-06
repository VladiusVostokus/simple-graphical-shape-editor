using System;
using System.Windows;
using System.IO;

namespace Lab5
{
    class MyEditor
    {
        private MyEditor()
        {

        }

        private static MyEditor? instance;
        private bool isDraw = false;
        private Point shapeStart;
        private static string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private static string relativePath = Path.Combine(currentDirectory, "Text/text.txt");
        private ShapeWriter writer = new ShapeWriter(relativePath);

        public static MyEditor Instance()
        {
            if (instance == null)
            {
                instance = new MyEditor();
            }
            return instance;
        }

        public void OnMouseDown(Shape shape ,Point start)
        {
            if (shape != null)
            {
                shapeStart = start;
                shape.OnMouseDown();
                isDraw = true;
            }
        }
        public void OnMouseMove(Shape shape)
        {
            if (isDraw == true)
            {
                shape.OnMouseMove();
            }
        }
        public void OnMouseUp(Shape shape, Point end)
        {
            if (isDraw == true)
            {
                shape.OnMouseUp();
                string type = shape.GetType().Name;
                if (type == "PointShape")
                {
                    writer.Write(type, (int)shapeStart.X, (int)shapeStart.Y, (int)shapeStart.X, (int)shapeStart.Y);
                }
                else
                {
                    if (shapeStart != end)
                    {
                        writer.Write(type, (int)shapeStart.X, (int)shapeStart.Y, (int)end.X, (int)end.Y);
                    }
                }
            }
            isDraw = false;
        }
        
        public void CloseFile() { writer.Close(); }
    }
}
