using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DynamicForms.DataObjects
{
   public class InputCollection
    {
        [XmlElement]
        public List<CustomButton> CustomButton { get; set; }
        [XmlElement]
        public List<CustomTextBox> CustomTextBox { get; set; }

       
    }
}
