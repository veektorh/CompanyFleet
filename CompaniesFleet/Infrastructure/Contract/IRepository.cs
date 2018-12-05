using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contract
{
    internal interface IRepository<T> where T : class 
    {
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
