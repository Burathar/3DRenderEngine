using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements3D
{
    public class Camera3D
    {
        public Point3D Position { get; set; }
        public Vector3D Direction { get; set; }
        /// <summary>
        /// The total angle that the camera can see.
        /// </summary>
        public float LensAngle { get; set; } //moet nog berekening in komen met Focal length of the lens of the camera in mm.
        private Vector3D up;//Naam van een vector die loodrecht op vector x staat
        public Vector3D Up
        {//Naam van een vector die loodrecht op vector x staat
            get
            {
                return up;
            }
            set
            {
                up = value;
                //Check if up is perpendicular
            }
        }

        public double GetHorizontalAngle(decimal relativeWidth)
        {
            throw new NotImplementedException();
        }

        public double GetVerticalAngle(decimal relativeHeight)
        {
            throw new NotImplementedException();
        }

        public Camera3D()
        {
            LensAngle = 20;
        }

        public Camera3D(Point3D position, Vector3D direction)
        {
            this.Position = position;
            this.Direction = direction;
            this.Up = new Vector3D(0, 1, 0);
            LensAngle = 20;
        }

        public Camera3D(Point3D position, Vector3D direction, Vector3D up)
        {
            this.Position = position;
            this.Direction = direction;
            this.Up = up;
            LensAngle = 20;
        }
    }
}
