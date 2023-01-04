using System.Collections.Generic;

namespace Everest03.NET.Services
{
    public interface IService
    {
        void DeleteCustomer(long id);
        Customer GetCustomerById(long Id);
        List<Customer> GetCustomers();
        void SetCustomer(Customer customer);
        void UpdateCustomer(long Id, Customer customer);
    }
}
