using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CompaniesFleet.Controllers;
using System.Web.Http.Results;
using DevContactDirectory.Models;

namespace CompaniesFleet.Tests
{
    [TestClass]
    public class UnitTest1
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
        public void GetCarByIdTest()
        {
            CompanyCarController companyCar = new CompanyCarController();

            var result = companyCar.Get(1) as OkNegotiatedContentResult<CompanyCarViewModel>;


            Assert.IsNotNull(result.Content);
            Assert.AreEqual(result.Content.Id, 1);
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
