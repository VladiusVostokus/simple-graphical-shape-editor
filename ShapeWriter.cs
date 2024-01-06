using System.IO;

namespace Lab5
{
    class ShapeWriter
    {
        private StreamWriter writer;
        private string point = "PointShape";
        public ShapeWriter(string path)
        {
            writer = new StreamWriter(path);
        }

        public void Write(string shapeType, int X1, int Y1, int X2, int Y2) {

            if (shapeType != point)
                writer.WriteLine($"{shapeType}\t{X1}\t{Y1}\t{X2}\t{Y2}");
            else writer.WriteLine($"{shapeType}\t{X1}\t{Y1}");
        }
        public void Close() { writer.Close(); }
    }
}
