using Model.BookModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.BookManager
{
    public interface IBooksDataManager
    {
        CatalogVM GetBooks(int pageIndex, int pageSize);
        Book GetBookDetails(string bookID);
        Book UpdateBookWithPersonID(string bookID, string personID);
    }
}
