using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PersonModels
{
    /// <summary>
    /// The request class for how many books to be requested and is used for pagination
    /// </summary>
    public class PersonListRequestFilter
    {
        /// <summary>
        /// Index of the page to be served.
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// Total pages to be served for the request.
        /// </summary>
        public int PageSize { get; set; }
    }
}
