using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RenderEngine3D;

namespace _3DEngine
{
    public partial class Form1 : Form
    {
        Engine3D engine;
        public Form1()
        {
            engine = new Engine3D(new Size(0, 0));
            InitializeComponent();
        }

        private void picBoxCanvas_Paint(object sender, PaintEventArgs e)
        {
            engine.SetCanvasSize(picBoxCanvas.Size);
            engine.Draw(e.Graphics);
        }
    }
}
