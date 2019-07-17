using Model.BookModels;
using Model.PersonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Tests.Helper
{
    /// <summary>
    /// Create sample test data for testing
    /// </summary>
    class TestHelper
    {
        /// <summary>
        /// Create sample test data catalog data
        /// </summary>
        /// <param name="bookListCount">Count on how many books to return</param>
        /// <returns></returns>
        public static CatalogVM CreateBookList(int bookListCount)
        {
            Book book1 = new Book
            {
                BookID = "b101",
                Author = "Book1 Author",
                Description = "Book1 Description",
                Genre = "Book1 Genre",
                PersonID = "p101",
                Price = 250,
                Title = "Book1 Title"
            };
            Book book2 = new Book
            {
                BookID = "b102",
                Author = "Book2 Author",
                Description = "Book2 Description",
                Genre = "Book2 Genre",
                PersonID = "p102",
                Price = 250,
                Title = "Book2 Title"
            };
            Book book3 = new Book
            {
                BookID = "b103",
                Author = "Book3 Author",
                Description = "Book3 Description",
                Genre = "Book3 Genre",
                PersonID = "p102",
                Price = 250,
                Title = "Book3 Title"
            };
            List<Book> bookList = new List<Book>();
            bookList.Add(book1);
            bookList.Add(book2);
            bookList.Add(book3);

            CatalogVM catalog = new CatalogVM { Books = bookList.GetRange(0, bookListCount), TotalBooks = bookListCount };
            return catalog;
        }

        /// <summary>
        ///  Create sample test data person data
        /// </summary>
        /// <param name="personListCount"></param>
        /// <returns>Count on how many persons to return</returns>
        public static PersonVM CreatePersonList(int personListCount)
        {
            Person person1 = new Person
            {

                PersonID = "p101",
                Name = "Person1"
            };
            Person person2 = new Person
            {

                PersonID = "p102",
                Name = "Person2"
            };
            Person person3 = new Person
            {

                PersonID = "p103",
                Name = "Person3"
            };

            List<Person> personsList = new List<Person>();
            personsList.Add(person1);
            personsList.Add(person2);
            personsList.Add(person3);

            PersonVM personListModel = new PersonVM { Persons = personsList.GetRange(0, personListCount), TotalPersons = personListCount };
            return personListModel;
        }
    }
}
