using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements3D
{
    public class Vector3D
    {
        public float X { get; private set; }
        public float Y { get; private set; }
        public float Z { get; private set; }

        public Vector3D()
        {

        }

        public Vector3D(Point3D pointA, Point3D pointB)
        {
            X = pointB.X - pointA.X;
            Y = pointB.Y - pointA.Y;
            Z = pointB.Z - pointA.Z;
        }

        public Vector3D(float angleX, float angleY, float angleZ, float length)
        {
            //Uitrekenen met poolcoordinaten of sinus(gebruikt in Perlin noise app?
        }

        public Vector3D(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public float GetAngleX
        {
            get
            {
                return 0;//Uitrekenen met poolcoordinaten of sinus(gebruikt in Perlin noise app?
            }
        }

        public float GetAngleY
        {
            get
            {
                return 0;//Uitrekenen met poolcoordinaten of sinus(gebruikt in Perlin noise app?
            }
        }

        public float GetAngleZ
        {
            get
            {
                return 0;//Uitrekenen met poolcoordinaten of sinus(gebruikt in Perlin noise app?
            }
        }

        public float GetLength
        {
            get
            {
                return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
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
    }
}
