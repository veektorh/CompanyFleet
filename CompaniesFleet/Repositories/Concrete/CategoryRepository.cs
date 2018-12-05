using CompaniesFleet.Models;
using Infrastructure.Concrete;
using Infrastructure.Contract;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CompaniesFleet.Repositories
{
    public class CategoryRepository : CompaniesFleet.Repositories.ICategoryRepository
    {
        private readonly IRepository<Category> repository;
        private readonly DbContext Db;
        Logger logger = LogManager.GetLogger("ErrorLogger");

        public CategoryRepository()
        {
            Db = new ApplicationDbContext();
            repository = new Repository<Category>(Db);
        }

        public bool Add(Category entity)
        {
            try
            {
                repository.Add(entity);
                return true;
            }
            catch (Exception ex)
            {
                logger.Error("Namespace:CategoryRepository || \t Method: Add ||\t Ex.Msg : " + ex.Message);
                return false;

            }
        }

        public IEnumerable<Category> AddRange(List<Category> entities)
        {
            try
            {
                return repository.AddRange(entities);
            }
            catch (Exception ex)
            {
                logger.Error("Namespace:CategoryRepository || \t Method: AddRange ||\t Ex.Msg : " + ex.Message);
                return null;
            }
        }

        public bool Remove(Category entity)
        {
            try
            {
                repository.Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                logger.Error("Namespace:CategoryRepository || \t Method: Remove ||\t Ex.Msg : " + ex.Message);
                return false;
            }
        }

        public bool Remove(object key)
        {
            try
            {
                repository.Remove(key);
                return true;
            }
            catch (Exception ex)
            {
                logger.Error("Namespace:CategoryRepository || \t Method: Remove ||\t  Ex.Msg : " + ex.Message);
                return false;
            }
        }

        public bool Update(Category entity)
        {
            try
            {
                repository.Update(entity);
                return true;
            }
            catch (Exception ex)
            {
                logger.Error("Namespace:CategoryRepository || \t Method: Update ||\t Ex.Msg : " + ex.Message);
                return false;
            }
        }

        public IEnumerable<Category> UpdateRange(List<Category> entities)
        {
            try
            {
                return repository.UpdateRange(entities);
            }
            catch (Exception ex)
            {
                logger.Error("Namespace:CategoryRepository || \t Method: UpdateRange ||\t Ex.Msg : " + ex.Message);
                return null;
            }
        }

        public List<Category> GetAll()
        {
            try
            {
                return repository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                logger.Error("Namespace:CategoryRepository || \t Method: GetAll ||\t Ex.Msg : " + ex.Message);
                return null;
            }
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> predicate)
        {
            try
            {
                return repository.GetAll(predicate).ToList();
            }
            catch (Exception ex)
            {
                logger.Error("Namespace:CategoryRepository || \t Method: GetAll(predicate) ||\t Ex.Msg : " + ex.Message);
                return null;
            }
        }

        public Category GetById(object key)
        {
            try
            {
                return repository.GetById(key);
            }
            catch (Exception ex)
            {
                logger.Error("Namespace:CategoryRepository || \t Method: GetById() ||\t Ex.Msg : " + ex.Message);
                return null;
            }
        }
    }
}
