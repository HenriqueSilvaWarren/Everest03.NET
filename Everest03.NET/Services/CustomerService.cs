
using Everest03.NET.Repositories;
using Everest03.NET.Validators;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Everest03.NET.Services
{
    public class CustomersService
    {
        private CustomersRepository _repository;
        private List<Customer> _customers;
        private CustomersValidator _validator;
        public CustomersService(CustomersRepository repository, List<Customer> customers, CustomersValidator validator)
        {
            _customers= customers;
            _repository = repository;
            _validator= validator;
        }


        public List<Customer> getCustomers()
        {
            return _repository.getCustomers();
        }

        public Customer getCustomerById(long Id)
        {
            idExists(Id);
            return _repository.getCustomerById(Id);
        }

        public void deleteCustomer(long Id)
        {
            idExists(Id);
            _repository.deleteCustomer(Id);
        }

        public void setCustomer(Customer customer)
        {
            _validator.Validate(customer);
            customer.Cpf = new Regex("[.-]").Replace(customer.Cpf, string.Empty);
            EmailAlreadyExists(customer.Email);
            CpfAlreadyExists(customer.Cpf);
            _repository.setCustomer(customer);
        }

        public void updateCustomer(long Id, Customer customer)
        {
            _validator.Validate(customer);
            idExists(Id);
            EmailAlreadyExists(customer.Email, Id);
            CpfAlreadyExists(customer.Cpf, Id);
            _repository.updateCustomer(Id, customer);
        }

        private void EmailAlreadyExists(string email, long Id = 0)
        {
            foreach (Customer registeredCustomer in _customers)
            {
                if(registeredCustomer.Id == Id)
                {
                    continue;
                }
                if (registeredCustomer.Email == email)
                {
                    throw new Exception("Email já existe");
                }
            }
        }

        private void CpfAlreadyExists(string cpf, long Id = 0)
        {
            foreach (Customer registeredCustomer in _customers)
            {
                if (registeredCustomer.Id == Id)
                {
                    continue;
                }
                if (registeredCustomer.Cpf == cpf)
                {
                    throw new Exception("Cpf já existe");
                }
            }
        }

        private void idExists(long id)
        {
            foreach (Customer customer in _customers)
            {
                if (customer.Id == id) return;
            }
            throw new Exception($"O id {id} não foi encontrado");
        }
    }

}
