using System;

namespace BookStore.Core.Interfaces.Data.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository Books { get; }
        ICategoryRepository Categories { get; }

        int Complete();
    }
}
