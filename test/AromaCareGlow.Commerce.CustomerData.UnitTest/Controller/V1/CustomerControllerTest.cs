using System;
using System.Threading.Tasks;
using Xunit;
using AromaCareGlow.Commerce.CustomerData.Rest.V1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using AromaCareGlow.Commerce.CustomerData.Domain.Repository;

namespace AromaCareGlow.Commerce.CustomerData.UnitTest.Controller.V1
{
    public class CustomerControllerTest
    {
        private Mock<ICustomerRepository> _customerRepository;
        private Mock<ILogger<CustomerController>> _loggerMock;
        private Mock<IConfiguration> _configuration;
        public  CustomerControllerTest()
        {
            _customerRepository = new Mock<ICustomerRepository>();
            _loggerMock = new Mock<ILogger<CustomerController>>();
            _configuration = new Mock<IConfiguration>();
        }
        [Fact]
        public async Task SaveCustomer()
        {
            var customerObject = new CustomerController(_customerRepository.Object, _loggerMock.Object, _configuration.Object)
            {
                ControllerContext = new ControllerContext()
            };
            customerObject.ControllerContext.HttpContext = new DefaultHttpContext();
           
        }

    }
}
