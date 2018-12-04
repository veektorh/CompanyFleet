using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompaniesFleet.Models
{
    public class CompanyCarViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
    }

    public class CompanyCarCreateViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Category { get; set; }
    }

    public class CompanyCarUpdateViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Category { get; set; }
    }
}