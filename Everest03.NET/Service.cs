using Microsoft.AspNetCore.Mvc;

namespace Everest03.NET
{
    public class Service
    {
        private long _id = 0;
        private List<Customers> Customers = new List<Customers>();

        public List<Customers> getCustomers()
        {
            return Customers;
        }

        public void setCustomers(Customers customer)
        {
            customer.setId(++this._id);
            Customers.Add(customer);
        }
    }
}
