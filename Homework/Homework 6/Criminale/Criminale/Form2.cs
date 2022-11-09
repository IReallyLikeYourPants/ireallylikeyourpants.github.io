using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Criminale
{
    public partial class Form2 : Form
    {
        
        public Form2(List<List<int>> samples_list1)
        {
            
            InitializeComponent();
            for (int i = 0; i < samples_list1.Count; i++)
            {
                richTextBox1.AppendText((i+1).ToString("D2") + " Sample: [");
                for (int e = 0; e < samples_list1[i].Count; e++)
                    if (e == samples_list1[i].Count - 1)
                    {
                        richTextBox1.AppendText(samples_list1[i][e].ToString());
                    }
                    else
                    {
                        richTextBox1.AppendText(samples_list1[i][e].ToString() + ", ");
                    }
                richTextBox1.AppendText("]\n");
            }
        }
    }
}
