using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements3D
{
    public class Universe3D
    {
        private Camera3D camera;
        private List<Entity3D> entities;

        public Universe3D(Camera3D camera)
        {
            entities = new List<Entity3D>();
            this.camera = camera;
        }

        public void AddEntity(params Entity3D[] entities)
        {
            this.entities.AddRange(entities);
        }

        public double GetVerticalAngle(decimal relativeHeight)
        {
            return camera.GetVerticalAngle(relativeHeight);
        }

        public double GetHorizontalAngle(decimal relativeWidth)
        {
            return camera.GetHorizontalAngle(relativeWidth);
        }
    }
}
