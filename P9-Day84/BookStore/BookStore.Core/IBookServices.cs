
using System.Collections.Generic;

namespace BookStore.Core
{
    public interface IBookServices
    {
        List<Book> GetBooks();
        Book AddBook(Book book);
        Book GetBook(string id);
        void DeleteBook(string id);
        Book UpdateBook(Book book);
    }
}
