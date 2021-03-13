using MongoDB.Driver;

namespace BookStore.Core
{
    public interface IDbClient
    {
        IMongoCollection<Book> GetBooksCollection();
    }
}
