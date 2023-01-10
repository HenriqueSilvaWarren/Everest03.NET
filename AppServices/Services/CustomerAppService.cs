using AppServices.Interfaces;
using DomainModels;
using DomainServices.Interfaces;
using System;
using System.Collections.Generic;

namespace AppServices.Services
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
            return _service.AddCustomer(customer);

        }

        public void UpdateCustomer(long Id, Customer customer)
        {
            _service.UpdateCustomer(Id, customer);
        }

        List<Customer> ICustomerAppService.GetCustomers()
        {
            throw new System.NotImplementedException();
        }
    }
}
