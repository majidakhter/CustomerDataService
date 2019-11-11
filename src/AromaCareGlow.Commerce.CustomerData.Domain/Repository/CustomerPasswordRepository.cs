using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AromaCareGlow.Commerce.CustomerData.Infrastructure.Context;
using AromaCareGlow.Commerce.CustomerData.Infrastructure.Factory;
using AromaCareGlow.Commerce.CustomerData.Model;
using Microsoft.EntityFrameworkCore;

namespace AromaCareGlow.Commerce.CustomerData.Domain.Repository
{
    public class CustomerPasswordRepository : ICustomerPasswordRepository
    {
        private readonly IApplicationDbContextFactory dbContextFactory;

        public CustomerPasswordRepository(IApplicationDbContextFactory context)
        {
            dbContextFactory = context;
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

        public bool Update(CustomerPassword entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            using (var context = dbContextFactory.Create())
            {
                context.DbSet<CustomerPassword>().Update(entity);
                context.SaveChanges();
                return true;
            }
        }
    }
}
