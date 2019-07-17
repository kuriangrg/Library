using BL.BookTransactionService;
using DAL.BookManager;
using DAL.PersonManager;
using LibrarySystem.Tests.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.BookModels;
using Model.PersonModel;
using Moq;
using Shared.IOCHelper;
using Shared.Logger;
using System;
using System.Linq;

namespace LibrarySystem.Tests.BL
{
    /// <summary>
    /// All possible Unit test cases for BookTransactionService
    /// </summary>
    [TestClass]
   public class BookTransactionsTest
    {
        Mock<IBooksDataManager> MockBookManager;
        Mock<IPersonsDataManager> MockPersonManager;
        Mock<ILogger> MockLogger;
        Mock<IUnityLocator> MockUnityLocator;
        IBorrowBookService bookTransaction;
      

        public BookTransactionsTest()
        {
            //Mock all the DAL and logger services
            MockBookManager = new Mock<IBooksDataManager>();
            MockPersonManager = new Mock<IPersonsDataManager>();
            MockLogger = new Mock<ILogger>();
            MockUnityLocator = new Mock<IUnityLocator>();

            //Define the unitylocator items
            MockUnityLocator.Setup(p => p.GetLocator<IBooksDataManager>()).Returns(MockBookManager.Object);
            MockUnityLocator.Setup(p => p.GetLocator<ILogger>()).Returns(MockLogger.Object);
            MockUnityLocator.Setup(p => p.GetLocator<IPersonsDataManager>()).Returns(MockPersonManager.Object);
            //Pass the mocked unitylocator
            bookTransaction = new BorrowBookService(MockUnityLocator.Object);
        }
        [TestMethod]
        public void BorrowBook_PassValidBookAndPersonIds_ReturnsUpdatedBookWithPerson()
        {
            BorrowBookRequest bookRequestFilter = new BorrowBookRequest { BookID="b101",PersonID="p101" };
            //Mock Data
            CatalogVM catalog = TestHelper.CreateBookList(3);
            Book bookData=catalog.Books.Where(b => b.BookID == bookRequestFilter.BookID).FirstOrDefault();
            bookData.PersonID = bookRequestFilter.PersonID;
            MockBookManager.Setup(p => p.UpdateBookWithPersonID(bookRequestFilter.BookID, bookRequestFilter.PersonID)).Returns(bookData);
            //Perform the act
            var result = bookTransaction.BorrowBookForPerson(bookRequestFilter);
            //Assert
            Assert.AreEqual(result.PersonID, bookRequestFilter.PersonID);
        }

        [TestMethod]
        public void BorrowBook_PassNullPersonID_ReturnsBookWithNoMappingToPerson()
        {
            BorrowBookRequest bookRequestFilter = new BorrowBookRequest { BookID = "b101", PersonID = null };
            //Mock Data
            CatalogVM catalog = TestHelper.CreateBookList(3);
            Book bookData = catalog.Books.Where(b => b.BookID == bookRequestFilter.BookID).FirstOrDefault();
            bookData.PersonID = bookRequestFilter.PersonID;
            MockBookManager.Setup(p => p.UpdateBookWithPersonID(bookRequestFilter.BookID, bookRequestFilter.PersonID)).Returns(bookData);
            //Perform the act
            var result = bookTransaction.BorrowBookForPerson(bookRequestFilter);
            //Assert
            Assert.AreEqual(result.PersonID, null);
        }

        [TestMethod]
        public void BorrowBook_InvalidBookID_ReturnsNull()
        {
            BorrowBookRequest bookRequestFilter = new BorrowBookRequest { BookID = "b11", PersonID = "p101" };
            //Mock Data
            CatalogVM catalog = TestHelper.CreateBookList(3);
            Book bookData = catalog.Books.Where(b => b.BookID == bookRequestFilter.BookID).FirstOrDefault();
            MockBookManager.Setup(p => p.UpdateBookWithPersonID(bookRequestFilter.BookID, bookRequestFilter.PersonID)).Returns(bookData);
            //Perform the act
            var result = bookTransaction.BorrowBookForPerson(bookRequestFilter);
            //Assert
            Assert.AreEqual(result, null);
        }
        [TestMethod]
        public void BorrowBook_NullRequest_ReturnsNull()
        {
            BorrowBookRequest bookRequestFilter = null;
            //Perform the act
            var result = bookTransaction.BorrowBookForPerson(bookRequestFilter);
            //Assert
            Assert.AreEqual(result, null);
        }

        [TestMethod]
        public void GetBorrowBookDetails_ValidBookID_ReturnsBorrowedBookDetails()
        {
            string bookID = "b101";
            //Mock Data
            CatalogVM catalog = TestHelper.CreateBookList(3);
            Book bookData = catalog.Books.Where(b => b.BookID == bookID).FirstOrDefault();
            Person personData = new Person { PersonID = "p101", Name = "Person1" };
            MockBookManager.Setup(p => p.GetBookDetails(bookID)).Returns(bookData);
            MockPersonManager.Setup(p => p.GetPersonDetails(bookData.PersonID)).Returns(personData);
            var actualData = new BookPersonVM { BookDetails = bookData, PersonDetails = personData };
            //Perform the act
            var result = bookTransaction.GetBorrowBookDetails(bookID);
            //Assert
            Assert.AreEqual(result.BookDetails, actualData.BookDetails);
            Assert.AreEqual(result.PersonDetails, actualData.PersonDetails);
        }

        [TestMethod]
        public void GetBorrowBookDetails_InValidBookID_ReturnsNullDetails()
        {
            string bookID = "b1011";
            //Mock Data
            CatalogVM catalog = TestHelper.CreateBookList(3);
            Book bookData = null;
            MockBookManager.Setup(p => p.GetBookDetails(bookID)).Returns(bookData);
            //Perform the act
            var result = bookTransaction.GetBorrowBookDetails(bookID);
            //Assert
            Assert.AreEqual(result, null);
        }

        [TestMethod]
        public void GetBorrowBookDetails_NullBookID_ReturnsNullDetails()
        {
            string bookID = null;
            //Mock Data
            CatalogVM catalog = TestHelper.CreateBookList(3);
            Book bookData = null;
            MockBookManager.Setup(p => p.GetBookDetails(bookID)).Returns(bookData);
            //Perform the act
            var result = bookTransaction.GetBorrowBookDetails(bookID);
            //Assert
            Assert.AreEqual(result, null);
        }
    }
}
