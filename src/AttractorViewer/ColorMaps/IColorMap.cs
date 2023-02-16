using System.Drawing;

namespace AttractorViewer.ColorMaps;

public enum ColorMap
{
    Orange,
    Parula
}

public interface IColorMap
{
    Color GetColor(double value);
}
