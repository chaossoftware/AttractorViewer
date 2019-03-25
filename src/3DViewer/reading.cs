using System.Collections.Generic;
using System.IO;

namespace viewer
{
    public class reading
    {
        public Point3d[] points;
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

            HashSet<Point3d> set = new HashSet<Point3d>(new Point3DComparer());

            while ((pointCoordinates = sr.ReadLine()) != null)
            {
                string[] parts = pointCoordinates.Split(' ', '\n', '\r');
                Point3d pt = new Point3d();
                pt.X = double.Parse(parts[0], System.Globalization.CultureInfo.InvariantCulture);
                pt.Y = double.Parse(parts[1], System.Globalization.CultureInfo.InvariantCulture);
                pt.Z = double.Parse(parts[2], System.Globalization.CultureInfo.InvariantCulture);

                set.Add(pt);
            }

            points = new Point3d[set.Count];
            set.CopyTo(points);
        }
    }
}
