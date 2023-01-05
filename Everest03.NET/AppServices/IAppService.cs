using System.Collections.Generic;

namespace Everest03.NET.AppServices
{
    public interface IAppService
    {
        List<Customer> GetCustomers();
        Customer GetCustomerById(long Id);
        void DeleteCustomer(long Id);
        long SetCustomer(Customer customer);
        void UpdateCustomer(long Id, Customer customer);
      
    }
}
