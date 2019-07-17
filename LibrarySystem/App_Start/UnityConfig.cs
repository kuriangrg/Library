using BL.BookService;
using BL.BookTransactionService;
using BL.PersonService;
using DAL.BookManager;
using DAL.PersonManager;
using LibrarySystem.IOCLocator;
using Shared.IOCHelper;
using Shared.Logger;
using System.Web.Configuration;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Injection;

namespace LibrarySystem
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        public static IUnityContainer Container;
        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        public static void RegisterTypes()
        {
            Container = new UnityContainer();
            Container.RegisterType<IBookDetailsService, BookDetailsService>();
            Container.RegisterType<IPersonDetailsService,PersonDetailsService>();
            Container.RegisterType< IBorrowBookService, BorrowBookService>();
            Container.RegisterType<IBooksDataManager, InMemBookDataManager>
              (new InjectionConstructor(new object[] {new LibLogger(), WebConfigurationManager.AppSettings["books"] }));
            Container.RegisterType<IPersonsDataManager, InMemPersonsDataManager>
              (new InjectionConstructor(new object[] { new LibLogger(), WebConfigurationManager.AppSettings["persons"] }));
            Container.RegisterType<ILogger, LibLogger>();
            Container.RegisterType<IUnityLocator, UnityLocator>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(Container));
        }
    }
}