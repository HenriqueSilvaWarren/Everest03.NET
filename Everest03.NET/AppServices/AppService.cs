
using Everest03.NET.Services;
using Everest03.NET.Validators;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Everest03.NET.AppServices
{
    public class AppService : IAppService
    {
        private Service _service;
      
        public AppService(Service service)
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

        public Customer SetCustomer(Customer customer)
        {
           return _service.SetCustomer(customer);
        }

        public void UpdateCustomer(long Id, Customer customer)
        {
            _service.UpdateCustomer(Id, customer);
        }
    }

}
