using CompaniesFleet.Helper;
using CompaniesFleet.Models;
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
    public class CompanyCarRepository : CompaniesFleet.Repositories.ICompanyCarRepository
    {
        private readonly IRepository<CompanyCar> repository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly DbContext Db;
        Logger logger = LogManager.GetLogger("ErrorLogger");

        public CompanyCarRepository()
        {
            Db = new ApplicationDbContext();
            repository = new Repository<CompanyCar>(Db);
            _categoryRepository = new Repository<Category>(Db);
        }

        public CompanyCar Add(CompanyCar entity)
        {
            var response = new Response();
            try
            {

                return repository.Add(entity);

            }
            catch (Exception ex)
            {
                logger.Error("Namespace:CompanyCarRepository || \t Method: Add ||\t Ex.Msg : " + ex.Message);
                return null;

            }
        }

        public IEnumerable<CompanyCar> AddRange(List<CompanyCar> entities)
        {
            try
            {
                return repository.AddRange(entities);
            }
            catch (Exception ex)
            {
                logger.Error("Namespace:CompanyCarRepository || \t Method: AddRange ||\t Ex.Msg : " + ex.Message);
                return null;
            }
        }

        public bool Remove(CompanyCar entity)
        {
            try
            {
                repository.Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                logger.Error("Namespace:CompanyCarRepository || \t Method: Remove ||\t Ex.Msg : " + ex.Message);
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
                logger.Error("Namespace:CompanyCarRepository || \t Method: Remove ||\t  Ex.Msg : " + ex.Message);
                return false;
            }
        }

        public CompanyCar Update(CompanyCar entity)
        {
            try
            {
                return repository.Update(entity);

            }
            catch (Exception ex)
            {
                logger.Error("Namespace:CompanyCarRepository || \t Method: Update ||\t Ex.Msg : " + ex.Message);
                return null;
            }
        }

        public IEnumerable<CompanyCar> UpdateRange(List<CompanyCar> entities)
        {
            try
            {
                return repository.UpdateRange(entities);
            }
            catch (Exception ex)
            {
                logger.Error("Namespace:CompanyCarRepository || \t Method: UpdateRange ||\t Ex.Msg : " + ex.Message);
                return null;
            }
        }

        public List<CompanyCar> GetAll()
        {
            try
            {
                return repository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                logger.Error("Namespace:CompanyCarRepository || \t Method: GetAll ||\t Ex.Msg : " + ex.Message);
                return new List<CompanyCar>();
            }
        }

        public List<CompanyCar> GetAll(Expression<Func<CompanyCar, bool>> predicate)
        {
            try
            {
                return repository.GetAll(predicate).ToList();
            }
            catch (Exception ex)
            {
                logger.Error("Namespace:CompanyCarRepository || \t Method: GetAll(predicate) ||\t Ex.Msg : " + ex.Message);
                return new List<CompanyCar>();
            }
        }

        public CompanyCar GetById(object key)
        {
            try
            {
                return repository.GetById(key);
                //var CompanyCarViewModel = new CompanyCarViewModel();
                //CompanyCarViewModel.Id = CompanyCar.Id;
                //CompanyCarViewModel.Name = CompanyCar.Name;
                //CompanyCarViewModel.Category = CompanyCar.Category.Name;
                
                //return CompanyCarViewModel;
            }
            catch (Exception ex)
            {
                logger.Error("Namespace:CompanyCarRepository || \t Method: GetById() ||\t Ex.Msg : " + ex.Message);
                return null;
            }
        }
    }
}
