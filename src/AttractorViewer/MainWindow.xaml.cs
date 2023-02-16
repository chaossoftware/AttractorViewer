using AttractorViewer.ColorMaps;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AttractorViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const double Step = 5;
        double angleX, angleY, angleZ;
        private ModelVisual3D attractor;
        private Model3DGroup group;
        private Point3D centerPoint;

        private bool animated = false;

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

                angleX = 0;
                angleY = 0;
                angleZ = 0;

                animated = cboxAnimated.IsChecked.Value;

                AddAttractor();
                
                if (cboxTrajectory.IsChecked.Value)
                {
                    ConstructAttractorModelPath(reader.Points, reader.Multiplier);
                }
                else
                {
                    ConstructAttractorModel(reader.Points, reader.Multiplier);
                }

                group.Freeze();
            }
        }

        private void ConstructAttractorModel(HashSet<ColoredPoint3D> points, double multiplier)
        {
            double ptRadius = Convert.ToDouble(textPtRadius.Text, CultureInfo.InvariantCulture);

            var _cubesCreator = new SpheresCreator(ptRadius);

            var material = new DiffuseMaterial(Brushes.Black);
            var prevColor = System.Drawing.Color.Black;

            foreach (var point in points)
            {
                if (prevColor != point.PointColor)
                {
                    material = new DiffuseMaterial(new SolidColorBrush(Color.FromArgb(point.PointColor.A, point.PointColor.R, point.PointColor.G, point.PointColor.B)));
                    prevColor = point.PointColor;
                }
                
                var childModel = _cubesCreator.CreateModel(material);
                var transform = new Transform3DGroup();
                transform.Children.Add(new ScaleTransform3D(0.1, 0.1, 0.1));
                transform.Children.Add(new TranslateTransform3D(point.X * multiplier, point.Y * multiplier, point.Z * multiplier));
                childModel.Transform = transform;

                if (animated)
                {
                    group.Dispatcher.Invoke(DispatcherPriority.Render, new Action(() => group.Children.Add(childModel)));
                }
                else
                {
                    group.Children.Add(childModel);
                }
            }
        }

        private void ConstructAttractorModelPath(HashSet<ColoredPoint3D> points, double multiplier)
        {
            var _cubesCreator = new SegmentsCreator();
            
            bool firstPoint = true;
            Point3D previousPoint = new Point3D(0, 0, 0);

            var material = new DiffuseMaterial(Brushes.Black);
            var prevColor = System.Drawing.Color.Black;

            double thickness = Convert.ToDouble(textThickness.Text, CultureInfo.InvariantCulture);

            foreach (var point in points)
            { 
                var currentPoint = new Point3D(point.X * multiplier, point.Y * multiplier, point.Z * multiplier);

                if (!firstPoint)
                {
                    if (prevColor != point.PointColor)
                    {
                        material = new DiffuseMaterial(new SolidColorBrush(Color.FromArgb(point.PointColor.A, point.PointColor.R, point.PointColor.G, point.PointColor.B)));
                        prevColor = point.PointColor;
                    }

                    var childModel = _cubesCreator.CreateModel(material, previousPoint, currentPoint, thickness);

                    if (animated)
                    {
                        group.Dispatcher.Invoke(DispatcherPriority.Render, new Action(() => group.Children.Add(childModel)));
                    }
                    else
                    {
                        group.Children.Add(childModel);
                    }
                }
                else
                {
                    firstPoint = false;
                }

                previousPoint = currentPoint;
            }
        }

        public void AddAttractor()
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

            attractor = new ModelVisual3D();
            group = new Model3DGroup();
            attractor.Content = group;

            viewport.Children.Add(attractor);
        }

        private void viewport_MouseWheel(object sender, MouseWheelEventArgs e) =>
            Camera.Width -= (double)e.Delta / 20;

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
                    e.Handled = true;
                    break;
                case Key.Down:
                    angleY -= Step;
                    e.Handled = true;
                    break;
                case Key.Home:
                    angleZ += Step;
                    break;
                case Key.End:
                    angleZ -= Step;
                    break;
                default:
                    return;
            }

            PositionCamera(x, y, z);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) =>
                TakeScreenshot(viewport, 3000, 3000);

        private void PositionCamera(double x, double y, double z)
        {
            attractor.Transform = Modificator.GetRotation(new Point3D(angleX, angleY, angleZ), centerPoint);

            Point3D cameraPosition = new Point3D(
                Camera.Position.X + x,
                Camera.Position.Y + y,
                Camera.Position.Z + z);
            Camera.Position = cameraPosition;
        }

        private void TakeScreenshot(Viewport3D v, int width, int height)
        {
            var vRect = new Rectangle();
            vRect.Width = width;
            vRect.Height = height;
            vRect.Arrange(new Rect(0, 0, vRect.Width, vRect.Height));

            double dpi = 300d;

            var bmp = new RenderTargetBitmap(width, height, dpi, dpi, PixelFormats.Pbgra32);
            v.Dispatcher.Invoke(() => bmp.Render(v), DispatcherPriority.Render);
            bmp.Render(vRect);
            bmp.Render(v);

            var png = new PngBitmapEncoder();
            png.Frames.Add(BitmapFrame.Create(bmp));

            var dlg = new SaveFileDialog();
            dlg.DefaultExt = ".png";
            dlg.Filter = "PNG Images (.png)|*.png";

            if (dlg.ShowDialog() ?? false == true)
            {
                string filepath = dlg.FileName;
                using (var stm = File.Create(filepath))
                    png.Save(stm);
            }
        }
    }
}
