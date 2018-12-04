using CompaniesFleet.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace CompaniesFleet.Repositories
{
    public interface ICategoryRepository
    {
        bool Add(Category entity);
        IEnumerable<Category> AddRange(List<Category> entities);
        List<Category> GetAll();
        List<Category> GetAll(Expression<Func<Category, bool>> predicate);
        Category GetById(object key);
        bool Remove(Category entity);
        bool Remove(object key);
        bool Update(Category entity);
        IEnumerable<Category> UpdateRange(List<Category> entities);
    }
}
