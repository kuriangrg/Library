using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.PersonModel;
using System.Linq;
using DAL.PersonManager;
using BL.PersonService;
using Moq;
using Model.PersonModels;
using LibrarySystem.Tests.Helper;
using Shared.Logger;
using Shared.IOCHelper;

namespace LibrarySystem.Tests.BL
{
    [TestClass]
    public class PersonDetailsServiceTest
    {
        Mock<IPersonsDataManager> MockPersonManager;
        Mock<ILogger> MockLogger;
        Mock<IUnityLocator> MockUnityLocator;
        IPersonDetailsService personDetails;
        int TotalPersonsCount;

        public PersonDetailsServiceTest()
        {
            MockLogger = new Mock<ILogger>();
            MockPersonManager = new Mock<IPersonsDataManager>();
            MockUnityLocator = new Mock<IUnityLocator>();

            //Define the unitylocator items
            MockUnityLocator.Setup(p => p.GetLocator<ILogger>()).Returns(MockLogger.Object);
            MockUnityLocator.Setup(p => p.GetLocator<IPersonsDataManager>()).Returns(MockPersonManager.Object);
            personDetails = new PersonDetailsService(MockUnityLocator.Object);
            TotalPersonsCount = 3;
        }

        [TestMethod]
        public void GetBookList_RetreiveAll_ReturnsAllList()
        {
            //Create Request
            PersonListRequestFilter personRequestFilter = new PersonListRequestFilter { PageIndex = 0, PageSize = int.MaxValue };
            //Mock Data
            PersonVM personModel = TestHelper.CreatePersonList(TotalPersonsCount);
            MockPersonManager.Setup(p => p.GetPersonsList(personRequestFilter.PageIndex, personRequestFilter.PageSize)).Returns(personModel);
            //Perform the act
            var result = personDetails.GetPersonsList(personRequestFilter);
            //Assert
            Assert.AreEqual(result.Persons.Count(),3);
            Assert.AreEqual(result.Persons[0].Name, personModel.Persons[0].Name);
            Assert.AreEqual(result.TotalPersons, TotalPersonsCount);
        }

        [TestMethod]
        public void GetBookList_Pass0Pagesize_ReturnsEmptyList()
        {
           
            //Create Request
            PersonListRequestFilter personRequestFilter = new PersonListRequestFilter { PageIndex = 0, PageSize = 0 };
            //Mock Data
            PersonVM personModel = TestHelper.CreatePersonList(0);
            MockPersonManager.Setup(p => p.GetPersonsList(personRequestFilter.PageIndex, personRequestFilter.PageSize)).Returns(personModel);
            //Perform the act
            var result = personDetails.GetPersonsList(personRequestFilter);
            //Assert
            Assert.AreEqual(result.Persons.Count(), 0);
        }
        [TestMethod]
        public void GetBookList_PassIndex1AndSize1_ReturnsListCount1()
        {
            //Create Request
            PersonListRequestFilter personRequestFilter = new PersonListRequestFilter { PageIndex = 1, PageSize = 1 };
            //Mock Data
            PersonVM personModel = TestHelper.CreatePersonList(1);
            MockPersonManager.Setup(p => p.GetPersonsList(personRequestFilter.PageIndex, personRequestFilter.PageSize)).Returns(personModel);
            //Perform the act
            var result = personDetails.GetPersonsList(personRequestFilter);
            //Assert
            Assert.AreEqual(result.Persons.Count, 1);
           
        }

        [TestMethod]
        public void GetBookList_NullRequest_ReturnsListCount1()
        {
            //Create Request
            PersonListRequestFilter personRequestFilter = new PersonListRequestFilter { PageIndex = 1, PageSize = 1 };
            //Mock Data
            PersonVM personModel =TestHelper.CreatePersonList(1);
            MockPersonManager.Setup(p => p.GetPersonsList(personRequestFilter.PageIndex, personRequestFilter.PageSize)).Returns(personModel);
            //Perform the act
            var result = personDetails.GetPersonsList(personRequestFilter);
            //Assert
            Assert.AreEqual(result.Persons.Count, 1);
          
        }

        [TestMethod]
        public void GetBookList_NullRequest_ReturnsNull()
        {
            PersonListRequestFilter personRequestFilter = null;
            //Perform the act
            var result = personDetails.GetPersonsList(personRequestFilter);
            //Assert
            Assert.AreEqual(result, null);
        }
    }
}
