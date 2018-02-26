using System;
using System.Collections.Generic;

namespace viewer
{
    class structs
    {
        //=============================3D point structure====================
        public struct point3d
        {
            double x;
            double y;
            double z;

            public double X
            {
                get { return x; }
                set { x = value; }
            }

            public double Y
            {
                get { return y; }
                set { y = value; }
            }

            public double Z
            {
                get { return z; }
                set { z = value; }
            }

            public point3d(double x, double y, double z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
        }
    }

    class Point3DComparer : IEqualityComparer<structs.point3d>
    {
        public bool Equals(structs.point3d x, structs.point3d y)
        {
            return Math.Abs(x.X - y.X) < 0.1 && Math.Abs(x.Y - y.Y) < 0.1 && Math.Abs(x.Z - y.Z) < 0.1;
        }


        public int GetHashCode(structs.point3d obj)
        {
            return (int)(obj.X + obj.Y + obj.Z);
        }

    }
}
