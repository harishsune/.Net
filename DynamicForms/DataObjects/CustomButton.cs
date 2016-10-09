using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DynamicForms.DataObjects
{
   public class CustomButton
    {
        [XmlAttribute("Text")]
        public string BText { get; set; }

        [XmlAttribute]
        public string OnClick { get; set; }
    }
}
