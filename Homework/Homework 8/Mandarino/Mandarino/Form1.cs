using System.Diagnostics;
using System.Windows.Forms;

namespace Mandarino
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        Bitmap b;
        Graphics g;

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
            double minValue = 0;
            double maxValue = 0;
            int numero_Insto = (int)numericUpDown2.Value; ;
            int n = (int)numericUpDown1.Value;
            List<double> valori = new List<double>();
            for (int i = 0; i < n; i++)
            {
                double x = 0;
                double y = 0;
                double value = 0;
                double val = -8;

                while (val < 0 || val > 1)
                {
                    x = (r.NextDouble() * 2) - 1;
                    y = (r.NextDouble() * 2) - 1;
                    val = (x * x) + (y * y);
                }

                x = x * Math.Sqrt(-2 * Math.Log(val) / val);
                y = y * Math.Sqrt(-2 * Math.Log(val) / val);

                if (comboBox1.Text == "X")
                {
                    minValue = -4;
                    maxValue = 4;
                    value = x;
                }
                else if (comboBox1.Text == "X^2")
                {
                    minValue = 0;
                    maxValue = 3;
                    value = x * x;
                }
                else if (comboBox1.Text == "X/Y^2")
                {
                    minValue = -9;
                    maxValue = 9;
                    value = x / (y * y);
                }
                else if (comboBox1.Text == "X^2/Y^2")
                {
                    minValue = 0;
                    maxValue = 3;
                    value = (x * x) / (y * y);
                }
                else if (comboBox1.Text == "X/Y")
                {
                    minValue = -9;
                    maxValue = 9;
                    value = x / y;
                }
                valori.Add(value);
            }
            double delta = maxValue - minValue;
            double intervalli = delta / numero_Insto;
            double da = minValue;
            double a = minValue + intervalli;
            int lung = 0;
            List<double> Mannaggia = new List<double>();
            for (int i = 0; i < numero_Insto; i++)
            {
                foreach (double element in valori)
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
            Pen Pen = new Pen(Color.LimeGreen, 2);
            for (int i = 0; i < Mannaggia.Count; i++)
            {
                int dovefarlox = pictureBox1.Width * (i) / Mannaggia.Count +1;
                Point point1 = new Point(dovefarlox, pictureBox1.Height);
                float dovefarloy = (float)Mannaggia[i] / (float)ritorno(Mannaggia) * (float)pictureBox1.Height;
                Point point2 = new Point(dovefarlox, pictureBox1.Height - (int)dovefarloy);
                g.DrawLine(Pen, point1, point2);
            }
            pictureBox1.Image = b;
        }
    }
}