using RenderEngine3D;
using System.Drawing;
using System.Windows.Forms;

namespace _3DEngine
{
    public partial class Form1 : Form
    {
        private Engine3D engine;

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

        private void Form1_Load(object sender, System.EventArgs e)
        {
        }
    }
}