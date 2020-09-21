using BookStore.Core.Entities;
using System.Collections.Generic;

namespace BookStore.Core.Interfaces.Data.Repository
{
    public interface IBookRepository : IRepository<Book>
    {
        IEnumerable<Book> GetTopSellingBooks(int count);

        IEnumerable<Book> GetBooksWithCategories(int pageIndex, int pageSize);
    }
}
