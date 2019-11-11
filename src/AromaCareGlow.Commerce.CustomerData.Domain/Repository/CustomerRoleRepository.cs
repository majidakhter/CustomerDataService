using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AromaCareGlow.Commerce.CustomerData.Infrastructure.Factory;
using AromaCareGlow.Commerce.CustomerData.Model;
using AromaCareGlow.Commerce.CustomerData.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AromaCareGlow.Commerce.CustomerData.Domain.Repository
{
    public class CustomerRoleRepository : ICustomerRoleRepository
    {
        private readonly IApplicationDbContextFactory dbContextFactory;

        public CustomerRoleRepository(IApplicationDbContextFactory context)
        {
            dbContextFactory = context;
        }

        public Task<bool> DeleteCustomer(CustomerRole entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<CustomerRole>> GetAllCustomerRoles(bool showHidden = false)
        {
            using (var context = dbContextFactory.Create())
            {
                var customer = await context.DbSet<CustomerRole>()
                    .ToListAsync();

                if (customer == null)
                {
                    return null;
                }

                return customer;
            }
        }

        public async Task<CustomerRole> GetCustomerRoleById(int customerRoleId)
        {
            using (var context = dbContextFactory.Create())
            {
                var customer = await context.DbSet<CustomerRole>()
                    .FirstOrDefaultAsync(x => x.Id == customerRoleId);

                if (customer == null)
                {
                    return null;
                }

                return customer;
            }
        }

        public async Task<CustomerRole> GetCustomerRoleBySystemName(string systemName)
        {
            using (var context = dbContextFactory.Create())
            {
                var customer = await context.DbSet<CustomerRole>()
                    .FirstOrDefaultAsync(x => x.SystemName == systemName);

                if (customer == null)
                {
                    return null;
                }

                return customer;
            }
        }

        public async Task<bool> InsertCustomerRole(CustomerRole entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            using (var context = dbContextFactory.Create())
            {
                await context.DbSet<CustomerRole>().AddAsync(entity);
                context.SaveChanges();
                return true;
            }
        }

        public bool UpdateCustomerRole(CustomerRole entityToUpdate)
        {
            if (entityToUpdate == null)
            {
                throw new ArgumentNullException("entity");
            }
            using (var context = dbContextFactory.Create())
            {
                context.DbSet<CustomerRole>().Update(entityToUpdate);
                context.SaveChanges();
                return true;
            }
        }
    }
}
