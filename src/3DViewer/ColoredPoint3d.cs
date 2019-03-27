using System.Drawing;

namespace viewer
{
    public struct ColoredPoint3D
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public Color PointColor { get; set; }

        public ColoredPoint3D(double x, double y, double z, Color color)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.PointColor = color;
        }
    }
}
