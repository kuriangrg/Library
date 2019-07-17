using Model.BookModels;
using DAL.BookManager;
using Shared.Logger;
using Shared.IOCHelper;

namespace BL.BookService
{
    /// <summary>
    /// The contract which serves the details of a book
    /// in library
    /// </summary>
    public class BookDetailsService : IBookDetailsService
    {
        private readonly IBooksDataManager BookDataManager;
        private readonly ILogger Logger;
        /// <summary>
        /// Dependency injection for book data manager
        /// </summary>
        /// <param name="BookDataManager"></param>
        public BookDetailsService(IUnityLocator unityLocator)
        {
            this.BookDataManager = unityLocator.GetLocator<IBooksDataManager>();
            this.Logger = unityLocator.GetLocator<ILogger>();
        }


        /// <summary>
        /// Get the book details 
        /// </summary>
        /// <param name="bookID"></param>
        /// <returns></returns>
        public Book GetBookDetail(string bookID)
        {
            Logger.Debug("GetBookDetail request. BookID" + bookID);
            return BookDataManager.GetBookDetails(bookID);
         }

        /// <summary>
        /// To get the list of books by specifying the boundary conditions
        /// </summary>
        /// <param name="personFilterRequest">Specifies the page index and pagesize</param>
        /// <returns>List of books from boundary conditions and total number of books </returns>
        public CatalogVM GetBookList(BookListRequestFilter booksFilter)
        {
            Logger.Debug("Get Booklist request"+ booksFilter);
            if (booksFilter != null)
            {
                return BookDataManager.GetBooks(booksFilter.PageIndex, booksFilter.PageSize);
            }
            else
            {
                Logger.Warn("The booksFilter request is null when GetBooklist is called");
                return null;
            }
        }
    }
}
