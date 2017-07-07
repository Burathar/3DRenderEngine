using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements3D
{
    public class CameraLens
    {
        public decimal FocalLength { get; set; }
        public decimal Aperture { get; set; }

        public CameraLens(decimal focalLength, decimal aperture)
        {
            FocalLength = focalLength;
            Aperture = aperture;
        }
    }
}