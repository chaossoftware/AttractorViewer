using ChaosSoft.Core.DrawEngine.Charts.ColorMaps;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Media.Media3D;

namespace AttractorViewer
{
    public class PointsReader
    {
        private readonly ColorMap _color;

        public PointsReader(ColorMap color)
        {
            _color = color;
        }

        public HashSet<ColoredPoint3D> Points { get; protected set; }

        public Point3D CenterPoint { get; protected set; }

        public double Multiplier { get; set; }

        public void ReadFile(string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            IColorMap colorMap;

            if (_color.Equals(ColorMap.Orange))
            {
                colorMap = new OrangeColorMap(0, lines.Length - 1);
            }
            else 
            {
                colorMap = new ParulaColorMap(0, lines.Length - 1);
            }

            Points = new HashSet<ColoredPoint3D>();

            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(' ', '\n', '\r');

                var pt = new ColoredPoint3D()
                {
                    X = double.Parse(parts[0], System.Globalization.CultureInfo.InvariantCulture),
                    Y = double.Parse(parts[1], System.Globalization.CultureInfo.InvariantCulture),
                    Z = double.Parse(parts[2], System.Globalization.CultureInfo.InvariantCulture),
                    PointColor = colorMap.GetColor(i)
                };

                Points.Add(pt);
            }

            double xMin = Points.Min(p => p.X);
            double yMin = Points.Min(p => p.Y);
            double zMin = Points.Min(p => p.Z);
            double xMax = Points.Max(p => p.X);
            double yMax = Points.Max(p => p.Y);
            double zMax = Points.Max(p => p.Z);

            var xAmplitude = xMax - xMin;
            var yAmplitude = yMax - yMin;
            var zAmplitude = zMax - zMin;

            var maxAmplitude = Math.Max(Math.Max(xAmplitude, yAmplitude), zAmplitude);

            Multiplier =  35 / maxAmplitude;
            CenterPoint = new Point3D((xMin + xAmplitude / 2) * Multiplier, (yMin + yAmplitude / 2) * Multiplier, (zMin + xAmplitude / 2) * Multiplier);
        }
    }
}
