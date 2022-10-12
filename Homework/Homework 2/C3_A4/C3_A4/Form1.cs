using Microsoft.VisualBasic.FileIO;
using System.IO;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections.Generic;

namespace C3_A4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "(Comma split)| *.csv; *.txt";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                string sFileName = choofdlog.FileName;
                using (TextFieldParser parser = new TextFieldParser(sFileName))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    string[] fields2 = parser.ReadFields();
                    foreach (string field in fields2)
                    {
                        dataGridView1.Columns.Add(field, field);
                    }
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        dataGridView1.Rows.Add(fields);
                    }
                }
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int valore = e.ColumnIndex;
            List<String> franco = new List<String>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                franco.Add(Convert.ToString(dataGridView1.Rows[i].Cells[valore].Value).ToLower());

            }
            int valorefranco = franco.Count()-1;

            var hashSet = new HashSet<String>(franco);
            foreach (var value in hashSet)
            {
                if (value == "")
                {
                    hashSet.Remove("");
                }
            }

            List <(string, int)> tupleList  = new List<(string, int)>();
            foreach (var value in hashSet)
            {
                int conto = 0;
                for (int i = 0; i < franco.Count(); i++)
                {
                    if (franco[i].Equals(value))
                    {
                        conto++;
                    }
                    
                }
                tupleList.Add((value, conto));
            }
            tupleList.Sort();
            foreach (var tuple in tupleList)
            {
                richTextBox1.AppendText("The distribution of " + tuple.Item1 + " is " + tuple.Item2 + "/" + valorefranco + "\n" );
            }
            richTextBox1.AppendText("\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
    }
}