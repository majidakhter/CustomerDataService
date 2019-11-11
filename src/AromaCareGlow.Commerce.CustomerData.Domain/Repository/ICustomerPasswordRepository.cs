using AromaCareGlow.Commerce.CustomerData.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AromaCareGlow.Commerce.CustomerData.Domain.Repository
{
    public interface ICustomerPasswordRepository
    {
        Task<CustomerPassword> GetCurrentPassword(int customerId);
        Task<bool> Insert(CustomerPassword entity);
        bool Update(CustomerPassword entityToUpdate);
    }
}
