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
        private readonly IUnitOfWork _context;
        private readonly DbSet<T> _dbSet;
        private readonly DbContext _dbContext;

        public Repository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
            _context = unitOfWork;
            _dbSet = unitOfWork.Context.AppDbContext.Set<T>();
            _dbContext = unitOfWork.Context.AppDbContext;
        }

        public DbContext RepositoryContext()
        {
            return _dbContext;
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
            _context.Context.AppDbContext.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return updated;
        }

        public IEnumerable<T> UpdateRange(List<T> entities)
        {
            var retVals = new List<T>();
            foreach (var item in entities)
            {
                var updated = _dbSet.Attach(item);
                _context.Context.AppDbContext.Entry(item).State = EntityState.Modified;
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
