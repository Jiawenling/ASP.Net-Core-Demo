using System;
using Demo.Data;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repository
{
	public class Repository<T>: IRepository<T> where T: class
	{
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
		public Repository(ApplicationDbContext db)
		{
            _db = db;
            this.dbSet = _db.Set<T>();
		}

        void IRepository<T>.Add(T entity)
        {
            dbSet.Add(entity);
        }

        T IRepository<T>.Get(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query.Where(filter);
            return query.FirstOrDefault();
        }

        IEnumerable<T> IRepository<T>.GetAll()
        {
            return dbSet.ToList();
        }

        void IRepository<T>.Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        void IRepository<T>.RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}

