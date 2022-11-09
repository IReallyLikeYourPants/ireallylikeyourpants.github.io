using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Criminale
{
    public partial class Form3 : Form
    {
        Graphics g;
        Bitmap b;

        Graphics g1;
        Bitmap b1;

        Graphics g2;
        Bitmap b2;

        Graphics g3;
        Bitmap b3;
        public int count_repetition(int val, List<int> fra)
        {
            int can = 0;
            for (int i = 0; i < fra.Count; i++)
            {
                if (fra[i] == val)
                {
                    can += 1;
                }
            }
            return can;
        }

        double variance_cal(List<int> va)
        {

            double squaredDifferences = 0;
            for (int i = 0; i < va.Count; i++)
            {
                double diff = (double)va[i] - (double)((double)va.Sum() / (double)(va.Count));
                double squaredDiff = diff * diff;
                squaredDifferences += squaredDiff;
            }
            return (double)(squaredDifferences / (double)(va.Count - 1));
        }

        double variance_cal1(List<int> va)
        {
            double squaredDifferences = 0;
            for (int i = 0; i < va.Count; i++)
            {
                double diff = (double)va[i] - (double)((double)va.Sum() / (double)(va.Count));
                double squaredDiff = diff * diff;
                squaredDifferences += squaredDiff;
            }
            return (double)(squaredDifferences / (double)(va.Count));
        }
            public Form3(List<int> fra, List<List<int>> fra2, int samples_n)
        {
            InitializeComponent();
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            int tot = fra.Sum();
            Pen Pen = new Pen(Color.DarkSeaGreen, 50);

            for (int i = 1; i < 7; i++)
            {
                int dovefarlox = pictureBox1.Width * i/7;
                Point point1 = new Point(dovefarlox, pictureBox1.Height);
                float valf = (float)count_repetition(i, fra) / (float) tot * (float)pictureBox1.Height * 7;
                Point point2 = new Point(dovefarlox, pictureBox1.Height - (int)valf);
                g.DrawLine(Pen, point1, point2);
            }
            pictureBox1.Image = b;
            label1.Text = "1: " + count_repetition(1, fra);
            label2.Text = "2: " + count_repetition(2, fra);
            label3.Text = "3: " + count_repetition(3, fra);
            label4.Text = "4: " + count_repetition(4, fra);
            label5.Text = "5: " + count_repetition(5, fra);
            label6.Text = "6: " + count_repetition(6, fra);

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
            //second part//
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
            Pen Pen3 = new Pen(Color.DeepPink, 1);
            List<Point> Punti = new List<Point>();
            List<double> now_mean = new List<double>();
            b1 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            g1 = Graphics.FromImage(b1);
            g1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            var dictionary2 = new Dictionary<int, double>(){{1, pictureBox2.Height-1 }, 
                {2, pictureBox2.Height* 0.8 }, {3, pictureBox2.Height * 0.6 }, 
                {4, pictureBox2.Height * 0.4 }, {5, pictureBox2.Height *0.2}, {6 , 0}};
            for (int i = 0; i < fra.Count; i++)
            {
                int la_y = (int)dictionary2[fra[i]];
                now_mean.Add(dictionary2[fra[i]]);
                double now_mean_value = now_mean.Sum() / now_mean.Count;
                float la_x = (float)pictureBox2.Width / (float)fra.Count * i;
                if (i == fra.Count -1)
                {
                    la_x = (float)pictureBox2.Width;
                }
                Punti.Add(new Point((int)la_x, (int)(now_mean_value)));
            }
            
            g1.DrawLines(Pen3, Punti.ToArray());
            pictureBox2.Image = b1;

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
            //third part//
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////

            b2 = new Bitmap(pictureBox3.Width, pictureBox3.Height);
            g2 = Graphics.FromImage(b2);
            g2.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            int how_big = 0;
            int quant = fra2.Count;
            if (quant < 10)
            {
                how_big = 50;
            }
            else if (quant < 100)
            {
                how_big = 5;
            }
            else
            {
                how_big = 1;
            }
            Pen Pen4 = new Pen(Color.DarkSeaGreen, how_big);
            int sommone = 0;
            for (int i  = 0; i < quant; i++)
            {
                sommone += fra2[i].Sum();
            }
            float risultatone = (float)sommone / ((float)fra2.Count * (float)samples_n);
            
            for (int i = 1; i < quant + 1; i++)
            {
                int dovefarlox = pictureBox3.Width * i / (quant + 1);
                Point point1 = new Point(dovefarlox, pictureBox3.Height);
                float valf = (((float)fra2[i - 1].Sum() / fra2[i-1].Count()) / 6) * (float)pictureBox3.Height;
                Point point2 = new Point(dovefarlox, pictureBox3.Height - (int)valf);
                g2.DrawLine(Pen4, point1, point2);
            }
            Point point1v = new Point(0, pictureBox3.Height - (int)(pictureBox3.Height * (float)((float)fra.Sum()/ (float)fra.Count) / 6));
            Point point2v = new Point(pictureBox3.Width, pictureBox3.Height - (int)(pictureBox3.Height * (float)(float)fra.Sum() / (float)fra.Count) / 6);
            Pen Pen5 = new Pen(Color.DeepPink, 1);
            g2.DrawLine(Pen5, point1v, point2v);
            pictureBox3.Image = b2;


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
            //fourth part//
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////

            b3 = new Bitmap(pictureBox4.Width, pictureBox4.Height);
            g3 = Graphics.FromImage(b3);
            g3.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            int how_big1 = 0;
            int quant1 = fra2.Count;
            if (quant1 < 10)
            {
                how_big1 = 50;
            }
            else if (quant1 < 100)
            {
                how_big1 = 5;
            }
            else
            {
                how_big = 1;
            }
            Pen Pen6 = new Pen(Color.DarkSeaGreen, how_big1);
            int sommone1 = 0;
            for (int i = 0; i < quant1; i++)
            {
                sommone1 += fra2[i].Sum();
            }
            float risultatone1 = (float)sommone1 / ((float)fra2.Count * (float)samples_n);

            for (int i = 1; i < quant1 + 1; i++)
            {
                int dovefarlox = pictureBox4.Width * i / (quant1 + 1);
                Point point1 = new Point(dovefarlox, pictureBox4.Height);
                float valf = (((float)variance_cal(fra2[i-1])) / 6) * (float)pictureBox4.Height;
                Point point2 = new Point(dovefarlox, pictureBox4.Height - (int)valf);
                g3.DrawLine(Pen6, point1, point2);
            }
            Point point1v1 = new Point(0, pictureBox4.Height - (int)(pictureBox4.Height * variance_cal1(fra) / 6));
            Point point2v1 = new Point(pictureBox4.Width, pictureBox4.Height - (int)((float)pictureBox4.Height * (float)variance_cal1(fra) / 6));
            Pen Pen7 = new Pen(Color.DeepPink, 1);
            g3.DrawLine(Pen7, point1v1, point2v1);
            pictureBox4.Image = b3;




        }
    }
}
