using System;

namespace Elements3D
{
    public class Vector3D
    {
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

        public Vector3D(double angleX, double angleY, double angleZ, double length)
        {
            //Uitrekenen met poolcoordinaten of sinus(gebruikt in Perlin noise app?
        }

        public Vector3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public double GetAngleX
        {
            get
            {
                return Math.Atan2(Math.Sqrt(Y * Y + Z * Z), X);
            }
        }

        public double GetAngleY
        {
            get
            {
                return Math.Atan2(Math.Sqrt(Z * Z + X * X), Y);
            }
        }

        public double GetAngleZ
        {
            get
            {
                return Math.Atan2(Math.Sqrt(X * X + Y * Y), Z);
            }
        }

        public double GetLength
        {
            get
            {
                return (double)Math.Sqrt(X * X + Y * Y + Z * Z);
            }
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
            Point3D item = obj as Point3D;
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