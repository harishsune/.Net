using DynamicForms.DataObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;


namespace DynamicForms
{
    public partial class Form1 : Form
    {
        DynamicInterface oDynamicInterface;

        public Form1()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            GetDynamicMenu();
        }

        private void GetDynamicMenu()
        {
            MenuStrip oMenu = new MenuStrip();
            ToolStripMenuItem SSMenu = new ToolStripMenuItem();
            oMenu.Visible = true;
            ToolStripMenuItem oToolStripMenuItem = new ToolStripMenuItem();
            XmlSerializer oXmlSerializer = new XmlSerializer(typeof(DynamicInterface));
            StreamReader oStreamReader = new StreamReader(@"G:\C#_Training_Harish_Sune\Windows App\Windows Forms\DynamicForms\DynamicInterfaceData.xml");
            oDynamicInterface = (DynamicInterface)oXmlSerializer.Deserialize(oStreamReader);
            foreach (CustomMenuItems oMenuItem in oDynamicInterface.CustomMenu.CustomMenuItems)
            {
                //oMenu.Items.Add(oMenuItem.Header);

                //oToolStripMenuItem.DropDownItems.Add(oMenuItem.Header);
                //oMenu.Items.Add(oToolStripMenuItem);
                //oMenu.drop
                oToolStripMenuItem = new ToolStripMenuItem(oMenuItem.Header);
                oMenu.Items.Add(oToolStripMenuItem);

                 SSMenu = new ToolStripMenuItem(oMenuItem.Header);
                // SubMenu(SSMenu,rw);  I have included this piece of code to add a Sub-Menu to the New Menu
                oToolStripMenuItem.DropDownItems.Add(SSMenu);
                oToolStripMenuItem.DropDownItems[0].Click += new System.EventHandler(this.fileToolStripMenuItem_Click_1);
            }
            
            this.Controls.Add(oMenu);

            }

       
        private void fileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string sSender = sender.ToString();
            switch(sSender)
            {
                case "File":
                    getForm(sender,e);
                    break;

            }

        }

        private void getForm(object sender, EventArgs e)
        {
            Form oForm = null;
            foreach (CustomForm customForm in oDynamicInterface.CustomForm)
            {
                oForm = new Form();
                oForm.MdiParent = this;
                oForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                oForm.Size = new Size(Convert.ToInt32(customForm.Height), Convert.ToInt32(customForm.Width));
                oForm.Text = customForm.Name;
            }
            //oDynamicInterface.CustomForm[0].InputCollection[0]
              foreach (CustomButton oButton in oDynamicInterface.CustomForm[0].InputCollection[0].CustomButton)
            {
                Button oDynamicButton = new Button();
                oDynamicButton.Text = oButton.BText;
                oDynamicButton.Click += (s, cevent) => OnDynamicButton_Click(oButton);
                oForm.Controls.Add(oDynamicButton);
            }

              foreach(CustomTextBox oTextBox in oDynamicInterface.CustomForm[0].InputCollection[0].CustomTextBox)
            {
                TextBox oDynamicTextBox = new TextBox();
                oDynamicTextBox.Multiline = Convert.ToBoolean(oTextBox.IsMultiLine);
                oDynamicTextBox.Size= new Size(Convert.ToInt32(oTextBox.Width), Convert.ToInt32(oTextBox.Height));
                oDynamicTextBox.Location = new Point(Convert.ToInt32(oTextBox.X), Convert.ToInt32(oTextBox.Y));
                oForm.Controls.Add(oDynamicTextBox);
            }
            oForm.Show();
            //this.Controls.Add(oForm);
        }

        private void OnDynamicButton_Click(CustomButton customButton)
        {
            Process.Start(customButton.OnClick);
        }
    }
}
