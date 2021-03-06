﻿using Elements3D;
using System.Drawing;

namespace RayTracer
{
    public class RayTracer
    {
        private Size canvasSize;
        private Universe3D universe;

        public RayTracer(Size canvasSize)
        {
            this.canvasSize = canvasSize;
            Point3D cameraPosition = new Point3D(10, 5, -10);
            universe = new Universe3D(new Camera3D(cameraPosition, new Vector3D(cameraPosition, new Point3D(0, 0, 0))));
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
            for (int y = 0; y < canvasSize.Height - 1; y++)
            {
                double verticalAngle = universe.GetVerticalAngle((y + 1) / (double)canvasSize.Height);
                for (int x = 0; x < canvasSize.Width - 1; x++)
                {
                    double horizontalAngle = universe.GetHorizontalAngle((x + 1) / (double)canvasSize.Width);
                    DrawPixel(g, x, y, horizontalAngle, verticalAngle);
                }
            }
        }

        private void DrawPixel(Graphics g, int x, int y, double horizontalAngle, double VerticalAngle)
        {
            Color color = Color.Black;
            //color = universe.
            g.FillRectangle(new SolidBrush(color), x, y, 1, 1);
        }
    }
}