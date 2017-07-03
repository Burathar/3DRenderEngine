namespace Elements3D
{
    public class Point3D : Entity3D
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point3D()
        {
        }

        public void Add(Point3D point)
        {
            this.X += point.X;
            this.Y += point.Y;
            this.Z += point.Z;
        }

        public void Subtract(Point3D point)
        {
            this.X -= point.X;
            this.Y -= point.Y;
            this.Z -= point.Z;
        }

        public void Multiply(Point3D point)
        {
            this.X *= point.X;
            this.Y *= point.Y;
            this.Z *= point.Z;
        }

        public void Devide(Point3D point)
        {
            this.X /= point.X;
            this.Y /= point.Y;
            this.Z /= point.Z;
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