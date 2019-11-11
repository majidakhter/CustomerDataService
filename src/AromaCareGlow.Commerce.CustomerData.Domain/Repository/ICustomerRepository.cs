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
        Task<Customer>  GetCustomerByUsername(string username);
        Task<Customer> GetCustomerById(int customerId);
        Task<Customer> GetCustomerByGuid(Guid customerId);
        Task<List<Customer>> GetCustomerByIds(int[] customerIds);
        Task<bool> InsertCustomer(Customer entity);
        bool UpdateCustomer(Customer entityToUpdate);
        bool DeleteCustomer(Customer entity);
        bool DeleteGuestCustomer(DateTime? createdFromUtc, DateTime? createdToUtc, bool onlyWithoutShoppingCart);
        Task<bool> InsertGuestCustomer(Customer entity);
    }
}
