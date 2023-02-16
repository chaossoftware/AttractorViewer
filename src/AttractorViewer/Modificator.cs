using System.Windows.Media.Media3D;

namespace AttractorViewer;

public class Modificator
{
    private readonly Transform3DGroup _transformGroup;

    public Modificator()
    {
        _transformGroup = new Transform3DGroup();
    }

    public Modificator Scale(double scaleX, double scaleY, double scaleZ)
    {
        var scaleTransform = new ScaleTransform3D
        {
            ScaleX = scaleX,
            ScaleY = scaleY,
            ScaleZ = scaleZ
        };

        _transformGroup.Children.Add(scaleTransform);

        return this;
    }

    public Modificator Move(double x, double y, double z)
    {
        var translateTransform = new TranslateTransform3D
        {
            OffsetX = x,
            OffsetY = y,
            OffsetZ = z
        };

        _transformGroup.Children.Add(translateTransform);

        return this;
    }

    public Modificator Rotate(Vector3D axis, double angle, Point3D center)
    {
        var rotateTransform = new RotateTransform3D
        {
            Rotation = new AxisAngleRotation3D
            {
                Axis = axis,
                Angle = angle
            },
            CenterX = center.X,
            CenterY = center.Y,
            CenterZ = center.Z
        };

        _transformGroup.Children.Add(rotateTransform);

        return this;
    }

    public void ApplyTo(ModelVisual3D model) =>
        model.Transform = _transformGroup;

    public static RotateTransform3D GetRotation(Vector3D axis, double angle, Point3D center)
    {
        var rotateTransform = new RotateTransform3D
        {
            Rotation = new AxisAngleRotation3D
            {
                Axis = axis,
                Angle = angle
            },
            CenterX = center.X,
            CenterY = center.Y,
            CenterZ = center.Z
        };

        return rotateTransform;
    }

    public static Transform3DGroup GetRotation(Point3D angles, Point3D center)
    {
        var rotations = new Transform3DGroup();

        var rotateX = new RotateTransform3D
        {
            Rotation = new AxisAngleRotation3D
            {
                Axis = new Vector3D(1, 0, 0),
                Angle = angles.X,
            },
            CenterX = center.X,
            CenterY = center.Y,
            CenterZ = center.Z
        };

        var rotateY = new RotateTransform3D
        {
            Rotation = new AxisAngleRotation3D
            {
                Axis = new Vector3D(0, 1, 0),
                Angle = angles.Y,
            },
            CenterX = center.X,
            CenterY = center.Y,
            CenterZ = center.Z
        };

        var rotateZ = new RotateTransform3D
        {
            Rotation = new AxisAngleRotation3D
            {
                Axis = new Vector3D(0, 0, 1),
                Angle = angles.Z,
            },
            CenterX = center.X,
            CenterY = center.Y,
            CenterZ = center.Z
        };

        rotations.Children.Add(rotateX);
        rotations.Children.Add(rotateY);
        rotations.Children.Add(rotateZ);

        return rotations;
    }
}
