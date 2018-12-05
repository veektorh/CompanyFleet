using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Contract;

namespace Infrastructure.Concrete
{


    internal class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext Db)
        {
            if (Db == null) throw new ArgumentNullException("Db");
            _context = Db;
            _dbSet = Db.Set<T>();
        }

        public T Add(T entity)
        {
            var entityAdded =  _dbSet.Add(entity);
            _context.SaveChanges();
            return entityAdded;
        }

        public IEnumerable<T> AddRange(List<T> entities)
        {
            var entitiesAdded =  _dbSet.AddRange(entities);
            _context.SaveChanges();
            return entitiesAdded;
        }

        public T Remove(T entity)
        {
            var entityRemoved =  _dbSet.Remove(entity);
            _context.SaveChanges();
            return entityRemoved;
        }

        public T Remove(object key)
        {
            var entity = _dbSet.Find(key);
            var entityRemoved = _dbSet.Remove(entity);
            _context.SaveChanges();
            return entityRemoved;
        }

        public T Update(T entity)
        {
            var updated = _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return updated;
        }

        public IEnumerable<T> UpdateRange(List<T> entities)
        {
            var retVals = new List<T>();
            foreach (var item in entities)
            {
                var updated = _dbSet.Attach(item);
                _context.Entry(item).State = EntityState.Modified;
                retVals.Add(updated);
            }
            _context.SaveChanges();
            return retVals;
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public T GetById(object key)
        {
            return _dbSet.Find(key);
        }

        

    }
}
