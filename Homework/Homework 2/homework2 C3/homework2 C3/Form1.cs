using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework2_C3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<String> list = new List<string> { "Yellow", "Blue", "Green", "Red" };
        Random rnd = new Random();
        int Yellow = 0;
        int Red = 0;
        int Blue = 0;
        int Green = 0;
        
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int index = rnd.Next(list.Count);
            String value = list[index];
            if (value == "Yellow")
            {
                Yellow++;
                richTextBox1.BackColor = Color.Yellow;
            }
            else if (value == "Blue")
            {
                Blue++;
                richTextBox1.BackColor = Color.Blue;
            }
            else if (value == "Green")
            {
                Green++;
                richTextBox1.BackColor = Color.Green;
            }
            else
            {
                Red++;
                richTextBox1.BackColor = Color.Red;
            }
            richTextBox1.AppendText(value + "\n");
            if (Yellow == 10)
            {
                label1.Text = "Yellow WON!";
                label1.Visible = true;
                timer1.Enabled = false;
                Yellow = 0;
                Red = 0;
                Blue = 0;
                Green = 0;
            }
            else if (Red == 10)
            {

                label1.Text = "Red WON!";
                label1.Visible = true;
                timer1.Enabled = false;
                Yellow = 0;
                Red = 0;
                Blue = 0;
                Green = 0;
            }
            else if (Blue == 10)
            {

                label1.Text = "Blue WON!";
                label1.Visible = true;
                timer1.Enabled = false;
                Yellow = 0;
                Red = 0;
                Blue = 0;
                Green = 0;
            }
            else if (Green == 10)
            {
                label1.Text = "Green WON!";
                label1.Visible = true;
                timer1.Enabled = false;
                Yellow = 0;
                Red = 0;
                Blue = 0;
                Green = 0;
            }
        }
    }
}
