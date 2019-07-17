using Model.PersonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BookModels
{
    /// <summary>
    /// Model which specify the detail of the book and details of the 
    /// corresponding Person who has borrowed
    /// </summary>
    public class BookPersonVM
    {
       public  Book BookDetails { get; set; }
       public  Person PersonDetails { get; set; }
    }
}
