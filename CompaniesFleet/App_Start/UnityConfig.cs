using CompaniesFleet.Repositories;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace CompaniesFleet
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<ICompanyCarRepository, CompanyCarRepository>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}