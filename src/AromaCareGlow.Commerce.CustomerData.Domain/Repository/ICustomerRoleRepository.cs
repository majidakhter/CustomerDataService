using AromaCareGlow.Commerce.CustomerData.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AromaCareGlow.Commerce.CustomerData.Domain.Repository
{
    public interface ICustomerRoleRepository
    {
        Task<CustomerRole> GetCustomerRoleById(int customerRoleId);
        Task<CustomerRole> GetCustomerRoleBySystemName(string systemName);
        Task<IList<CustomerRole>> GetAllCustomerRoles(bool showHidden = false);
        Task<bool> InsertCustomerRole(CustomerRole entity);
        bool UpdateCustomerRole(CustomerRole entityToUpdate);
        Task<bool> DeleteCustomer(CustomerRole entity);
    }
}
