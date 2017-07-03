﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elements3D;
using System.Drawing;

namespace RenderEngine3D
{
    public class Engine3D
    {
        private Size canvasSize;
        private Universe3D universe;
        public Engine3D(Size canvasSize)
        {
            this.canvasSize = canvasSize;
            Point3D cameraPosition = new Point3D(10, 5, -10);
            universe = new Universe3D(new Camera3D(cameraPosition, new Vector3D(cameraPosition, new Point3D(0,0,0))));
            MakePoints();
        }

        public void SetCanvasSize(Size size)
        {
            canvasSize = size;
        }

        private void MakePoints()
        {
            universe.AddEntity(new Point3D(0, 0, 0) as Entity3D);
        }

        public void Draw(Graphics g)
        {
            for(int y = 0; y < canvasSize.Height -1; y++)
            {
                double verticalAngle = universe.GetVerticalAngle((decimal)canvasSize.Height / (y + 1));
                for(int x = 0; x < canvasSize.Width -1; x++)
                {
                    double horizontalAngle = universe.GetHorizontalAngle((decimal)canvasSize.Width / (x + 1));
                    Color color = Color.Black;


                    
                    g.FillRectangle(new SolidBrush(color), x, y, 1, 1);
                }
            }
        }
    }
}