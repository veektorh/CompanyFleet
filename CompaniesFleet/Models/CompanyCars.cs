
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompaniesFleet.Models
{
    public class CompanyCar
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}