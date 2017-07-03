using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements3D
{
    public class Point3D : Entity3D
    { 
        public float X { get; private set; }
        public float Y { get; private set; }
        public float Z { get; private set; }

        public Point3D(float x, float y, float z)
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
            if(item == null)
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
        {//https://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode
            unchecked // Overflow is fine, just wrap
            {
                int hash = (int)2166136261;
                // Suitable nullity checks etc, of course :)
                hash = (hash * 16777619) ^ X.GetHashCode();
                hash = (hash * 16777619) ^ Y.GetHashCode();
                hash = (hash * 16777619) ^ Z.GetHashCode();
                return hash;
            }
        }
    }
}
