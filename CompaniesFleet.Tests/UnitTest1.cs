using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CompaniesFleet.Controllers;

namespace CompaniesFleet.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CompanyCarController companyCar = new CompanyCarController();

            var result = companyCar.Get();

            Assert.IsNotNull(result);
        }
    }
}
