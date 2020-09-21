using BookStore.Core.Interfaces;
using BookStore.Core.Interfaces.Data.Repository;

namespace BookStore.Infrastructure.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookStoreContext _context;

        public UnitOfWork(BookStoreContext context)
        {
            _context = context;
            Books = new BookRepository(_context);


        }
        public IBookRepository Books { get; private set; }

        public ICategoryRepository Categories { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
