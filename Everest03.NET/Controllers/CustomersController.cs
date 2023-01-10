
using AppServices.AppServices;
using DomainModels;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CustomerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerAppService _appService;

        public CustomersController(ICustomerAppService appService)
        {
            _appService = appService ?? throw new ArgumentNullException(nameof(appService));
        }

        [HttpPost(Name = "PostCustomer")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Customer))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Customer body)
        {
            try
            {
                var Id = _appService.AddCustomer(body);
                return Created("", Id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{Id}",Name = "DeleteCustomer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete([FromRoute] long Id)
        {
            try
            {
                _appService.DeleteCustomer(Id);
                return NoContent();
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPut("{Id}", Name = "PutCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest   )]
        public IActionResult Put([FromRoute] long Id, [FromBody] Customer customer)
        {
            try
            {
                _appService.UpdateCustomer(Id, customer);
                return NoContent();
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
         
        }

        [HttpGet(Name = "GetCustomers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public List<Customer> Get()
        {
            return _appService.GetCustomers();
        }

        [HttpGet("{Id}",Name = "GetCustomerById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById([FromRoute] long Id)
        {
            try
            {
                return Ok(_appService.GetCustomerById(Id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
