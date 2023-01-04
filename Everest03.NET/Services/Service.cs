using System.Collections.Generic;
using System.Linq;

namespace Everest03.NET.Services
{
    public class Service : IService
    {
        public Service(List<Customer> customers) {
            _customers= customers;
        }
        private readonly List<Customer> _customers;

        private long _id = 0;

        public void SetCustomer(Customer customer)
        {
            customer.SetId(++_id);
            _customers.Add(customer);
        }

        public List<Customer> GetCustomers()
        {
            return _customers;
        }

        public Customer GetCustomerById(long Id)
        {
            return _customers.FirstOrDefault(customer => customer.Id == Id)!;
        }
        public void DeleteCustomer(long id)
        {
            _customers.RemoveAll(customer => customer.Id == id);
        }

        public void UpdateCustomer(long Id, Customer customer)
        {
            customer.SetId(Id);
            var index = _customers.FindIndex(customer => customer.Id == Id);
            _customers[index] = customer;
        }
    }
}
