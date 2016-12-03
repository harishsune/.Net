using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using BatchReadingJob;
using System.IO;

namespace MultiThreding
{

    public partial class Form1 : Form
    {
        List<string> oList;
        System.Windows.Forms.Timer oTimer;
        FileStream o = new FileStream(@"D:\Log", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        StreamReader oo;
        bool isJobCompleted;

        public Form1()
        {
            InitializeComponent();
            oTimer = new System.Windows.Forms.Timer();
            oTimer.Interval = 1;
            oTimer.Tick += OTimer_Tick;
        }

        private void OTimer_Tick(object sender, EventArgs e)
        {

            textBox1.AppendText(Environment.NewLine + oo.ReadLine());
            if (isJobCompleted && oo.EndOfStream)
            {
                textBox2.Text = "Completed";
                oTimer.Stop();
                label2.Text = DateTime.Now.ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BackgroundWorker obj = new BackgroundWorker();
            obj.DoWork += Obj_DoWork;
            obj.RunWorkerAsync();
            obj.RunWorkerCompleted += Obj_RunWorkerCompleted;
            oo = new StreamReader(o);
            oTimer.Start();
        }

        private void Obj_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            isJobCompleted = true;
            label1.Text = DateTime.Now.ToString();
        }

        private void Obj_DoWork(object sender, DoWorkEventArgs e)
        {
            ReaderAndWriter oReader = new ReaderAndWriter();
            oList = ReaderAndWriter.Log;
            oReader.Process(null);
        }
    }
}
