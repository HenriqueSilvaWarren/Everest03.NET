using System.Collections.Generic;

namespace Everest03.NET.AppServices
{
    public interface IAppService
    {
        List<Customer> GetCustomers();
        Customer GetCustomerById(long Id);
        void DeleteCustomer(long Id);
        void SetCustomer(Customer customer);
        void UpdateCustomer(long Id, Customer customer);
        void IdExists(long id);
        void EmailAlreadyExists(string email, long Id = 0);
        void CpfAlreadyExists(string cpf, long Id = 0);
    }
}
