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
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost(Name = "PostCustomer")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Customer))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Customer body)
        {
            try
            {
                _service.setCustomer(body);
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
                _service.deleteCustomer(Id);
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public List<Customer> Get()
        {
            return _service.getCustomers();
        }
    }
}
