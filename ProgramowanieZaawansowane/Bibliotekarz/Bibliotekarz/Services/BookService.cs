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
        private readonly AppDbContext dbContext;

        public BookService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void AddBook(Book item)
        {
            dbContext.Books.Add(item);
            dbContext.SaveChanges();
        }

        public ICollection<Book> GetAll()
        {
            return dbContext.Books.ToList();
        }

        public ICollection<Book> GetBorrowedBooks()
        {
            return dbContext.Books.Where(x => x.IsBorrowed == true).ToList();
        }
    }
}
