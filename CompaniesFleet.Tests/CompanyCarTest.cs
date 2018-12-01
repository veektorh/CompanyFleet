using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CompaniesFleet.Controllers;
using System.Web.Http.Results;
using DevContactDirectory.Models;
using System.Collections.Generic;
using System.Linq;

namespace CompaniesFleet.Tests
{
    [TestClass]
    public class CompanyCarTest
    {
        //get all company car test
        //get car by id test
        //test exceptions
        //get car by wrong id test
        //get car by invalid id test
        //update car test
        //delete car test
        //

        [TestMethod]
        public void GetAllCompanyTest()
        {
            CompanyCarController companyCar = new CompanyCarController();

            var result = companyCar.Get() as OkNegotiatedContentResult<IEnumerable<CompanyCarViewModel>>;

            Assert.IsNotNull(result.Content);
        }

        [TestMethod]
        public void GetCarByIdTest()
        {
            CompanyCarController companyCar = new CompanyCarController();

            var result = companyCar.Get(1) as OkNegotiatedContentResult<CompanyCarViewModel>;


            Assert.IsNotNull(result.Content);
            Assert.AreEqual(result.Content.Id, 1);
        }

        [TestMethod]
        public void PostCompanyCarTest()
        {
            CompanyCarController companyCar = new CompanyCarController();
            var model = new CompanyCarCreateViewModel() { Name = "Lexus", Category = 1 };
            var result = companyCar.Post(model) as OkNegotiatedContentResult<CompanyCarViewModel>;

            Assert.IsNotNull(result.Content);
            Assert.AreEqual(result.Content.Name, "Lexus");
        }

        [TestMethod]
        public void PutCompanyCarTest()
        {
            CompanyCarController companyCar = new CompanyCarController();
            
            var model = new CompanyCarUpdateViewModel() {Id=1, Name = "Hyundai", Category = 2 };
            var result = companyCar.Put(model) as OkNegotiatedContentResult<CompanyCarViewModel>;

            Assert.IsNotNull(result.Content);
            Assert.AreEqual(result.Content.Name, "Hyundai");
        }

        [TestMethod]
        public void DeleteCompanyCarTest()
        {
            CompanyCarController companyCar = new CompanyCarController();

            var companyCarList = companyCar.Get() as OkNegotiatedContentResult<IEnumerable<CompanyCarViewModel>>;
            var list = companyCarList.Content.ToList();
            if (list.Count > 0)
            {
                var rnd = new Random().Next(1, list.Count);
                var randomCompanyCar = list[rnd];
                var result = companyCar.Delete(randomCompanyCar.Id) as OkNegotiatedContentResult<CompanyCarViewModel>;

                Assert.IsNotNull(result.Content);
            }
        }

        [TestMethod]
        public void NotFoundTest()
        {
            CompanyCarController companyCar = new CompanyCarController();

            var result = companyCar.Get(100);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void BadRequestTest()
        {
            CompanyCarController companyCar = new CompanyCarController();
            var model = new CompanyCarCreateViewModel() { Name = "victor" };

            var result = companyCar.Post(model);

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }
    }
}
