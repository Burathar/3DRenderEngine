using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elements3D;

namespace RenderEngine3D
{
    class Ray
    {
        public Point3D StartPoint { get; set; }
        public Vector3D Vector { get; set; }
        public Ray NextRay { get; set; }
        public Ray PreviousRay { get; }

        public Ray()
        {

        }

        public Ray(Ray previousRay)
        {
            this.PreviousRay = previousRay;
            StartPoint = previousRay.StartPoint;
            StartPoint.Add(previousRay.Vector);
        }

        public Ray(Point3D startPoint)
        {
            this.StartPoint = startPoint;
        }
    }
}
