using DomainModels;
using System.Collections.Generic;

namespace AppServices.AppServices
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
