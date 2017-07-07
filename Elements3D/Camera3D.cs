using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Elements3D
{
    public class Camera3D
    {
        public Point3D Position { get; set; }
        public Vector3D Direction { get; set; }
        public CameraLens Lens { get; set; }

        public double ViewAngleHorizontal { get; private set; }
        public double ViewAngleVertical { get; private set; }

        /// <summary>
        /// Apect ratio(x:y) in 1:value. 3:2 becomes 1:.667
        /// </summary>
        public decimal SensorShape { get; set; }

        /// <summary>
        /// The amount of degrees the camera is rolled over its axis clockwise in the direction of the camera.
        /// </summary>
        /// <remarks>
        /// 0 degrees means the camera is upright.
        /// 180 degrees means the camera is upside down
        /// </remarks>
        public double Roll { get; set; }

        public double GetHorizontalAngle(double relativeWidth)
        {
            return ViewAngleHorizontal * relativeWidth;
        }

        public double GetVerticalAngle(double relativeHeight)
        {
            return ViewAngleVertical * relativeHeight;
        }

        public Camera3D()
        {
            ViewAngleHorizontal = 20;
            Roll = 0;
        }

        public Camera3D(Point3D position, Vector3D direction) : base()
        {
            this.Position = position;
            this.Direction = direction;
        }

        public Camera3D(Point3D position, Vector3D direction, Vector3D up)
        {
            this.Position = position;
            this.Direction = direction;
        }

        /*
        private Vector3D up;

        /// <summary>
        /// The <see cref="Vector3D">Vector</see> that indicates in what direction the <see cref="Camera3D">Camera</see> is rolled. This Vector has to be perpendicular to the <see cref="Direction"/> Vector.
        /// </summary>
        public Vector3D Up
        {
            get
            {
                return up;
            }
            set
            {
                if (value.GetLength != 0 && Direction.GetDotProdcut(value) == 0)
                    up = value;
                else
                    throw new CameraUpVectorException("The given vector is not perpendicular to the camera's direction vector.");
            }
        }
        */
    }
}