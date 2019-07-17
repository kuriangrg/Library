using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BookModels
{
    /// <summary>
    /// The Model which represents the request details like bookid
    /// or for how many duration the book is borrowed
    /// </summary>
    public class BorrowBookRequest
    {
        public string BookID { get; set; }
        public string PersonID { get; set; }
    }
}
