using System.Windows.Media.Media3D;

namespace AttractorViewer;

public interface IModelCreator
{
    ModelVisual3D CreateModel(Material material);
}
