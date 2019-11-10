using System;
using System.Net;
using System.Threading.Tasks;
using AromaCareGlow.Commerce.CustomerData.Domain.Repository;
using AromaCareGlow.Commerce.CustomerData.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AromaCareGlow.Commerce.CustomerData.Rest.V1
{
    [ApiVersion("1.0")]
    [Route("v{api-version:apiVersion}/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerRepository _repository;
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        public CustomerController(ICustomerRepository repository, ILogger logger, IConfiguration configuration)
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
        [HttpGet("{emailId}")]
        public async Task<IActionResult> GetCustomerByEmail(string emailId)
        {
            try
            {
                _logger.LogInformation($"GetCustomerByEmail : { emailId}");
                var customer = await _repository.GetCustomerByEmail(emailId);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpGet("{registeredRoleName}")]
        public async Task<IActionResult> GetCustomerRoleBySystemName(string registeredRoleName)
        {
            try
            {
                _logger.LogInformation($"GetCustomerRoleBySystemName : { registeredRoleName}");
                var customer = await _repository.GetCustomerRoleBySystemName(registeredRoleName);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpGet("{username}")]
        public async Task<IActionResult> GetCustomerByUsername(string username)
        {
            try
            {
                _logger.LogInformation($"GetCustomerByUsername : { username}");
                var customer = await _repository.GetCustomerByUsername(username);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpGet("{customerId}")]
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

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCustomer([FromBody]Customer customer)
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