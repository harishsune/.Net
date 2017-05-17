using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

//for DLL's
using System.Runtime.InteropServices;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //const and dll functions for moving form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        msgForm oForm;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
            int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        //call functions to move the form in your form's MouseDown event
        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
         
        }

        public Form1()
        {
            InitializeComponent();
        }

        public void transmitprotocol()
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            //you can use progresschange in order change waiting message while background working
            oForm = new msgForm();//set lable and your waiting text in this form
            try
            {
                bw.RunWorkerAsync();//this will run all Transmitting protocol coding at background thread

                //MessageBox.Show("Please wait. Uploading logo.", "Status");
                oForm.ShowDialog();//use controlable form instead of poor MessageBox
            }
            catch (Exception ex)
            {
               // Debug.WriteLine(ex.ToString());
            }
        }

       public void bw_DoWork(object sender, DoWorkEventArgs e)
       {
            
        // Transmitting protocol coding here. Takes around 2 minutes to finish. 
        //you have to write down your Transmitting codes here
        //The following code is just for loading time simulation and you can remove it later. 
        System.Threading.Thread.Sleep(5 * 1000); //this code take 5 seconds to be passed
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //all background work has complete and we are going to close the waiting message
            oForm.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> oList = new List<string>();
            XmlDocument oXmlDoc = new XmlDocument();
            oXmlDoc.Load("Data.xml");
            var nodes = oXmlDoc.SelectSingleNode("Data");

            foreach (XmlNode onode in nodes.ChildNodes)
            {
                checkedListBox1.Items.Add(onode.InnerText + 1);
                //checkedListBox1.SetItemCheckState(checkedListBox1.Items.IndexOf(onode.InnerText), CheckState.Indeterminate);

            }
            foreach (XmlNode onode in nodes.ChildNodes)
            {
                checkedListBox1.Items.Add(onode.InnerText);
                checkedListBox1.SetItemCheckState(checkedListBox1.Items.IndexOf(onode.InnerText), CheckState.Indeterminate);

            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (checkedListBox1.GetItemCheckState(e.Index) == CheckState.Indeterminate)
            {
                e.NewValue = e.CurrentValue;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            transmitprotocol();
            List<string> oChecked = new List<string>();
            foreach (var items in checkedListBox1.CheckedItems)
            {
                if (checkedListBox1.GetItemCheckState(checkedListBox1.Items.IndexOf(items)) == CheckState.Checked)
                {
                    if (!oChecked.Contains(items.ToString()))
                    {
                        oChecked.Add(items.ToString());
                    }
                }
            }

            foreach (var item in oChecked)
            {

                if (!checkedListBox2.Items.Contains(item))
                {
                    checkedListBox2.Items.Add(item);
                }
            }
        }
    }
}
