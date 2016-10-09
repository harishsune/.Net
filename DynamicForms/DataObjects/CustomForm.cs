using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DynamicForms.DataObjects
{
    public class CustomForm
    {
        [XmlElement]
        public List<InputCollection> InputCollection { get; set; }

        [XmlAttribute]
        public string Height { get; set; }

        [XmlAttribute]
        public string Width { get; set; }

        [XmlAttribute]
        public string Name { get; set; }

    }
}
