using BookStore.Core.Interfaces.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BookStore.Infrastructure.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        private readonly DbSet<T> dbset;
        public Repository(DbContext context)
        {
            Context = context;
            dbset = Context.Set<T>();
        }

        public T Get(int id)
        {
            return dbset.Find(id);
        }
        public IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return dbset.Where(predicate);
        }

        public void Add(T entity)
        {
            dbset.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            dbset.AddRange(entities);
        }


        public void Remove(int id)
        {
            dbset.Remove(Get(id));
        }

        public void Remove(T entity)
        {
            dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbset.RemoveRange(entities);
        }
    }
    public abstract class RepositoryTemp<T> : IRepositoryTemp<T> where T : class
    {
        private readonly DbContext dbContext;
        protected readonly DbSet<T> dbset;
        public RepositoryTemp(DbContext dbContext)
        {
            this.dbContext = dbContext;
            dbset = dbContext.Set<T>();
        }
        public void Add(T entity)
        {
            dbset.Add(entity);
        }

        public T Get(int id)
        {
            return dbset.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, string includeProperties = null)
        {
            IQueryable<T> query = dbset;
            if (filter != null)
                query.Concat(query.Where(filter));
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query.Concat(query.Include(includeProperty));
                }
            }
            if (orderby != null)
                return orderby(query).ToList();

            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbset;
            if (filter != null)
                query.Concat(query.Where(filter));
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query.Concat(query.Include(includeProperty));
                }
            }

            return query.FirstOrDefault();
        }

        public void Remove(int id)
        {
            dbset.Remove(Get(id));
        }

        public void Remove(T entity)
        {
            dbset.Remove(entity);
        }
    }
}
