using System.Collections.Generic;
using System.IO;

namespace viewer
{
    class reading
    {
        public structs.point3d[] points;
        private string path;

        public reading(string fileName)
        {
            path = fileName;
        }

        //=============================Reading from file====================

        public void read()
        {
            StreamReader sr = new StreamReader(path);
            string pointCoordinates;

            HashSet<structs.point3d> set = new HashSet<structs.point3d>(new Point3DComparer());

            while ((pointCoordinates = sr.ReadLine()) != null)
            {
                string[] parts = pointCoordinates.Split(' ', '\n', '\r');
                structs.point3d pt = new structs.point3d();
                pt.X = double.Parse(parts[0], System.Globalization.CultureInfo.InvariantCulture);
                pt.Y = double.Parse(parts[1], System.Globalization.CultureInfo.InvariantCulture);
                pt.Z = double.Parse(parts[2], System.Globalization.CultureInfo.InvariantCulture);

                set.Add(pt);
            }

            points = new structs.point3d[set.Count];
            set.CopyTo(points);
        }
    }
}
