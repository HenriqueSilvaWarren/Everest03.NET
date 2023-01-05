using System.Collections.Generic;

namespace Everest03.NET.Services
{
    public interface IService
    {
        void DeleteCustomer(long id);
        Customer GetCustomerById(long Id);
        List<Customer> GetCustomers();
        long SetCustomer(Customer customer);
        void UpdateCustomer(long Id, Customer customer);
        void IdExists(long id);
        void EmailAlreadyExists(string email, long Id = 0);
        void CpfAlreadyExists(string cpf, long Id = 0);
    }
}
