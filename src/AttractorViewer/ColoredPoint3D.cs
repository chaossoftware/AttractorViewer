using System.Drawing;

namespace AttractorViewer
{
    public struct ColoredPoint3D
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public Color PointColor { get; set; }

        public ColoredPoint3D(double x, double y, double z, Color color)
        {
            X = x;
            Y = y;
            Z = z;
            PointColor = color;
        }
    }
}
