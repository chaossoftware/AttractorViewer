﻿using ChaosSoft.Core.DrawEngine.Charts.ColorMaps;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace AttractorViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const double Step = 10;
        double angleX, angleY, angleZ;
        private ModelVisual3D attractor;
        private Point3D centerPoint;

        public MainWindow()
        {
            InitializeComponent();

            foreach (var type in typeof(ColorMap).GetEnumValues())
            {
                comboColorMap.Items.Add(type);
            }

            comboColorMap.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog
            { 
                Filter = "3D attractor models|*.3da|All files|*.*" 
            };

            if (dlg.ShowDialog().Value)
            {
                var reader = new PointsReader((ColorMap)comboColorMap.SelectedItem);
                reader.ReadFile(dlg.FileName);
                centerPoint = reader.CenterPoint;

                if (cboxTrajectory.IsChecked.Value)
                {
                    ConstructAttractorModelPath(reader.Points, reader.Multiplier);
                }
                else
                {
                    ConstructAttractorModel(reader.Points, reader.Multiplier);
                }

                DrawAttractor();

                angleX = 0;
                angleY = 0;
                angleZ = 0;
            }
        }

        private void ConstructAttractorModel(HashSet<ColoredPoint3D> points, double multiplier)
        {
            var _cubesCreator = new SpheresCreator();

            attractor = new ModelVisual3D();
            var group = new Model3DGroup();

            foreach (var point in points)
            {
                var material = new DiffuseMaterial(new SolidColorBrush(Color.FromArgb(point.PointColor.A, point.PointColor.R, point.PointColor.G, point.PointColor.B)));
                var childModel = _cubesCreator.CreateModel(material);
                var transform = new Transform3DGroup();
                transform.Children.Add(new ScaleTransform3D(0.1, 0.1, 0.1));
                transform.Children.Add(new TranslateTransform3D(point.X * multiplier, point.Y * multiplier, point.Z * multiplier));
                childModel.Transform = transform;
                group.Children.Add(childModel);
            }

            group.Freeze();
            attractor.Content = group;
        }

        private void ConstructAttractorModelPath(HashSet<ColoredPoint3D> points, double multiplier)
        {
            var _cubesCreator = new SegmentsCreator();

            attractor = new ModelVisual3D();
            var group = new Model3DGroup();

            bool firstPoint = true;
            Point3D previousPoint = new Point3D(0, 0, 0);

            foreach (var point in points)
            { 
                var currentPoint = new Point3D(point.X * multiplier, point.Y * multiplier, point.Z * multiplier);

                if (!firstPoint)
                {
                    var material = new DiffuseMaterial(new SolidColorBrush(Color.FromArgb(point.PointColor.A, point.PointColor.R, point.PointColor.G, point.PointColor.B)));
                    var childModel = _cubesCreator.CreateModel(material, previousPoint, currentPoint, 0.03);
                    group.Children.Add(childModel);
                }
                else
                {
                    firstPoint = false;
                }

                previousPoint = currentPoint;
            }

            group.Freeze();
            attractor.Content = group;
        }

        public void DrawAttractor()
        {
            viewport.Children.Clear();

            var _ambientLight = new ModelUIElement3D
            {
                Model = new AmbientLight(Color.FromArgb(255, 200, 200, 200))
            };

            var _directionalLight = new ModelUIElement3D
            {
                Model = new DirectionalLight(Color.FromArgb(255, 200, 200, 200), new Vector3D(-1, -1, -2))
            };

            viewport.Children.Add(_ambientLight);
            viewport.Children.Add(_directionalLight);

            viewport.Children.Add(attractor);
        }

        private void viewport_MouseWheel(object sender, MouseWheelEventArgs e) =>
            Camera.Width -= (double)e.Delta / 10;

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // Scrolling by moving the 3D camera
            double x = 0;
            double y = 0;
            double z = 0;

            switch(e.Key)
            {
                case Key.D:
                    x = -Step;
                    y = Step;
                    break;
                case Key.S:
                    x = Step;
                    y = Step;
                    break;
                case Key.A:
                    x = Step;
                    y = -Step;
                    break;
                case Key.W:
                    x = -Step;
                    y = -Step;
                    break;
                case Key.Z:
                    z = Step;
                    x = -Step;
                    y = -Step;
                    break;
                case Key.X:
                    z = -Step;
                    y = Step;
                    x = Step;
                    break;
                case Key.Left:
                    angleX -= Step;
                    break;
                case Key.Right:
                    angleX += Step;
                    break;
                case Key.Up:
                    angleY += Step;
                    break;
                case Key.Down:
                    angleY -= Step;
                    break;
                case Key.Home:
                    angleZ += Step;
                    break;
                case Key.End:
                    angleZ -= Step;
                    break;
                default:
                    break;
            }

            attractor.Transform = Modificator.GetRotation(new Point3D(angleX, angleY, angleZ), centerPoint);

            Point3D cameraPosition = new Point3D(
                Camera.Position.X + x,
                Camera.Position.Y + y,
                Camera.Position.Z + z);
            Camera.Position = cameraPosition;
        }
    }
}
