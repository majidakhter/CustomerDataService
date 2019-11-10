using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AromaCareGlow.Commerce.CustomerData.Infrastructure.Factory;
using AromaCareGlow.Commerce.CustomerData.Infrastructure.Context;
using AromaCareGlow.Commerce.CustomerData.Model;

namespace AromaCareGlow.Commerce.CustomerData.Domain.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
       
        private readonly IApplicationDbContextFactory dbContextFactory;

        public CustomerRepository(IApplicationDbContextFactory context)
        {
            dbContextFactory = context;
        }
        public async Task<Customer> GetCustomerByEmail(string emailId)
        {
            using (var context = dbContextFactory.Create())
            {
                var customers = await context.DbSet<Customer>()
                     .FirstOrDefaultAsync(x => x.Email == emailId);

                return customers;
            }
        }
        public async Task<Customer> GetCustomerRoleBySystemName(string registeredRoleName)
        {
            using (var context = dbContextFactory.Create())
            {
                var customers = await context.DbSet<Customer>()
                     .FirstOrDefaultAsync(x => x.SystemName == registeredRoleName);

                return customers;
            }
        }
        public async Task<Customer> GetCustomerByUsername(string username)
        {
            using (var context = dbContextFactory.Create())
            {
                var customers = await context.DbSet<Customer>()
                     .FirstOrDefaultAsync(x => x.Username == username);

                return customers;
            }
        }
        public async Task<Customer> GetByIDAsync(int id)
        {
            using (var context = dbContextFactory.Create())
            {
                var customer = await context.DbSet<Customer>()
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (customer == null)
                {
                    return null;
                }

                return customer;
            }
        }
        public async Task<CustomerPassword> GetCurrentPassword(int customerId)
        {
            using (var context = dbContextFactory.Create())
            {
                var customer = await context.DbSet<CustomerPassword>()
                    .FirstOrDefaultAsync(x => x.CustomerId == customerId);

                if (customer == null)
                {
                    return null;
                }

                return customer;
            }
        }
        public async Task<bool> Insert(CustomerPassword entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            
            using (var context = dbContextFactory.Create())
            {
                await context.DbSet<CustomerPassword>().AddAsync(entity);
                context.SaveChanges();
                return true;
            }
        }

        public bool  Update(Customer entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            using (var context = dbContextFactory.Create())
            {
                context.DbSet<Customer>().Update(entity);
                context.SaveChanges();
                return true;
            }
        }

       
    }
}
