using CompaniesFleet.Models;
using CompaniesFleet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompaniesFleet.Helper
{
    public class HelperClasses
    {
    }

    public class Response
    {
        public bool Status { get; set; }
        public string Message { get; set; }

        public CompanyCarViewModel CompanyCar { get; set; }
    }
}