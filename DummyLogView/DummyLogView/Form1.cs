using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Security.Permissions;

namespace DummyLogView
{
    public partial class Form1 : Form
    {

       

        public static FileSystemWatcher watcher = new FileSystemWatcher();
        public static FileSystemWatcher upWatchher = new FileSystemWatcher();


        public Form1()
        {
            InitializeComponent();
        }

        private void OnSetDownHost(object sender, EventArgs e)
        {

         
        }

        [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
        private void OnDialogLoad(object sender, EventArgs e)
        {

           

            watcher.Path = @"C:\kkcmh\";
            /* Watch for changes in LastAccess and LastWrite times, and
               the renaming of files or directories. */
            watcher.NotifyFilter = NotifyFilters.LastAccess 
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.FileName 
                                 | NotifyFilters.DirectoryName;
         
            // Only watch text files.
            watcher.Filter = "test.txt";
            watcher.Changed += new FileSystemEventHandler(OnChanged);

            // Begin watching.
            watcher.EnableRaisingEvents = true;


            upWatchher.Path = @"C:\kkcmh\";
            /* Watch for changes in LastAccess and LastWrite times, and
               the renaming of files or directories. */
            upWatchher.NotifyFilter = NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.FileName
                                 | NotifyFilters.DirectoryName;

            // Only watch text files.
            upWatchher.Filter = "uphost.txt";
            upWatchher.Changed += new FileSystemEventHandler(OnHostChanged);

            // Begin watching.
            upWatchher.EnableRaisingEvents = true;
         
        }


        public bool _LoadTxtOneLines(RichTextBox rcb , string file)
        {
            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            TextReader tr = new StreamReader(fs, Encoding.Default);
            string str = "";
            rcb.Text = "";
            while (str != null)
            {
                str = tr.ReadLine();
                if(str!=null)
                    rcb.AppendText(str + "\n");
            }

            return true;
        }

        private  void OnChanged(object source, FileSystemEventArgs e)
        {

            //watcher.EnableRaisingEvents = false;
           // MessageBox.Show(e.FullPath);
            string file = e.FullPath;
            _LoadTxtOneLines(this.richTextBox1,file);

            richTextBox1.SelectionStart = richTextBox1.TextLength;
            richTextBox1.ScrollToCaret();

           // watcher.EnableRaisingEvents = true;
           // Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
            //_LoadTxtOneLines(e.FullPath);
            
        }


        private void OnHostChanged(object source, FileSystemEventArgs e)
        {

            //watcher.EnableRaisingEvents = false;
            // MessageBox.Show(e.FullPath);
            string file = e.FullPath;

            _LoadTxtOneLines(this.richTextBox2, file);
            richTextBox2.SelectionStart = richTextBox2.TextLength;
            richTextBox2.ScrollToCaret();

            // watcher.EnableRaisingEvents = true;
            // Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
            //_LoadTxtOneLines(e.FullPath);

        }

        private void OnSetUpHost(object sender, EventArgs e)
        {

        }
    }
}
