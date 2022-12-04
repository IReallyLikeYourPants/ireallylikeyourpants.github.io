using System;
using System.Diagnostics;

namespace PortoCervo
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        Graphics g;
        Bitmap b;
        Graphics g1;
        Bitmap b1;
        private int FromXRealToXVirtual(double X, double minX, double maxX, int Left, int W)
        {
            return (int)(Left + W * (X - minX) / (maxX - minX));
        }
        private int FromYRealToYVirtual(double Y, double minY, double maxY, int Top, int H)
        {
            return (int)(Top + H - H * (Y - minY) / (maxY - minY));
        }

        public double ritorno(List<double> india)
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

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            int Trials = (int)numericUpDown1.Value;
            int NumberOfTrajectories = (int)numericUpDown2.Value;
            double Probability = 0.5;
            double minX = 0;
            double maxX = Trials;
            double minY = 0;
            double maxY = Trials;
            Rectangle Window = new Rectangle(0, 0, b.Width - 1, b.Height - 1);
            g.DrawRectangle(Pens.Black, Window);
            List<int> EndY = new List<int>();
            for (int i = 0; i < NumberOfTrajectories; i++)
            {
                Random rnd = new Random();
                Color randomColor = Color.FromArgb(rnd.Next(200), rnd.Next(200), rnd.Next(200));
                Pen PenTrajectory = new Pen(randomColor, 2);
                List<Point> Punti = new List<Point>();
                double Y = maxY / 2;
                for (int x = 0; x <= Trials; x++)
                {
                    double coin = r.NextDouble();
                    if (coin <= Probability)
                    {
                        Y = Y + 1;
                    }
                    else
                    {
                        Y = Y - 1;
                    }
                    if (x == 0)
                    {
                        Y = maxY / 2;
                    }    
                    int xDevice = FromXRealToXVirtual(x, minX, maxX, Window.Left, Window.Width);
                    int yDevice = FromYRealToYVirtual(Y, minY, maxY, Window.Top, Window.Height);
                    if (x == Trials)
                    {
                        EndY.Add(yDevice);
                    }
                    Punti.Add(new Point(xDevice, yDevice));
                }
                g.DrawLines(PenTrajectory, Punti.ToArray());
            }
            g.DrawLine(new Pen(Color.Red, 2), new Point(0, b.Height / 2), new Point(b.Width, b.Height / 2));
            pictureBox1.Image = b;

            /////////////////////////////////////////////////////////////////////////////////////////

            b1 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            g1 = Graphics.FromImage(b1);
            g1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            double delta = b.Height;
            int quanti = 500;
            double intervalli = delta / quanti;
            double da = 0;
            double a = 0 + intervalli;
            int lung = 0;
            List<double> Mannaggia = new List<double>();
            for (int i = 0; i < quanti; i++)
            {
                foreach (double element in EndY)
                {
                    if (element > da & element < a)
                    {
                        lung++;
                    }
                }
                Mannaggia.Add(lung);
                lung = 0;
                da = a;
                a = a + intervalli;
            }

            Pen Pen = new Pen(Color.Red, 1);
            for (int i = 0; i < Mannaggia.Count; i++)
            {
                int dovefarloy = pictureBox2.Height * (i) / quanti;
                float dovefarlox = (float)Mannaggia[i] / (float)ritorno(Mannaggia) * (float)pictureBox2.Width;
                Point point1 = new Point(0, dovefarloy);
                Point point2 = new Point((int)dovefarlox, dovefarloy);
                g1.DrawLine(Pen, point1, point2);
            }
            pictureBox2.Image = b1;
        }
    }
}