using DomainModels;
using System.Collections.Generic;

namespace AppServices.Interfaces
{
    public interface ICustomerAppService
    {
        List<Customer> GetCustomers();
        Customer GetCustomerById(long Id);
        void DeleteCustomer(long Id);
        long AddCustomer(Customer customer);
        void UpdateCustomer(long Id, Customer customer);
    }
}
