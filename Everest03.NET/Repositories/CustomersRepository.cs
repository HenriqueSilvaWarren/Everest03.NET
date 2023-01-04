namespace Everest03.NET.Repositories
{
    public class CustomersRepository
    {
        public CustomersRepository(List<Customer> customers) {
            _customers= customers;
        }
        private readonly List<Customer> _customers;

        private long _id = 0;

        public void setCustomer(Customer customer)
        {
            customer.setId(++_id);
            _customers.Add(customer);
        }

        public List<Customer> getCustomers()
        {
            return _customers;
        }

        public Customer getCustomerById(long Id)
        {
            return _customers.FirstOrDefault(customer => customer.Id == Id)!;
        }
        public void deleteCustomer(long id)
        {
            _customers.RemoveAll(customer => customer.Id == id);
        }

        public void updateCustomer(long Id, Customer customer)
        {
            customer.setId(Id);
            var index = _customers.FindIndex(customer => customer.Id == Id);
            _customers[index] = customer;
        }
    }
}
