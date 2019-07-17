using Model.BookModels;

namespace BL.BookTransactionService
{
    public interface  IBorrowBookService
    {
        BookPersonVM GetBorrowBookDetails(string bookID);
        Book BorrowBookForPerson(BorrowBookRequest borrowalRequest);
        Book ReturnBook(string bookID);
    }
}
