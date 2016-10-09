using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DynamicForms.DataObjects
{

    public class CustomMenu
    {
        [XmlElement]
        public List<CustomMenuItems> CustomMenuItems { get; set; }
    }
}
