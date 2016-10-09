using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DynamicForms.DataObjects
{
    [XmlRoot]
    public class DynamicInterface
    {
        [XmlElement]
        public CustomMenu CustomMenu { get; set; }

        [XmlElement]
        public List<CustomForm> CustomForm { get; set; }
    }
}
