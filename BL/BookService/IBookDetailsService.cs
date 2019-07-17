using Model.BookModels;
namespace BL.BookService
{
    /// <summary>
    /// The contract which serves the details of a book
    /// in library
    /// </summary>
    public interface IBookDetailsService
    {
        Book GetBookDetail(string bookID);
        CatalogVM GetBookList(BookListRequestFilter booksFilter);
    }
}
