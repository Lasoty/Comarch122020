using Bibliotekarz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotekarz.Services
{
    public class BookService : IBookService
    {
        public void AddBook(Book item)
        {

        }

        public ICollection<Book> GetAll()
        {
            return new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Author = "Leszek Lewandowski",
                    PageCount = 456,
                    Title = "Programowanie w C#",
                    IsBorrowed = true,
                    Borrower = new Customer
                    {
                        Id = 1,
                        FirstName = "Adam",
                        LastName = "Nowak"
                    }

                }
            };

        }

        public ICollection<Book> GetBorrowedBooks()
        {
            return null;
        }
    }
}
