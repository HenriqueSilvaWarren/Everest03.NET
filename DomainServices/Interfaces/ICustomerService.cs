using DomainModels.Entities;
using System.Collections.Generic;

namespace DomainServices.Interfaces
{
    public interface ICustomerService
    {
        List<Customer> GetCustomers();
        Customer GetCustomerById(long Id);
        void DeleteCustomer(long id);
        long AddCustomer(Customer customer);
        void UpdateCustomer(long Id, Customer customer);
    }
}
