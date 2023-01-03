using Everest03.NET.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Everest03.NET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private CustomersValidator _validator;
        private Service _service;
        public CustomersController(Service service, CustomersValidator validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpPost(Name = "PostCustomer")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Customers))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Customers body)
        {
            var validationResults = _validator.Validate(body);
            _service.setCustomers(body);
            return new CreatedResult("Post", "Created customer successfully");
        }

        [HttpGet(Name = "GetCustomers")]
        public List<Customers> Get()
        {
            return _service.getCustomers();
        }
    }
}
