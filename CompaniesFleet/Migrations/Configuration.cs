namespace CompaniesFleet.Migrations
{
    using CompaniesFleet.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CompaniesFleet.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CompaniesFleet.Models.ApplicationDbContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.Add(new Category() { Name = "Car" });
                context.Categories.Add(new Category() { Name = "Truck" });
                context.SaveChanges();
            }

            if (context.Categories.Any() && !context.CompanyCars.Any())
            {
                var cat = context.Categories.FirstOrDefault();
                context.CompanyCars.Add(new CompanyCar() { Name = "Toyota X1", CategoryId = cat.Id,  });
                context.SaveChanges();
            }
        }
    }
}
