using Everest03.NET.AppServices;
using Everest03.NET.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Everest03.NET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private AppService _service;

        public CustomersController(AppService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost(Name = "PostCustomer")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Customer))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Customer body)
        {
            try
            {
                _service.SetCustomer(body);
                return new CreatedResult("Post", $"Created customer successfully, ID: {body.Id}");
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpDelete(Name = "DeleteCustomer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete([FromQuery] long Id)
        {
            try
            {
                _service.DeleteCustomer(Id);
                return new NoContentResult();
            }
            catch(Exception e)
            {
                return new NotFoundObjectResult(e.Message);
            }
        }

        [HttpPut(Name = "PutCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest   )]
        public IActionResult Put([FromQuery] long Id, [FromBody] Customer customer)
        {
            try
            {
                _service.UpdateCustomer(Id, customer);
                return new OkObjectResult($"Cliente com ID: {Id} atualizado com sucesso!");
            }
            catch (ArgumentException e)
            {
                return new BadRequestObjectResult(e.Message);
            }
            catch (Exception e)
            {
                return new NotFoundObjectResult(e.Message);
            }
         
        }

        [HttpGet(Name = "GetCustomers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public List<Customer> Get()
        {
            return _service.GetCustomers();
        }

        [HttpGet("{Id}",Name = "GetCustomerById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById([FromRoute] long Id)
        {
            try
            {
                return new OkObjectResult(_service.GetCustomerById(Id));
            }
            catch (Exception e)
            {
                return new NotFoundObjectResult(e.Message);
            }
        }
    }
}
