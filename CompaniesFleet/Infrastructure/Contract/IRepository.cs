using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contract
{
    public enum SortOrder { Ascending = 1, Descending }
    internal interface IRepository<T> where T : class 
    {
        DbContext RepositoryContext();
        T Add(T entity);
        IEnumerable<T> AddRange(List<T> entities);
        T Remove(T entity);
        T Remove(object key);
        T Update(T entity);
        IEnumerable<T> UpdateRange(List<T> entities);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        T GetById(object key);
        
    }
}
