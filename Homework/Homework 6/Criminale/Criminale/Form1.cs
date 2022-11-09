using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Criminale
{
    public partial class Form1 : Form
    {


        Random rd = new Random();
        List<int> dice = new List<int>();
        int samples = 0;
        int samples_n1 = 0;
        List<List<int>> samples_list = new List<List<int>>();
        public Form1()
        {
            InitializeComponent();
        }


        public int count_repetition(int val)
        {
            int can = 0;
            for (int i = 0; i < dice.Count; i++)
            {
                if (dice[i] == val)
                {
                    can += 1;
                }
            }
            return can;
        }

        public void button1_Click(object sender, EventArgs e)
        {
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
            samples_list = new List<List<int>>();
            richTextBox1.Clear();
            richTextBox2.Clear();

            dice.Clear();
            int samples = (int)numericUpDown1.Value;
            int samples_n = (int)numericUpDown2.Value;
            samples_n1 = samples_n;
            for (int i = 1; i < 7; i++)
            {
                int rand_num = rd.Next((int)numericUpDown3.Value, (int)numericUpDown4.Value + 1);
                for (int r = 0; r < rand_num; r++)
                {
                    dice.Add(i);
                }
            }
            dice = dice.OrderBy(a => rd.Next()).ToList();
            double mean1 = dice.Sum();
            textBox1.Text = (mean1 / dice.Count).ToString("N5");
            textBox9.Text = variance_cal1(dice).ToString("N5");
            textBox2.Text = count_repetition(1).ToString();
            textBox3.Text = count_repetition(2).ToString();
            textBox4.Text = count_repetition(3).ToString();
            textBox5.Text = count_repetition(4).ToString();
            textBox6.Text = count_repetition(5).ToString();
            textBox7.Text = count_repetition(6).ToString();
            textBox8.Text = dice.Count.ToString();
            for (int i = 0; i < samples; i++)
            {
                samples_list.Add(dice.OrderBy(x => rd.Next()).Take(samples_n).ToList());
            }
            double means_sum = 0;
            double variance_sum = 0;
            for (int i = 0; i < samples; i++)
            {
                means_sum += (double)samples_list[i].Sum() / (double)samples_n;
                variance_sum += variance_cal(samples_list[i]);
                richTextBox1.AppendText("Mean " + (i + 1).ToString("D2") + ": " + ((double)samples_list[i].Sum() / (double)samples_n).ToString("N5") + "\n");
                richTextBox2.AppendText("Variance " + (i + 1).ToString("D2") + ": " + variance_cal(samples_list[i]).ToString("N5") + "\n");
            }
            label12.Text = ("The mean of the samples is: " + ((double)means_sum / (double)samples).ToString("N5"));
            label12.Visible = true;
            label14.Text = ("The Variance of the samples is: " + ((double)variance_sum / (double)samples).ToString("N5"));
            label14.Visible = true;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            samples = (int)numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            samples_n1 = (int)numericUpDown2.Value;
        }

        public void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(samples_list);
            form2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(dice, samples_list, samples_n1);
            form3.ShowDialog();
        }
    }
}