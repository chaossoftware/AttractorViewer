using System;
using System.Collections.Generic;

namespace viewer
{
    class Point3DComparer : IEqualityComparer<Point3D>
    {
        public bool Equals(Point3D x, Point3D y)
        {
            return Math.Abs(x.X - y.X) < 0.01 && Math.Abs(x.Y - y.Y) < 0.01 && Math.Abs(x.Z - y.Z) < 0.01;
        }


        public int GetHashCode(Point3D obj)
        {
            return (int)(obj.X + obj.Y + obj.Z);
        }

    }
}
