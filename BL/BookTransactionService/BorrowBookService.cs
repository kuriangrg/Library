using DAL.BookManager;
using DAL.PersonManager;
using Model.BookModels;
using Shared.IOCHelper;
using Shared.Logger;

namespace BL.BookTransactionService
{
    /// <summary>
    /// Contains the methods for the borrowal processess
    /// </summary>
    public class BorrowBookService: IBorrowBookService
    {
        private readonly IBooksDataManager BookManager;
        private readonly IUnityLocator UnityLocator;
        private readonly ILogger Logger;

        /// <summary>
        /// Inject booksdatamanager for book data and personsData manager for person data
        /// </summary>
        /// <param name="booksDataManager"></param>
        /// <param name="personsDataManager"></param>
        public BorrowBookService(IUnityLocator unityLocator)
        {
            this.UnityLocator = unityLocator;
            this.BookManager = unityLocator.GetLocator<IBooksDataManager>();
            this.Logger = unityLocator.GetLocator<ILogger>();
        }

        /// <summary>
        /// Get the book details with borrower deatils
        /// </summary>
        /// <param name="bookID"></param>
        /// <returns></returns>
        public BookPersonVM GetBorrowBookDetails(string bookID)
        {
            Logger.Debug("GetBorrowBookDetails request" + bookID);
            IPersonsDataManager PersonManager = UnityLocator.GetLocator<IPersonsDataManager>();
            Book bookDetails = BookManager.GetBookDetails(bookID);
            if (bookDetails != null)
            {
                return new BookPersonVM
                {
                    BookDetails = bookDetails,
                    PersonDetails = PersonManager.GetPersonDetails(bookDetails.PersonID)
                };
            }
            else
            {
                Logger.Warn("The booksFilter request is null when GetBooklist is called");
                return null;
            }
        }

        /// <summary>
        /// Update personid for book for the borrowal process
        /// </summary>
        /// <param name="borrowalRequest"></param>
        /// <returns></returns>

       public Book BorrowBookForPerson(BorrowBookRequest borrowalRequest)
        {
            Logger.Debug("BorrowBookForPerson borrowalRequest:" + borrowalRequest);
            return (borrowalRequest != null)?  BookManager.UpdateBookWithPersonID(borrowalRequest.BookID, borrowalRequest.PersonID):null;
         }

        /// <summary>
        /// Return the book by updating person value as null in book
        /// </summary>
        /// <param name="borrowalRequest"></param>
        /// <returns></returns>
        public Book ReturnBook(string bookID)
        {
            Logger.Debug("BorrowBookForPerson borrowalRequest:"+bookID);
            return  BookManager.UpdateBookWithPersonID(bookID,null);
        }

    }
    
}
