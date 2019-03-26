using System.Collections.Generic;
using System.IO;
using MathLib.DrawEngine.Charts.ColorMaps;

namespace viewer
{
    public class PointsReader
    {
        public ColoredPoint3D[] Points { get; protected set; }

        public void ReadFile(string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            var colorMap = new ParulaColorMap(0, lines.Length - 1);
            var set = new HashSet<ColoredPoint3D>();

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

                set.Add(pt);
            }

            Points = new ColoredPoint3D[set.Count];
            set.CopyTo(Points);
        }
    }
}
