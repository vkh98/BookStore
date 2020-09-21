using BookStore.Core.Entities;
using BookStore.Core.Interfaces.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Infrastructure.Data.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(BookStoreContext context) : base(context)
        {

        }
        public IEnumerable<Book> GetBooksWithCategories(int pageIndex, int pageSize = 10)
        {
            return ApplicationContext.Books
                .Include(q => q.Category)
                .OrderBy(q => q.Name)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public IEnumerable<Book> GetTopSellingBooks(int count)
        {
            return ApplicationContext.Books.OrderByDescending(q => q.Price).Take(count).ToList();
        }
        public BookStoreContext ApplicationContext { get { return Context as BookStoreContext; } }
    }
}
