namespace viewer
{
    public struct Point3d
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public Point3d(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
    }
}
