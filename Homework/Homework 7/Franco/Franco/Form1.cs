using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Franco
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        Graphics g;
        Bitmap b;
        Graphics g2;
        Bitmap b2;

        public Form1()
        {
            InitializeComponent();
        }

        private int FromXRealToXVirtual(double X, double minX, double maxX, int Left, int W)
        {
            return (int)(Left + W * (X - minX) / (maxX - minX));
        }
        private int FromYRealToYVirtual(double Y, double minY, double maxY, int Top, int H)
        {
            return (int)(Top + H - H * (Y - minY) / (maxY - minY));
        }
        public int ritorno(List<int> india)
        {
            if (india.Max() == 0)
            {
                return india.Count;
            }
            else
            {
                return india.Max();
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            int trials = (int)numericUpDown1.Value;
            int lambda = (int)numericUpDown2.Value;
            double Y = 0;
            Pen PenTrajectory = new Pen(Color.LimeGreen, 1);
            List<Point> Punti = new List<Point>();
            List<int> fraffo = new List<int>();
            int counter = 0;
            bool prova = false;
            for (int X = 0; X <= trials; X++)
            {
                double val = r.NextDouble();
                
                if (val <= (float)((float)lambda/(float)trials))
                {
                    fraffo.Add(counter);
                    counter = 0;
                    prova = true;
                    Y = Y + 1;
                }
                if (prova == false)
                {
                    counter += 1;
                }
                else
                {
                    counter = 0;
                    prova = false;
                }
                int xDevice = FromXRealToXVirtual(X, 0, trials, 0, pictureBox1.Width);
                int yDevice = FromYRealToYVirtual(Y, 0, trials, 0, pictureBox1.Height);
                Punti.Add(new Point(xDevice, yDevice));
            }
            g.DrawLines(PenTrajectory, Punti.ToArray());
            pictureBox1.Image = b;

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            b2 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            g2 = Graphics.FromImage(b2);
            g2.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            int Penna = 0;
            if (trials < 20)
            {
                Penna = 20;
            }
            else if (trials < 100)
            {
                Penna = 5;
            }
            else if (trials < 200)
            {
                Penna = 3;
            }
            else
            {
                Penna = 1;
            }    
            Pen Pen = new Pen(Color.LimeGreen, Penna);
            for (int i = 0; i < fraffo.Count; i++)
            {
                int dovefarlox = pictureBox2.Width * i / fraffo.Count;
                Point point1 = new Point(dovefarlox, pictureBox2.Height);
                float dovefarloy = (float)fraffo[i] / (float)ritorno(fraffo) * (float)pictureBox2.Height;
                Point point2 = new Point(dovefarlox, pictureBox2.Height - (int)dovefarloy);
                g2.DrawLine(Pen, point1, point2);
            }
            pictureBox2.Image = b2;
        }
    }
}