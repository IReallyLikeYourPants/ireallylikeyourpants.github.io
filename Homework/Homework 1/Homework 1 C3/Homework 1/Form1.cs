using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label1.ForeColor == System.Drawing.Color.Red)
                label1.ForeColor = System.Drawing.Color.Black;
            else
                label1.ForeColor = System.Drawing.Color.Red;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Visible == true)
                pictureBox1.Hide();
            else
                pictureBox1.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                label4.ForeColor = System.Drawing.Color.Green;
            else
                label4.ForeColor = System.Drawing.Color.Black;
        }
    }
}
