using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DynamicForms.DataObjects
{
    public class CustomTextBox
    {
        [XmlAttribute]
        public string IsMultiLine { get; set; }

        [XmlAttribute]
        public string Height { get; set; }

        [XmlAttribute]
        public string Width { get; set; }

        [XmlAttribute]
        public string X { get; set; }

        [XmlAttribute]
        public string Y { get; set; }

    }
}
