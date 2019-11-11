using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AromaCareGlow.Commerce.CustomerData.Domain.Repository;
using AromaCareGlow.Commerce.CustomerData.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AromaCareGlow.Commerce.CustomerData.Rest.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("v{api-version:apiVersion}/[controller]")]
    [ApiController]
    public class CustomerRoleController : ControllerBase
    {
        private ICustomerRoleRepository _repository;
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;

        public CustomerRoleController(ICustomerRoleRepository repository, ILogger logger, IConfiguration configuration)
        {
            _repository = repository;
            _logger = logger;
            _configuration = configuration;
        }
        [HttpGet("GetCustomerRoleBySystemName/{registeredRoleName}")]
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
        [HttpGet("GetCustomerRoleById/{customerRoleId}")]
        public async Task<IActionResult> GetCustomerRoleById(int customerRoleId)
        {
            try
            {
                _logger.LogInformation($"GetCustomerRoleBySystemName : { customerRoleId}");
                var customer = await _repository.GetCustomerRoleById(customerRoleId);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpGet("GetAllCustomerRoles/{showHidden}")]
        public async Task<IActionResult> GetAllCustomerRoles(bool showHidden = false)
        {
            try
            {
                _logger.LogInformation($"GetCustomerRoleBySystemName : { showHidden}");
                var customer = await _repository.GetAllCustomerRoles(showHidden);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpPost("SaveCustomerRole")]
        public async Task<IActionResult> SaveCustomer([FromBody]CustomerRole custRole)
        {
            try
            {
                _logger.LogInformation($"SaveCustomerPassword : { Newtonsoft.Json.JsonConvert.SerializeObject(custRole)}");
                await _repository.InsertCustomerRole(custRole);
                return Ok(custRole);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPut("UpdateCustomerRole")]
        public async Task<IActionResult> UpdateCustomerRole([FromBody]CustomerRole customerRole)
        {
            try
            {
                _logger.LogInformation($"SaveCustomerPassword : { Newtonsoft.Json.JsonConvert.SerializeObject(customerRole)}");
                _repository.UpdateCustomerRole(customerRole);
                return Ok(customerRole);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpDelete("DeleteCustomerRole")]
        public async Task<IActionResult> DeleteCustomerRole(CustomerRole customerRole)
        {
            try
            {
                _logger.LogInformation($"SaveCustomerPassword : { Newtonsoft.Json.JsonConvert.SerializeObject(customerRole)}");
                await _repository.DeleteCustomer(customerRole);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}