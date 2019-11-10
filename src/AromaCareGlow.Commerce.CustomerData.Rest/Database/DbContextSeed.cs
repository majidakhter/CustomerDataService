using AromaCareGlow.Commerce.CustomerData.Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AromaCareGlow.Commerce.CustomerData.Rest.Database
{
    public class DbContextSeed : IDbContextSeed
    {
        private readonly IConfiguration configuration;

        public DbContextSeed(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Seed(ModelBuilder modelBuilder)
        {
            // Add Customers:
            //var customer1 = new Customer { Id = 1, FirstName = "Philipp", LastName = "Wagner" };
            //var customer2 = new Customer { Id = 2, FirstName = "Max", LastName = "Mustermann" };


            //modelBuilder.Entity<Model.Customer>()
            //    .HasData(customer1, customer2);
        }
    }
}
