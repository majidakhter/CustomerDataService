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
       
        [HttpGet("GetCustomerByEmail/{emailId}")]
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
        
        [HttpGet("GetCustomerByUsername/{username}")]
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
       
        [HttpGet("GetCustomerById/{customerId}")]
        public async Task<IActionResult> GetCustomerById(int customerId)
        {
            try
            {
                _logger.LogInformation($"GetCurrentPassword : { customerId}");
                var customer = await _repository.GetCustomerById(customerId);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet("GetCustomerByGuid/{customerId}")]
        public async Task<IActionResult> GetCustomerByGuid(Guid customerId)
        {
            try
            {
                _logger.LogInformation($"GetCurrentPassword : { customerId}");
                var customer = await _repository.GetCustomerByGuid(customerId);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet("GetCustomerByIds/{customerId}")]
        public async Task<IActionResult> GetCustomerByIds(int[] customerIds)
        {
            try
            {
                _logger.LogInformation($"GetCurrentPassword : { customerIds}");
                var customer = await _repository.GetCustomerByIds(customerIds);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost("Save")]
        public async Task<IActionResult> SaveCustomer([FromBody]Customer custPassword)
        {
            try
            {
                _logger.LogInformation($"SaveCustomerPassword : { Newtonsoft.Json.JsonConvert.SerializeObject(custPassword)}");
                 await _repository.InsertCustomer(custPassword);
                return Ok(custPassword);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer([FromBody]Customer custPassword)
        {
            try
            {
                _logger.LogInformation($"SaveCustomerPassword : { Newtonsoft.Json.JsonConvert.SerializeObject(custPassword)}");
                 _repository.UpdateCustomer(custPassword);
                return Ok(custPassword);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
        //[HttpPost("SaveGuestCustomer")]
        //public  Task SaveGuestCustomer()
        //{
        //    try
        //    {
        //        _logger.LogInformation($"SaveCustomerPassword");
        //         _repository.InsertGuestCustomer();
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, ex.Message);
        //        return StatusCode((int)HttpStatusCode.InternalServerError, ex);
        //    }
        //}
        //[HttpDelete("DeleteCustomer")]
        //public  Task<IActionResult> DeleteCustomer(Customer customer)
        //{
        //    try
        //    {
        //        _logger.LogInformation($"SaveCustomerPassword : { Newtonsoft.Json.JsonConvert.SerializeObject(customer)}");
        //         _repository.DeleteCustomer(customer);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, ex.Message);
        //        return StatusCode((int)HttpStatusCode.InternalServerError, ex);
        //    }
        //}

        //[HttpDelete("DeleteGuestCustomer")]
        //public async Task<IActionResult> DeleteGuestCustomer(DateTime? createdFromUtc, DateTime? createdToUtc, bool onlyWithoutShoppingCart)
        //{
        //    try
        //    {
        //        //_logger.LogInformation($"SaveCustomerPassword : { Newtonsoft.Json.JsonConvert.SerializeObject(custPassword)}");
        //        await _repository.DeleteGuestCustomer(createdFromUtc, createdToUtc, onlyWithoutShoppingCart);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, ex.Message);
        //        return StatusCode((int)HttpStatusCode.InternalServerError, ex);
        //    }
        //}
    }
}