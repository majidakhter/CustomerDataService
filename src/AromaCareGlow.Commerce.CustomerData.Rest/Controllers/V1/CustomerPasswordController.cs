using System;
using System.Net;
using System.Threading.Tasks;
using AromaCareGlow.Commerce.CustomerData.Domain.Repository;
using AromaCareGlow.Commerce.CustomerData.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AromaCareGlow.Commerce.CustomerData.Rest.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("v{api-version:apiVersion}/[controller]")]
    [ApiController]
    public class CustomerPasswordController : ControllerBase
    {
        private ICustomerPasswordRepository _repository;
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;

        public CustomerPasswordController(ICustomerPasswordRepository repository, ILogger logger, IConfiguration configuration)
        {
            _repository = repository;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost("Save")]
        public async Task<IActionResult> SaveCustomerPassword([FromBody]CustomerPassword custPassword)
        {
            try
            {
                _logger.LogInformation($"SaveCustomerPassword : { Newtonsoft.Json.JsonConvert.SerializeObject(custPassword)}");
                await _repository.Insert(custPassword);
                return Ok(custPassword);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
      
        [HttpGet("GetCurrentPassword/{customerId}")]
        public async Task<IActionResult> GetCurrentPassword(int customerId)
        {
            try
            {
                _logger.LogInformation($"GetCurrentPassword : { customerId}");
                var customer = await _repository.GetCurrentPassword(customerId);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
       
       
        [HttpPut("UpdateCustomerPassword")]
        public async Task<IActionResult> UpdateCustomerPassword([FromBody]CustomerPassword customer)
        {
            try
            {
                _logger.LogInformation($"UpdateCustomer : {  Newtonsoft.Json.JsonConvert.SerializeObject(customer)}");
                var customers = _repository.Update(customer);
                return Ok(customers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
      
      
       
    }
}