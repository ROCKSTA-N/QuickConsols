using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data.Repositories
{
    public class RepositoryBase<T> : IRepository<T>
        where T : class
   
    {
        private DbSet<T> _dbSet;
        protected DbSet<T> DbSet
        {
            get => _dbSet ??= Context.Set<T>();
        }
        protected DbContext Context { get; }

        public RepositoryBase(DbContext context)
        {
            Context = context;
        } 

        public T Find<TKey>(TKey id)
        {
            return DbSet.Find(id);
        }


        public void  Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Update(entity);
        }

        public IQueryable<T> List(Expression<Func<T, bool>> expression)
        {
            return DbSet.Where(expression);
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
        }
    }
}
