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
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
