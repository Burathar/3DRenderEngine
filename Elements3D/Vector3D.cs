using System;

namespace Elements3D
{
    public class Vector3D
    {
        public static Vector3D XAxis = new Vector3D(1, 0, 0);
        public static Vector3D YAxis = new Vector3D(0, 1, 0);
        public static Vector3D ZAxis = new Vector3D(0, 0, 1);

        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }

        public Vector3D()
        {
        }

        public Vector3D(Point3D pointA, Point3D pointB)
        {
            X = pointB.X - pointA.X;
            Y = pointB.Y - pointA.Y;
            Z = pointB.Z - pointA.Z;
        }

        public Vector3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
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

        public void Add(Vector3D vector)
        {
            this.X += vector.X;
            this.Y += vector.Y;
            this.Z += vector.Z;
        }

        public void Subtract(Vector3D vector)
        {
            this.X -= vector.X;
            this.Y -= vector.Y;
            this.Z -= vector.Z;
        }

        public void Multiply(Vector3D vector)
        {
            this.X *= vector.X;
            this.Y *= vector.Y;
            this.Z *= vector.Z;
        }

        public void Devide(Vector3D vector)
        {
            this.X /= vector.X;
            this.Y /= vector.Y;
            this.Z /= vector.Z;
        }

        public void Invert()
        {
            X = -X;
            Y = -Y;
            Z = -Z;
        }

        public override string ToString()
        {
            return $"({X.ToString("N")}, {Y.ToString("N")}, {Z.ToString("N")})";
        }

        public override bool Equals(object obj)
        {
            Vector3D item = obj as Vector3D;
            if (item == null)
            {
                return false;
            }

            bool areEqual = true;
            if (!X.Equals(item.X)) areEqual = false;
            if (!Y.Equals(item.Y)) areEqual = false;
            if (!Z.Equals(item.Z)) areEqual = false;
            return areEqual;
        }

        public override int GetHashCode()
        {
            return FNV_1a.CreateHash(X.GetHashCode(), Y.GetHashCode(), Z.GetHashCode());
        }
    }
}