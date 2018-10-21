using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace LogViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void InitKeyWord()
        {
           // keywords.Add("1114");
        }

        private string readFile(string file)
        {
            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read,FileShare.ReadWrite);
            TextReader tr = new StreamReader(fs, Encoding.Default);
            string str = tr.ReadToEnd(); 
            return str; 
        }


        private bool _LoadTxtOneLines(string file)
        {
            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            TextReader tr = new StreamReader(fs, Encoding.Default);
            string str = "";
            while (str != null)
            {
                str = tr.ReadLine();
                richTextBox1.AppendText(str + "\n");
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //richTextBox1.Text = readFile(@"C:\kkcmh\test.txt");
            _LoadTxtOneLines(@"C:\kkcmh\test.txt");
            string findstr = "14";
            int lineStartPos = 0;

            foreach (string item in richTextBox1.Lines)
            {
                int index = item.IndexOf(findstr);
                if(index != -1 )
                { 
                    this.richTextBox1.Select(lineStartPos,item.Length );
                    richTextBox1.SelectionFont = new Font("宋体", 14, (FontStyle.Regular));
                    richTextBox1.SelectionColor = Color.Red;
                }

                lineStartPos += item.Length + 1;
            }
        }

    }
}
