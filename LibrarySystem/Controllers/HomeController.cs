using BL.BookService;
using BL.BookTransactionService;
using BL.PersonService;
using Model.BookModels;
using Model.PersonModels;
using Shared.IOCHelper;
using Shared.Logger;
using System;
using System.Linq;
using System.Web.Mvc;
namespace LibrarySystem.Controllers
{
    /// <summary>
    /// The controller handles all the basic functionalites of Library system
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger Logger;
        private readonly IUnityLocator UnityLocatorService;

        /// <summary>
        /// Unity framework injection is executed in the controller
        /// </summary>
        /// <param name="BookDataService">Injects the  service for books</param>
        /// <param name="PersonDataService">Injects the data service for person</param>
        /// <param name="BookOperationService">Injects the data service for borrowal</param>
        public HomeController(IUnityLocator unityLocator)
        {
            this.UnityLocatorService = unityLocator;
            this.Logger = unityLocator.GetLocator<ILogger>();
        }

        /// <summary>
        /// Home page of the system to show all the books
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            try
            {
                Logger.Info("Get Home page");
                //Request all books 
                IBookDetailsService BookService = UnityLocatorService.GetLocator<IBookDetailsService>();
                CatalogVM catalog 
                    = BookService.GetBookList(new BookListRequestFilter { PageIndex = 0, PageSize = int.MaxValue });
                return View(catalog);
            }
            catch(Exception ex)
            {
                Logger.Error("An exception occured in Home page", ex);
                throw;
            }
        }

        /// <summary>
        /// Get the book details and who has borrowed it
        /// </summary>
        /// <param name="bookID"></param>
        /// <returns></returns>
        public ActionResult BookAndBorrowalDetails(string bookID)
        {
            Logger.Info("Get Book and borrowal details");
            try
            {
                IBorrowBookService BookOperationService = UnityLocatorService.GetLocator<IBorrowBookService>();
                return View(BookOperationService.GetBorrowBookDetails(bookID));
            }
            catch(Exception ex)
            {
                Logger.Debug("Exception while getting details for book:"+ bookID);
                Logger.Error("An exception occured in Borrowing Details", ex);
                throw;
            }
}

        /// <summary>
        ///Return the book to the system
        /// </summary>
        /// <param name="bookID"></param>
        /// <returns></returns>
        public ActionResult ReturnBook(string bookID)
        {
            Logger.Info("Return of the book");
            try
            {
                IBorrowBookService BookOperationService = UnityLocatorService.GetLocator<IBorrowBookService>();
                return View(BookOperationService.ReturnBook(bookID));
            }
            catch(Exception ex)
            {
                Logger.Debug("Exception while returning the book:" + bookID);
                Logger.Error("An exception occured while Returning book", ex);
                throw;
            }
        }

        /// <summary>
        /// Get request only to show the borrowal page with the current
        /// person who has borrowed
        /// </summary>
        /// <param name="bookID">bookID for which borrowal is done</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult BorrowBook(string bookID)
        {
            Logger.Info("Borrowal of the book- show page");
            try
            {
                IBookDetailsService BookService =  UnityLocatorService.GetLocator<IBookDetailsService>();
                IPersonDetailsService PersonService = UnityLocatorService.GetLocator<IPersonDetailsService>();
                Book bookDetail = BookService.GetBookDetail(bookID);
                //Populate personIDs for selection
                ViewBag.Persons = PersonService.GetPersonsList(
                    new PersonListRequestFilter { PageIndex = 0, PageSize = 100 }).Persons.Select(x => x.PersonID);
                return View(bookDetail);
            }
            catch(Exception ex)
            {
                Logger.Debug("Exception while Borrowing the book:" + bookID);
                Logger.Error("An exception occured in Borrowing Book", ex);
                throw;
            }
        }

        /// <summary>
        /// Post request to update the borrowal with the person
        /// </summary>
        /// <param name="borrowBookRqst">request contains bookID and personID to be allocted</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult BorrowBook(BorrowBookRequest borrowBookRqst)
        {
            Logger.Info("Execute Borrowal of the book");
            try
            {
                IBorrowBookService BookOperationService = UnityLocatorService.GetLocator<IBorrowBookService>();
                IPersonDetailsService PersonService = UnityLocatorService.GetLocator<IPersonDetailsService>();
                ViewBag.Persons = PersonService.GetPersonsList(new PersonListRequestFilter { PageIndex = 0, PageSize = 100 })
                    .Persons.Select(x => x.PersonID);
                ViewBag.Success = "Borrower has been updated!!";
                return View(BookOperationService.BorrowBookForPerson(borrowBookRqst));
            }
            catch(Exception ex)
            {
                Logger.Debug("Exception while Borrowing the book:" + borrowBookRqst+"By person:"+borrowBookRqst.PersonID);
                Logger.Error("An exception occured in Borrowing Book", ex);
                throw;
            }
        }
    }
}