using Bibliotekarz.Model;
using System.Collections.Generic;

namespace Bibliotekarz.Services
{
    public interface IBookService
    {
        void AddBook(Book item);
        ICollection<Book> GetAll();
        ICollection<Book> GetBorrowedBooks();
    }
}