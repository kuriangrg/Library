using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model.PersonModel
{
    /// <summary>
    /// /// <summary>
    /// Model forlist of books. The class is also used for serialization of data from xml
    /// </summary>
    /// </summary>
    [XmlRoot(ElementName = "persons")]
    public class PersonVM
    {
        [XmlElement(Order = 2, ElementName = "person")]
        public List<Person> Persons { get; set; }
        [XmlIgnore]
        public int TotalPersons { get; set; }
    }
}
