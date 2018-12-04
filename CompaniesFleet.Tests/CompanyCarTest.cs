using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CompaniesFleet.Controllers;
using System.Web.Http.Results;
using CompaniesFleet.Models;
using System.Collections.Generic;
using System.Linq;
using CompaniesFleet.Repositories;
using Moq;

namespace CompaniesFleet.Tests
{
    [TestClass]
    public class CompanyCarTest
    {
        private ICompanyCarRepository _companyCarRepository;
        private ICategoryRepository _categoryRepository;
        private CompanyCarController _companyCarController;

        public CompanyCarTest()
        {
            _companyCarRepository = new CompanyCarRepository();
            _categoryRepository = new CategoryRepository();

            _companyCarController = new CompanyCarController(_companyCarRepository, _categoryRepository);
        }


        public void SetupMockRepo()
        {
            var compamyCarRepoMock = new Mock<CompanyCarRepository>();

            var carCategory = new Category() { Id = 1, Name = "Car" };
            var truckCategory = new Category() { Id = 2, Name = "Truck" };
            var suvCategory = new Category() { Id = 3, Name = "Suv" };

            var categoryList = new List<Category>()
            {
                carCategory,truckCategory,suvCategory
            };

            var companyCarList = new List<CompanyCar>()
            { 
                new CompanyCar(){  Id = 1, Name = "Toyota" , Category= carCategory, CategoryId = 1 },
                new CompanyCar(){  Id = 1, Name = "Lexus" , Category= suvCategory, CategoryId = 3 },
                new CompanyCar(){  Id = 1, Name = "Hilux" , Category= truckCategory, CategoryId = 2 },

            };
            compamyCarRepoMock.Setup(a => a.GetAll()).Returns(companyCarList);
            compamyCarRepoMock.Setup(a => a.GetById(It.IsAny<int>())).Returns((int c) => companyCarList.FirstOrDefault(a => a.Id == c));
            compamyCarRepoMock.Setup(a => a.Add(It.IsAny<CompanyCar>())).Returns((CompanyCar c) => c);
        }


        [TestMethod]
        public void GetAllCompanyTest()
        {

            var result = _companyCarController.Get() as OkNegotiatedContentResult<List<CompanyCar>>;

            Assert.IsNotNull(result.Content);
        }

        [TestMethod]
        public void GetCarByIdTest()
        {

            var result = _companyCarController.Get(3) as OkNegotiatedContentResult<CompanyCar>;


            Assert.IsNotNull(result.Content);
            Assert.AreEqual(result.Content.Id, 3);
        }

        [TestMethod]
        public void PostCompanyCarTest()
        {
            var model = new CompanyCarCreateViewModel() { Name = "Lexus", Category = 1 };
            var result = _companyCarController.Post(model) as OkNegotiatedContentResult<CompanyCar>;

            Assert.IsNotNull(result.Content);
            Assert.AreEqual(result.Content.Name, "Lexus");
        }

        [TestMethod]
        public void PutCompanyCarTest()
        {
            var model = new CompanyCarUpdateViewModel() { Id = 3, Name = "Hyundai", Category = 2 };
            var result = _companyCarController.Put(model) as OkNegotiatedContentResult<CompanyCar>;

            Assert.IsNotNull(result.Content);
            Assert.AreEqual(result.Content.Name, "Hyundai");
        }

        [TestMethod]
        public void DeleteCompanyCarTest()
        {
            var companyCarList = _companyCarController.Get() as OkNegotiatedContentResult<List<CompanyCar>>;
            var list = companyCarList.Content.ToList();
            if (list.Count > 0)
            {
                var rnd = new Random().Next(1, list.Count);
                var randomCompanyCar = list[rnd];

                if (randomCompanyCar.Id != 3)
                {
                    var result = _companyCarController.Delete(randomCompanyCar.Id) as OkNegotiatedContentResult<CompanyCar>;

                    Assert.IsNotNull(result.Content);
                }

            }
        }

        [TestMethod]
        public void NotFoundTest()
        {
            var result = _companyCarController.Get(100);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void BadRequestTest()
        {
            var model = new CompanyCarCreateViewModel() { Name = "victor" };

            var result = _companyCarController.Post(model);

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }
    }
}
