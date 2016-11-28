using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void treeListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TreeListViewItem oItem = new TreeListViewItem("Harish", 0);
            oItem.Name = "Harish";
            treeListView1.Items.Add(oItem);
            treeListView1.Items["Harish"].Items.Add("XYZ");

            TreeListViewItem oItem1 = new TreeListViewItem("ABCD");
            oItem1.Name = "ABCD";
            //oItem1.Group = treeListView1.Groups[1];
            treeListView1.Items.Add(oItem1);

            TreeListViewItem oItem2 = new TreeListViewItem("PQR", 0);
          //  oItem2.Group = treeListView1.Groups[1];
            treeListView1.Items["ABCD"].Items.Add(oItem2);
            treeListView1.Items["ABCD"].Items.Add("XYZ");


        }

        private void treeListView1_ItemActivate(object sender, EventArgs e)
        {

        }

        private void treeListView1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(treeListView1.SelectedItem.Text);  
        }
    }
}
