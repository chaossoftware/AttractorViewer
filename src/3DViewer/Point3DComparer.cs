using System;
using System.Collections.Generic;

namespace viewer
{
    class Point3DComparer : IEqualityComparer<Point3d>
    {
        public bool Equals(Point3d x, Point3d y)
        {
            return Math.Abs(x.X - y.X) < 0.01 && Math.Abs(x.Y - y.Y) < 0.01 && Math.Abs(x.Z - y.Z) < 0.01;
        }


        public int GetHashCode(Point3d obj)
        {
            return (int)(obj.X + obj.Y + obj.Z);
        }

    }
}
