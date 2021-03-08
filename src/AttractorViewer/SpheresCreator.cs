using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Media3D;

namespace AttractorViewer
{
    public class SpheresCreator
    {
        private const double Radius = 0.5;
        private const int Thetas = 15;
        private const int Phis = 10;

        private const double _cx = 0.5;
        private const double _cy = 0.5;
        private const double _cz = 0.5;

        private readonly double dphi;
        private readonly double dtheta;

        private readonly MeshGeometry3D _mesh;

        public SpheresCreator()
        {
            dphi = Math.PI / Phis;
            dtheta = 2 * Math.PI / Thetas;

            _mesh = new MeshGeometry3D();

            // Remember the first point.
            int pt0 = _mesh.Positions.Count;

            // Make the points.
            double phi1 = Math.PI / 2;
            for (int p = 0; p <= Phis; p++)
            {
                double r1 = Radius * Math.Cos(phi1);
                double y1 = Radius * Math.Sin(phi1);

                double theta = 0;
                for (int t = 0; t <= Thetas; t++)
                {
                    _mesh.Positions.Add(new Point3D(
                        _cx + r1 * Math.Cos(theta),
                        _cy + y1,
                        _cz + -r1 * Math.Sin(theta)));
                    _mesh.TextureCoordinates.Add(new Point(
                        (double)t / Thetas, (double)p / Phis));
                    theta += dtheta;
                }
                phi1 -= dphi;
            }

            // Make the triangles.
            int i1, i2, i3, i4;
            for (int p = 0; p <= Phis - 1; p++)
            {
                i1 = p * (Thetas + 1);
                i2 = i1 + (Thetas + 1);

                for (int t = 0; t <= Thetas - 1; t++)
                {
                    i3 = i1 + 1;
                    i4 = i2 + 1;
                    _mesh.TriangleIndices.Add(pt0 + i1);
                    _mesh.TriangleIndices.Add(pt0 + i2);
                    _mesh.TriangleIndices.Add(pt0 + i4);

                    _mesh.TriangleIndices.Add(pt0 + i1);
                    _mesh.TriangleIndices.Add(pt0 + i4);
                    _mesh.TriangleIndices.Add(pt0 + i3);
                    i1 += 1;
                    i2 += 1;
                }
            }
        }

        public GeometryModel3D CreateModel(Material material) =>
            new GeometryModel3D(_mesh.Clone(), material);
    }
}
