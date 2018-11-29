using CompaniesFleet.Helper;
using CompaniesFleet.Models;
using DevContactDirectory.Models;
using Infrastructure.Concrete;
using Infrastructure.Contract;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CompaniesFleet.Data.Repositories
{
    public class CompanyCarRepository
    {
        private readonly IRepository<CompanyCar> repository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IUnitOfWork uoWork;
        Logger logger = LogManager.GetLogger("ErrorLogger");

        public CompanyCarRepository()
        {
            uoWork = new UnitOfWork();
            repository = new Repository<CompanyCar>(uoWork);
            _categoryRepository = new Repository<Category>(uoWork);
        }

        public Response Add(CompanyCar entity)
        {
            var response = new Response();
            try
            {
                var category = _categoryRepository.GetById(entity.CategoryId);

                if (category == null)
                {
                    response.Message = "Invalid Category";
                    return response;
                }

                var CompanyCar = repository.Add(entity);

                var CompanyCarViewModel = new CompanyCarViewModel();
                CompanyCarViewModel.Id = CompanyCar.Id;
                CompanyCarViewModel.Name = CompanyCar.Name;
                CompanyCarViewModel.Category = CompanyCar.Category.Name;

                response.Status = true;
                response.CompanyCar = CompanyCarViewModel;
                return response;
            }
            catch (Exception ex)
            {
                logger.Error("Namespace:CompanyCarRepository || \t Method: Add ||\t Ex.Msg : " + ex.Message);
                return response;

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

        public CompanyCarViewModel Update(CompanyCar entity)
        {
            try
            {
                var CompanyCar =  repository.Update(entity);

                var CompanyCarViewModel = new CompanyCarViewModel();
                CompanyCarViewModel.Id = CompanyCar.Id;
                CompanyCarViewModel.Name = CompanyCar.Name;
                CompanyCarViewModel.Category = CompanyCar.Category.Name;

                return CompanyCarViewModel;
            }
            catch (Exception ex)
            {
                logger.Error("Namespace:CompanyCarRepository || \t Method: Update ||\t Ex.Msg : " + ex.Message);
                return new CompanyCarViewModel();
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

        public CompanyCarViewModel GetById(object key)
        {
            try
            {
                var CompanyCar = repository.GetById(key);
                var CompanyCarViewModel = new CompanyCarViewModel();
                CompanyCarViewModel.Id = CompanyCar.Id;
                CompanyCarViewModel.Name = CompanyCar.Name;
                CompanyCarViewModel.Category = CompanyCar.Category.Name;
                
                return CompanyCarViewModel;
            }
            catch (Exception ex)
            {
                logger.Error("Namespace:CompanyCarRepository || \t Method: GetById() ||\t Ex.Msg : " + ex.Message);
                return null;
            }
        }
    }
}
