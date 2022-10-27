using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace HW4
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        Graphics g;
        Bitmap b;
        Graphics gIsto;
        Bitmap bIsto;
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
        private void button2_Click(object sender, EventArgs e)
        {
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            int Trials = (int)numericUpDown2.Value;
            int NumberOfTrajectories = (int)numericUpDown3.Value;
            double Probability = ((Convert.ToDouble(numericUpDown1.Value)) / 100);
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
                double Y = 0;
                for (int x = 0; x <= Trials; x++)
                {
                    double coin = r.NextDouble();
                    if (coin <= Probability)
                    {
                        Y = Y + 1;
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
            pictureBox1.Image = b;
            bIsto = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            gIsto = Graphics.FromImage(bIsto);
            gIsto.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Dictionary<double, int> magia = new Dictionary<double, int>();
            double beginning = 2.5;
            double inter = beginning;
            while (inter <= bIsto.Height)
            {
                magia[inter] = 0;
                inter = inter + (beginning * 2);
            }
            foreach (int agaga in EndY)
            {
                foreach (double chiave in magia.Keys)
                {
                    if (agaga >= chiave - beginning && agaga < chiave + beginning)
                    {
                        magia[chiave] += 1;
                    }
                }
            }
            int massimo = 0;
            foreach (double chiave in magia.Keys)
            {
                massimo += magia[chiave];
            }
            int intervalli = 0;
            foreach (double chiave in magia.Keys)
            {
                Rectangle Window1 = new Rectangle(0, 5 * intervalli,  bIsto.Width / massimo * magia[chiave], (int)beginning * 2);
                intervalli++;
                gIsto.DrawRectangle(Pens.Black, Window1);
                gIsto.FillRectangle(Brushes.MistyRose, Window1);
            }
           pictureBox2.Image = bIsto;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            List<int> EndY = new List<int>();
            int Trials = (int)numericUpDown2.Value;
            int NumberOfTrajectories = (int)numericUpDown3.Value;
            double Probability = ((Convert.ToDouble(numericUpDown1.Value)) / 100);
            Rectangle Window = new Rectangle(0, 0, b.Width - 1, b.Height - 1);
            double minX = 0;
            double maxX = Trials;
            double minY = 0;
            double maxY = Trials;
            for (int i = 0; i < NumberOfTrajectories; i++)
            {
                List<Point> Punti = new List<Point>();
                Random rnd = new Random();
                Color randomColor = Color.FromArgb(rnd.Next(200), rnd.Next(200), rnd.Next(200));
                Pen PenTrajectory = new Pen(randomColor, 2);
                double Y = 0;
                for (int x = 0; x <= Trials; x++)
                {
                    double coin = r.NextDouble();
                    if (coin <= Probability)
                    {
                        Y = Y + 1;
                    }
                    double yRelative = Y * Trials / (x + 1);
                    int xDevice = FromXRealToXVirtual(x, minX, maxX, Window.Left, Window.Width);
                    int yDevice = FromYRealToYVirtual(yRelative, minY, maxY, Window.Top, Window.Height);
                    if (x == Trials)
                    {
                        EndY.Add(yDevice);
                    }
                    Punti.Add(new Point(xDevice, yDevice));
                }
                g.DrawLines(PenTrajectory, Punti.ToArray());
            }
            pictureBox1.Image = b;
            bIsto = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            gIsto = Graphics.FromImage(bIsto);
            gIsto.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Dictionary<double, int> magia = new Dictionary<double, int>();
            double beginning = 2.5;
            double inter = beginning;
            //Debug.WriteLine();
            while (inter <= bIsto.Height)
            {
                magia[inter] = 0;
                inter += (beginning * 2);
            }
            foreach (int agaga in EndY)
            {
                foreach (double chiave in magia.Keys)
                {
                    if (agaga >= chiave - beginning && agaga < chiave + beginning)
                    {
                        magia[chiave] += 1;
                    }
                }
            }
            int massimo = 0;
            foreach (double chiave in magia.Keys)
            {
                massimo += magia[chiave];
            }
            int intervalli = 0;
            foreach (double chiave in magia.Keys)
            {
                Rectangle Window1 = new Rectangle(0, 5 * intervalli,  bIsto.Width / massimo * magia[chiave] , (int)beginning * 2);
                intervalli++;
                gIsto.DrawRectangle(Pens.Black, Window1);
                gIsto.FillRectangle(Brushes.MistyRose, Window1);
            }
            pictureBox2.Image = bIsto;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            int Trials = (int)numericUpDown2.Value;
            int NumberOfTrajectories = (int)numericUpDown3.Value;
            double Probability = ((Convert.ToDouble(numericUpDown1.Value)) / 100);
            Rectangle Window = new Rectangle(0, 0, b.Width-1, b.Height-1);
            g.DrawRectangle(Pens.Black, Window);
            List<int> EndY = new List<int>();
            double minX = 0;
            double maxX = Trials;
            double minY = 0;
            double maxY = Trials / Math.Sqrt(Trials);
            for (int i = 0; i < NumberOfTrajectories; i++)
            {
                List<Point> Punti = new List<Point>();
                Random rnd = new Random();
                Color randomColor = Color.FromArgb(rnd.Next(200), rnd.Next(200), rnd.Next(200));
                Pen PenTrajectory = new Pen(randomColor, 2);
                double YY = 0;
                for (int x = 0; x <= Trials; x++)
                {
                    double coin = r.NextDouble();
                    if (coin <= Probability)
                    {
                        YY = YY + 1;
                    }
                    double yNormalized = YY / Math.Sqrt(x + 1);
                    int xDevice = FromXRealToXVirtual(x, minX, maxX, Window.Left, Window.Width);
                    int yDevice = FromYRealToYVirtual(yNormalized, minY, maxY, Window.Top, Window.Height);
                    if (x == Trials)
                    {
                        EndY.Add(yDevice);
                    }
                    Punti.Add(new Point(xDevice, yDevice));
                }
                g.DrawLines(PenTrajectory, Punti.ToArray());
            }
            pictureBox1.Image = b;
            Dictionary<double, int> magia = new Dictionary<double, int>();
            double beginning = 2.5;
            double inter = beginning;
            bIsto = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            gIsto = Graphics.FromImage(bIsto);
            gIsto.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            while (inter <= bIsto.Height)
            {
                magia[inter] = 0;
                inter = inter + (beginning * 2);
            }
            foreach (int coordY in EndY)
            {
                foreach (double chiave in magia.Keys)
                {
                    if (coordY < chiave + beginning && coordY >= chiave - beginning)
                    {
                        magia[chiave] += 1;
                    }
                }
            }
            int massimo = 0;
            foreach (double chiave in magia.Keys)
            {
                massimo += magia[chiave];
            }
            int intervalli = 0;
            foreach (double chiave in magia.Keys)
            {
                Rectangle Window1 = new Rectangle(0,  intervalli * 5,  bIsto.Width/ massimo *  magia[chiave] ,  (int)beginning * 2);
                intervalli++;
                gIsto.DrawRectangle(Pens.Black, Window1);
                gIsto.FillRectangle(Brushes.MistyRose, Window1);
            }
            pictureBox2.Image = bIsto;
        }
    }
}