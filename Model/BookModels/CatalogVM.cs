using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model.BookModels
{
    /// <summary>
    /// /// <summary>
    /// Model forlist of books. The class is also used for serialization of data from xml
    /// </summary>
    /// </summary>
    [XmlRoot(ElementName = "catalog")]
    public class CatalogVM
    {
        [XmlElement(Order = 2, ElementName = "book")]
        public List<Book> Books { get; set; }
        /// <summary>
        /// Specify the total number of books in the system
        /// </summary>
        [XmlIgnore]
        public int TotalBooks { get; set; }
    }
}
