using System.Diagnostics;
using System.Windows.Forms;

namespace Aquila
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        Bitmap b;
        Graphics g;

        Bitmap b1;
        Graphics g1;

        Bitmap b2;
        Graphics g2;
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

        private void button1_Click(object sender, EventArgs e)
        {
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            int Points = (int)numericUpDown1.Value;
            int Distance = (int)numericUpDown2.Value;
            List<double> PuntiX = new List<double>();
            List<double> PuntiY = new List<double>();
            double minX = -100;
            double maxX = 100;
            double minY = -100;
            double maxY = 100;
            for (int i = 0; i < Points; i++)
            {
                double len = r.NextDouble() * Distance;
                double aa = r.Next(0, 360);
                double x = len * Math.Cos(aa);
                double y = len * Math.Sin(aa);
                int xDevice = FromXRealToXVirtual(x, minX, maxX, 0, pictureBox1.Width);
                int yDevice = FromYRealToYVirtual(y, minY, maxY, 0, pictureBox1.Height);
                Rectangle rect = new Rectangle(xDevice, yDevice, 1, 1);
                g.DrawRectangle(new Pen(Color.PeachPuff, 1), rect);
                PuntiX.Add(xDevice);
                PuntiY.Add(yDevice);
            }
            pictureBox1.Image = b;
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            b1 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            g1 = Graphics.FromImage(b1);
            g1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            double fra = PuntiX.Max();
            double valore = fra / 25;
            double da = 0;
            double a = valore;
            int lung = 0;
            List<double> Mannaggia = new List<double>();
            for (int i = 0; i < 25; i++)
            {
                foreach (double element in PuntiX)
                {
                    if (element > da & element < a)
                    {
                        lung++;
                    }
                }
                Mannaggia.Add(lung);
                lung = 0;
                da = a;
                a = a + valore;
            }
            Pen Pen = new Pen(Color.LimeGreen, 7);
            for (int i = 0; i < Mannaggia.Count; i++)
            {
                int dovefarlox = pictureBox2.Width * (i) / Mannaggia.Count  + 6;
                Point point1 = new Point(dovefarlox, pictureBox2.Height);
                float dovefarloy = (float)Mannaggia[i] / (float)ritorno(Mannaggia) * (float)pictureBox2.Height;
                Point point2 = new Point(dovefarlox, pictureBox2.Height - (int)dovefarloy);
                g1.DrawLine(Pen, point1, point2);
            }
            pictureBox2.Image = b1;

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            b2 = new Bitmap(pictureBox3.Width, pictureBox3.Height);
            g2 = Graphics.FromImage(b2);
            g2.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            fra = PuntiY.Max();
            valore = fra / 25;
            da = 0;
            a = valore;
            lung = 0;
            Mannaggia = new List<double>();
            for (int i = 0; i < 25; i++)
            {
                foreach (double element in PuntiY)
                {
                    if (element > da & element < a)
                    {
                        lung++;
                    }
                }
                Mannaggia.Add(lung);
                lung = 0;
                da = a;
                a = a + valore;
            }
            Pen = new Pen(Color.Purple, 7);
            for (int i = 0; i < Mannaggia.Count; i++)
            {
                int dovefarlox = pictureBox3.Width * (i) / Mannaggia.Count + 6;
                Point point1 = new Point(dovefarlox, pictureBox3.Height);
                float dovefarloy = (float)Mannaggia[i] / (float)ritorno(Mannaggia) * (float)pictureBox3.Height;
                Point point2 = new Point(dovefarlox, pictureBox3.Height - (int)dovefarloy);
                g2.DrawLine(Pen, point1, point2);
            }
            pictureBox3.Image = b2;
        }
            
    }
}