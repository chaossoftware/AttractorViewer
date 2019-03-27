using System;
using System.Drawing;

namespace viewer
{
    public class View3D
    {
        public int M = 200;
        public ColoredPoint3D[] points;
        public PointsReader reader;

        private double[,] Matrix, M_shift, M_rotX, M_rotY, M_rotZ, M_scale, M_screen, M_shiftF;

        public View3D(Size viewpointSize)
        {
            Matrix = new double[4, 4] 
            {
                {1, 0, 0, 0},
                {0, 1, 0, 0},
                {0, 0, 1, 0},
                {0, 0, 0, 1}
            };

            M_shift = new double[4, 4];
            Array.Copy(Matrix, M_shift, Matrix.Length);

            M_shiftF = new double[4, 4];
            Array.Copy(Matrix, M_shiftF, Matrix.Length);

            M_scale = new double[4, 4];
            Array.Copy(Matrix, M_scale, Matrix.Length);

            M_rotX = new double[4, 4];
            Array.Copy(Matrix, M_rotX, Matrix.Length);

            M_rotY = new double[4, 4];
            Array.Copy(Matrix, M_rotY, Matrix.Length);

            M_rotZ = new double[4, 4];
            Array.Copy(Matrix, M_rotZ, Matrix.Length);

            M_screen = new double[4, 4];
            Array.Copy(Matrix, M_screen, Matrix.Length);

            M_screen[2, 0] = (double)viewpointSize.Width / 2d;
            M_screen[2, 1] = (double)viewpointSize.Height / 2d;
        }

        public void Initialize(double Distance, double numShiftX, double numShiftY, double numShiftZ, double angleX, double angleY, double angleZ, double scaleX, double scaleY, double scaleZ)
        {
            ////Array.Clear(points, 0, points.Length);

            double shiftX, shiftY, shiftZ;
            double cos, sin;

            shiftX = -1 * numShiftX;
            shiftY = -1 * numShiftY;
            shiftZ = -1 * numShiftZ;

            Matrix = new double[4, 4]
            {
                {1, 0, 0, 0},
                {0, 1, 0, 0},
                {0, 0, 1, 0},
                {0, 0, 0, 1}
            };

            M_shift[0, 3] = shiftX;
            M_shift[1, 3] = shiftY;
            M_shift[2, 3] = shiftZ;

            M_shiftF[3, 2] = Distance;

            M_scale[0, 0] = scaleX;
            M_scale[1, 1] = scaleY;
            M_scale[2, 2] = scaleZ;
            

            cos = Math.Cos(angleX);
            sin = Math.Sin(angleX);

            M_rotX[1, 1] = cos;
            M_rotX[1, 2] = -1 * sin;
            M_rotX[2, 1] = sin;
            M_rotX[2, 2] = cos;

            cos = Math.Cos(angleY);
            sin = Math.Sin(angleY);

            M_rotY[0, 0] = cos;
            M_rotY[0, 2] = sin;
            M_rotY[2, 0] = -1 * sin;
            M_rotY[2, 2] = cos;

            cos = Math.Cos(angleZ);
            sin = Math.Sin(angleZ);

            M_rotZ[0, 0] = cos;
            M_rotZ[0, 1] = -1 * sin;
            M_rotZ[1, 0] = sin;
            M_rotZ[1, 1] = cos;

            M_screen[0, 0] = M;
            M_screen[1, 1] = -1 * M;
            M_screen[2, 2] = M;
            M_screen[2, 3] = 1;
            M_screen[3, 3] = 0;

            Matrix = Mult(Matrix, M_rotX);
            Matrix = Mult(Matrix, M_rotY);
            Matrix = Mult(Matrix, M_rotZ);
            Matrix = Mult(Matrix, M_shiftF);

            Matrix = Mult(Matrix, M_scale);
            Matrix = Mult(Matrix, M_shift);
            Matrix = Mult(Matrix, M_screen);

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = MultM(reader.Points[i], Matrix);
            }
        }

        public void Read(string fileName)
        {
            reader = new PointsReader();
            reader.ReadFile(fileName);
            points = new ColoredPoint3D[reader.Points.Length];
        }

        //=============================Multipling matrixes====================

        private double[,] Mult(double[,] A, double[,] B)
        {
            double[,] m = new double[4, 4];
            double s;

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    s = 0;
                    for (int x = 0; x < 4; x++)
                        s += A[i, x] * B[x, j];
                    m[i, j] = s;
                }
            return m;
        }

        //=============================Multipling matrix & row====================

        private ColoredPoint3D MultM(ColoredPoint3D sourcePoint, double[,] Matrix)
        {
            var resultPoint = new ColoredPoint3D()
            {
                PointColor = sourcePoint.PointColor
            };

            double[] sp = new double[] { sourcePoint.X, sourcePoint.Y, sourcePoint.Z, 1 };
            double[] rp = new double[] { 0, 0, 0, 0};

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    rp[i] += sp[j] * Matrix[j, i];
                }
            }

            resultPoint.X = rp[0] / rp[3];
            resultPoint.Y = rp[1] / rp[3];
            resultPoint.Z = rp[2] / rp[3];

            return resultPoint;
        }
    }
    
    
    ////Matrix = new double[4, 4] {
				////{1,0,0,0},
				////{0,1,0,0},
				////{0,0,1,0},
				////{0,0,0,1}};

    ////        M_shift = new double[4, 4] {
				////{1, 0, 0, 0},
				////{0, 1, 0, 0},
				////{0, 0, 1, 0},
				////{shiftX, shiftY, shiftZ, 1}};

    ////        M_shiftF = new double[4, 4] {
				////{1, 0, 0, 0},
				////{0, 1, 0, 0},
				////{0, 0, 1, 0},
				////{0, 0, d, 1}};

    ////        M_scale = new double[4, 4] {
				////{scaleX,0,0,0},
				////{0,scaleY,0,0},
				////{0,0,scaleZ,0},
				////{0,0,0,1}};

    ////        M_rotX = new double[4, 4] {
				////{1,0,0,0},
				////{0,(float)Math.Cos(angleX),-1*(float)Math.Sin(angleX),0},
				////{0,(float)Math.Sin(angleX),(float)Math.Cos(angleX),0},
				////{0,0,0,1}};

    ////        M_rotY = new double[4, 4] {
				////{(float)Math.Cos(angleY),0,(float)Math.Sin(angleY),0},
				////{0,1,0,0},
				////{-1*(float)Math.Sin(angleY),0,(float)Math.Cos(angleY),0},
				////{0,0,0,1}};

    ////        M_rotZ = new double[4, 4] {
				////{Math.Cos(angleZ),-1*Math.Sin(angleZ),0,0},
				////{Math.Sin(angleZ),Math.Cos(angleZ),0,0},
				////{0,0,1,0},
				////{0,0,0,1}};

    ////        M_screen = new double[4, 4] {
				////{M,0,0,0},
				////{0,-1*M,0,0},
				////{pictureBox.Width/2,pictureBox.Height/2,M,1},
				////{0,0,0,0}}; 
     
}
