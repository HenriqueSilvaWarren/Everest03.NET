using Everest03.NET.Services;
using Everest03.NET.Validators;

using Microsoft.AspNetCore.Mvc;

namespace Everest03.NET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private CustomersService _service;
        public CustomersController(CustomersService service)
        {
            _service = service;

        }

        [HttpPost(Name = "PostCustomer")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Customer))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Customer body)
        {
            try
            {
            
                _service.setCustomer(body);
                return new CreatedResult("Post", "Created customer successfully");
            }
            catch(Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpDelete(Name = "DeleteCustomer")]
        public IActionResult Delete([FromQuery] long Id)
        {
            try
            {
                _service.deleteCustomer(Id);
                return new OkResult();
            }
            catch(Exception e)
            {
                return new NotFoundObjectResult(e.Message);
            }
        }

        [HttpPut(Name = "PutCustomer")]
        public IActionResult Put([FromQuery] long Id, [FromBody] Customer customer)
        {
            try
            {
                _service.updateCustomer(Id, customer);
                return new OkObjectResult($"Cliente com ID: {Id} atualizado com sucesso!");
            }
            catch (Exception e)
            {
                return new NotFoundObjectResult(e.Message);
            }
        }

        [HttpGet(Name = "GetCustomers")]
        public List<Customer> Get()
        {
            return _service.getCustomers();
        }
    }
}
