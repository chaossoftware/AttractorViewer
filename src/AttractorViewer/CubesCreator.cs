using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace AttractorViewer
{
    public class CubesCreator
    {
        private readonly int[] _triangleIndices = new int[]
        {
            0, 2 ,1,
            1, 2, 3,
            0, 4, 2,
            2, 4, 6,
            0, 1, 4,
            1, 5, 4,
            1, 7, 5,
            1, 3, 7,
            4, 5, 6,
            7, 6, 5,
            2, 6, 3,
            3, 6, 7
        };

        private readonly Vector3D[] _normals = new Vector3D[]
        {
            new Vector3D(0, 1, 0),
            new Vector3D(0, 1, 0),
            new Vector3D(1, 0, 0),
            new Vector3D(1, 0, 0),
            new Vector3D(0, 1, 0),
            new Vector3D(0, 1, 0),
            new Vector3D(1, 0, 0),
            new Vector3D(1, 0, 0)
        };

        private readonly Point[] _textureCoordinates = new Point[]
        {
            new Point(0, 0),
            new Point(0, 0),
            new Point(0, 0),
            new Point(0, 0),
            new Point(0, 0),
            new Point(0, 1),
            new Point(1, 0),
            new Point(1, 1),
            new Point(0, 0),
            new Point(0, 0),
            new Point(0, 0),
            new Point(0, 0),
            new Point(0, 0),
            new Point(0, 0),
            new Point(0, 0),
            new Point(0, 0),
            new Point(0, 0),
            new Point(0, 0),
            new Point(0, 0),
            new Point(0, 0),
            new Point(0, 0),
            new Point(0, 0),
            new Point(0, 0),
            new Point(0, 0)
        };

        public GeometryModel3D CreateModel(Material material, double x, double y, double z, double pointSize)
        {
            var _positions = new Point3D[]
            {
                new Point3D(x, y, z),
                new Point3D(x + pointSize, y, z),
                new Point3D(x, y + pointSize, z),
                new Point3D(x + pointSize, y + pointSize, z),
                new Point3D(x, y, z + pointSize),
                new Point3D(x + pointSize, y, z + pointSize),
                new Point3D(x, y + pointSize, z + pointSize),
                new Point3D(x + pointSize, y + pointSize, z + pointSize)
            };

            var mesh = new MeshGeometry3D
            {
                Positions = new Point3DCollection(_positions),
                TriangleIndices = new Int32Collection(_triangleIndices),
                TextureCoordinates = new PointCollection(_textureCoordinates),
                Normals = new Vector3DCollection(_normals)
            };

            return new GeometryModel3D(mesh, material);
        }
    }
}
