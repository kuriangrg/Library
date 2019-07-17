using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DAL.BookManager;
using Model.BookModels;
using BL.BookService;
using LibrarySystem.Tests.Helper;
using Shared.Logger;
using Shared.IOCHelper;

namespace LibrarySystem.Tests.Controllers
{
    /// <summary>
    /// All possible Unit test cases for BookDetailsServie
    /// </summary>
    [TestClass]
    public class BookDetailsServiceTest
    {
        Mock<IBooksDataManager> MockBookManager;
        Mock<ILogger> MockLogger;
        Mock<IUnityLocator> MockUnityLocator;
        IBookDetailsService bookDetails;
        int TotalBooksCount;


        public BookDetailsServiceTest()
        {
            MockLogger = new Mock<ILogger>();
            MockUnityLocator = new Mock<IUnityLocator>();
            MockBookManager = new Mock<IBooksDataManager>();
            MockUnityLocator = new Mock<IUnityLocator>();

            MockUnityLocator.Setup(p => p.GetLocator<IBooksDataManager>()).Returns(MockBookManager.Object);
            MockUnityLocator.Setup(p => p.GetLocator<ILogger>()).Returns(MockLogger.Object);
            bookDetails = new BookDetailsService(MockUnityLocator.Object);
            TotalBooksCount = 3;
        }

        [TestMethod]
        public void GetBookList_RetreiveAll_ReturnsAllList()
        {
            //Create Request
            BookListRequestFilter bookRequestFilter = new BookListRequestFilter { PageIndex = 0, PageSize = int.MaxValue };
            //Mock Data
            CatalogVM catalog = TestHelper.CreateBookList(TotalBooksCount);
            MockBookManager.Setup(p => p.GetBooks(bookRequestFilter.PageIndex, bookRequestFilter.PageSize)).Returns(catalog);
            //Perform the act
            var result = bookDetails.GetBookList(bookRequestFilter);
            //Assert
            Assert.AreEqual(result.Books.Count(), TotalBooksCount);
            Assert.AreEqual(result.Books[0].Author, catalog.Books[0].Author);
            Assert.AreEqual(result.TotalBooks, TotalBooksCount);
        }

        [TestMethod]
        public void GetBookList_Pass0Pagesize_ReturnsEmptyList()
        {
            //Create Request
            BookListRequestFilter bookRequestFilter = new BookListRequestFilter { PageIndex = 0, PageSize = 0 };
            //Mock Data
            CatalogVM catalog = TestHelper.CreateBookList(0);
            MockBookManager.Setup(p => p.GetBooks(bookRequestFilter.PageIndex, bookRequestFilter.PageSize)).Returns(catalog);
            //Perform the act
            var result = bookDetails.GetBookList(bookRequestFilter);
            //Assert
            Assert.AreEqual(result.Books.Count(), 0);

        }
        [TestMethod]
        public void GetBookList_PassIndex1AndSize1_ReturnsListCount1()
        {
            //Create Request
            BookListRequestFilter bookRequestFilter = new BookListRequestFilter { PageIndex = 1, PageSize = 1 };
            //Mock Data
            CatalogVM catalog = TestHelper.CreateBookList(1);
            MockBookManager.Setup(p => p.GetBooks(bookRequestFilter.PageIndex, bookRequestFilter.PageSize)).Returns(catalog);
            //Perform the act
            var result = bookDetails.GetBookList(bookRequestFilter);
            //Assert
            Assert.AreEqual(result.Books.Count, 1);
        }

        [TestMethod]
        public void BorrowBook_NullRequest_ReturnsNull()
        {
            BookListRequestFilter bookRequestFilter = null;
            //Perform the act
            var result = bookDetails.GetBookList(bookRequestFilter);
            //Assert
            Assert.AreEqual(result, null);
        }

        [TestMethod]
        public void GetBookDetails_PassValidBookID_RetreiveBook()
        {
            //Create Request
            string bookID = "b101";
            //Mock Data
            CatalogVM catalog = TestHelper.CreateBookList(TotalBooksCount);
            Book bookData = catalog.Books.Where(b => b.BookID == bookID).FirstOrDefault();
            MockBookManager.Setup(p => p.GetBookDetails(bookID)).Returns(bookData);
            //Perform the act
            var result = bookDetails.GetBookDetail(bookID);
            //Assert
            Assert.AreEqual(result, bookData);
        }

        [TestMethod]
        public void GetBookDetails_PassInValidBookID_ReturnNull()
        {
            //Create Request
            string bookID = "c101";
            //Mock Data
            CatalogVM catalog = TestHelper.CreateBookList(3);
            Book bookData = catalog.Books.Where(b => b.BookID == bookID).FirstOrDefault();
            MockBookManager.Setup(p => p.GetBookDetails(bookID)).Returns(bookData);
            //Perform the act
            var result = bookDetails.GetBookDetail(bookID);
            //Assert
            Assert.AreEqual(result, null);
        }

        [TestMethod]
        public void GetBookDetails_PassNullBookID_ReturnNull()
        {
            //Create Request
            string bookID = null;
            //Mock Data
            CatalogVM catalog = TestHelper.CreateBookList(3);
            Book bookData = catalog.Books.Where(b => b.BookID == bookID).FirstOrDefault();
            MockBookManager.Setup(p => p.GetBookDetails(bookID)).Returns(bookData);
            //Perform the act
            var result = bookDetails.GetBookDetail(bookID);
            //Assert
            Assert.AreEqual(result, null);
        }
    }
}
