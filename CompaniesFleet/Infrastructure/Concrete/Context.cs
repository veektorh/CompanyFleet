using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Contract;
using System.Configuration;
using CompaniesFleet.Models;


namespace Infrastructure.Concrete
{
    public class Context : IContext
    {
        public DbContext AppDbContext { get; private set; }

        public Context()
        {
            AppDbContext = new ApplicationDbContext();
            //DataKioskDbContext.Configuration.LazyLoadingEnabled = false;
        }

        public Context(string conString)
        {
            AppDbContext = new DbContext(ConfigurationManager.ConnectionStrings[conString].ConnectionString);
            //AppDbContext.Configuration.LazyLoadingEnabled = false;
        }

        public void Dispose()
        {
            AppDbContext.Dispose();
        }

        
    }
}
