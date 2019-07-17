using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model.PersonModel
{
    /// <summary>
    /// Model for person. The class is also used for serialization of data from xml
    /// </summary>
    public class Person
    {
        [XmlAttribute("id")]
        public string PersonID { get; set; }
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "place")]
        public string Place { get; set; }
        [XmlElement(ElementName = "contact")]
        public string Contact { get; set; }

    }
}
