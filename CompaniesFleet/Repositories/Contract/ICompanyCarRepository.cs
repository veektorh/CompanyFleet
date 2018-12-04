using CompaniesFleet.Helper;
using CompaniesFleet.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CompaniesFleet.Repositories
{
    public interface ICompanyCarRepository
    {
        CompanyCar Add(CompanyCar entity);
        IEnumerable<CompanyCar> AddRange(List<CompanyCar> entities);
        List<CompanyCar> GetAll();
        List<CompanyCar> GetAll(Expression<Func<CompanyCar, bool>> predicate);
        CompanyCar GetById(object key);
        bool Remove(CompanyCar entity);
        bool Remove(object key);
        CompanyCar Update(CompanyCar entity);
        IEnumerable<CompanyCar> UpdateRange(List<CompanyCar> entities);
    }
}
