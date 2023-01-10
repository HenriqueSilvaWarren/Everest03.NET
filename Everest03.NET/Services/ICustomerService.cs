using System.Collections.Generic;

namespace Everest03.NET.Services
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
