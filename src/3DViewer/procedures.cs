namespace viewer
{
    class procedures
    {
        //=============================Multipling matrixes====================

        public double[,] mult(double[,] A, double[,] B)
        {
            double[,] M = new double[4, 4];
            double s;

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    s = 0;
                    for (int x = 0; x < 4; x++)
                        s += A[i, x] * B[x, j];
                    M[i, j] = s;
                }
            return M;
        }

        //=============================Multipling matrix & row====================

        public Point3d multM(Point3d point_, double[,] Matrix)
        {
            Point3d point1 = new Point3d();
            double[] p = new double[4];
            double[] p1 = new double[4];

            p[0] = point_.X;
            p[1] = point_.Y;
            p[2] = point_.Z;
            p[3] = 1;

            p1[0] = p1[1] = p1[2] = p1[3] = 0;

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    p1[i] += p[j] * Matrix[j, i];


            point1.X = p1[0] / p1[3];
            point1.Y = p1[1] / p1[3];
            point1.Z = p1[2] / p1[3];

            return point1;
        }

    }
}
