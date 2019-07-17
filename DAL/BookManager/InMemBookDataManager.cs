using Model.BookModels;
using Shared.Logger;
using Shared.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace DAL.BookManager
{
    /// <summary>
    /// The implemenation of Bookdata manager to support In memory
    /// data for books and its manipulation.
    /// </summary>
    public class InMemBookDataManager : IBooksDataManager
    {
        private static CatalogVM CatalogData;
        private readonly ILogger Logger;
        /// <summary>
        /// Initialize by fetching the data from XML file
        /// </summary>
        /// <param name="bookXMLFileName"></param>
        public  InMemBookDataManager(ILogger logger,string bookXMLFileName)
        {
            this.Logger= logger;
            //Catalog Data fetched only once
            if (CatalogData == null)
            {
                XmlSerializer se = new XmlSerializer(typeof(CatalogVM));
                //Convert XML data to CatalogVM object
                CatalogData = (CatalogVM)se.Deserialize(Helper.GetStreamFromURL(bookXMLFileName));
                CatalogData.TotalBooks = CatalogData.Books.Count();
            }
        }

        /// <summary>
        /// Get the Book data from CatalogData
        /// </summary>
        /// <param name="bookID"></param>
        /// <returns></returns>
         public Book GetBookDetails(string bookID)
         {
            return CatalogData.Books.FirstOrDefault(x => x.BookID == bookID);
         }

        /// <summary>
        /// To get the list of books by specifying the boundary conditions from static memory
        /// </summary>
        /// <param name="pageIndex">Specifies the page index</param>
        /// <param name="pageSize">Specifies the page size to be shown</param>
        /// <returns></returns>
        public CatalogVM GetBooks(int pageIndex, int pageSize)
        {
            return new CatalogVM
            {
                Books = (List<Book>)CatalogData.Books.Skip(pageIndex).Take(pageSize).ToList<Book>(),
                TotalBooks = CatalogData.Books.Count
            };
        }

        /// <summary>
        /// Map the book with the specified personid
        /// </summary>
        /// <param name="bookID"></param>
        /// <param name="personID"></param>
        /// <returns></returns>
        public Book UpdateBookWithPersonID(string bookID, string personID)
        {
            var book = CatalogData.Books.FirstOrDefault(x => x.BookID == bookID);
            if (book != null)
            {
                book.PersonID = personID;
            }
            return book;
        }
    }
}
