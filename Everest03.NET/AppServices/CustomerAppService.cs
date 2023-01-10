using Everest03.NET.Services;
using System;
using System.Collections.Generic;

namespace Everest03.NET.AppServices
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerService _service;
      
        public CustomerAppService(ICustomerService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public List<Customer> GetCustomers()
        {
            return _service.GetCustomers();
        }

        public Customer GetCustomerById(long Id)
        {
            return _service.GetCustomerById(Id);
        }

        public void DeleteCustomer(long Id)
        {
            _service.DeleteCustomer(Id);
        }

        public long AddCustomer(Customer customer)
        {
           _service.AddCustomer(customer);
           return customer.Id;
        }

        public void UpdateCustomer(long Id, Customer customer)
        {
            _service.UpdateCustomer(Id, customer);
        }
    }
}
