using System;

namespace Elements3D
{
    public class Vector3D : Point3D
    {
        public static Vector3D XAxis = new Vector3D(1, 0, 0);
        public static Vector3D YAxis = new Vector3D(0, 1, 0);
        public static Vector3D ZAxis = new Vector3D(0, 0, 1);

        public Vector3D():base()
        {
        }

        public Vector3D(Point3D pointA, Point3D pointB)
        {
            X = pointB.X - pointA.X;
            Y = pointB.Y - pointA.Y;
            Z = pointB.Z - pointA.Z;
        }

        public Vector3D(double x, double y, double z) : base(x,y,z)
        {
        }

        public double GetLength
        {
            get
            {
                return (double)Math.Sqrt(X * X + Y * Y + Z * Z);
            }
        }

        public double GetDotProdcut(Vector3D vector)
        {
            return X * vector.X + Y * vector.Y + Z * vector.Z;
        }

        public double GetAngleWith(Vector3D vector)
        { //Source: https://www.easycalculation.com/algebra/3dvector-angle.php
            return (Math.Acos((Math.Abs(X * vector.X) + Math.Abs(Y * vector.Y) + Math.Abs(Z * vector.Z)) / (Math.Sqrt((X * X) + (Y * Y) + (Z * Z)) * Math.Sqrt((vector.Y * vector.Y) + (vector.X * vector.X) + (vector.Z * vector.Z)))) * 360) / (Math.PI * 2);
        }

        public void Invert()
        {
            X = -X;
            Y = -Y;
            Z = -Z;
        }
    }
}