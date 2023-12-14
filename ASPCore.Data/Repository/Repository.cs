using CoreASP.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreASP.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> _dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this._dbSet = db.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            IQueryable<T> querry = _dbSet;
            return querry.ToList();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> querry = _dbSet;
            querry = querry.Where(filter);

            return querry.FirstOrDefault();
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
}
