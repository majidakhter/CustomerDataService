using AromaCareGlow.Commerce.CustomerData.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AromaCareGlow.Commerce.CustomerData.Domain.Repository

{
    public interface ICustomerRepository
    {

        Task<Customer> GetByIDAsync(int id);
        Task<Customer> GetCustomerByEmail(string emailId);
        Task<Customer> GetCustomerRoleBySystemName(string registeredRoleName);
        Task<Customer>  GetCustomerByUsername(string username);
        Task<CustomerPassword> GetCurrentPassword(int customerId);
       // Task<IEnumerable<Customer>> GetAll();
        Task<bool> Insert(CustomerPassword entity);
        bool Update(CustomerPassword entityToUpdate);
    }
}
