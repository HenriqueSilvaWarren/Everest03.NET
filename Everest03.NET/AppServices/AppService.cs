
using Everest03.NET.Service;
using Everest03.NET.Validators;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Everest03.NET.AppServices
{
    public class AppService : IAppService
    {
        private Service.Service _repository;
        private List<Customer> _customers;
        public AppService(Service.Service repository, List<Customer> customers)
        {
            _customers= customers;
            _repository = repository;
        }


        public List<Customer> GetCustomers()
        {
            return _repository.GetCustomers();
        }

        public Customer GetCustomerById(long Id)
        {
            IdExists(Id);
            return _repository.GetCustomerById(Id);
        }

        public void DeleteCustomer(long Id)
        {
            IdExists(Id);
            _repository.DeleteCustomer(Id);
        }

        public void SetCustomer(Customer customer)
        {
            customer.Cpf = new Regex("[.-]").Replace(customer.Cpf, string.Empty);
            EmailAlreadyExists(customer.Email);
            CpfAlreadyExists(customer.Cpf);
            _repository.SetCustomer(customer);
        }

        public void UpdateCustomer(long Id, Customer customer)
        {
            IdExists(Id);
            EmailAlreadyExists(customer.Email, Id);
            CpfAlreadyExists(customer.Cpf, Id);
            _repository.UpdateCustomer(Id, customer);
        }

        public void EmailAlreadyExists(string email, long Id = 0)
        {
            foreach (Customer registeredCustomer in _customers)
            {
                if(registeredCustomer.Id == Id)
                {
                    continue;
                }
                if (registeredCustomer.Email == email)
                {
                    throw new ArgumentException("Email já existe");
                }
            }
        }

        public void CpfAlreadyExists(string cpf, long Id = 0)
        {
            foreach (Customer registeredCustomer in _customers)
            {
                if (registeredCustomer.Id == Id)
                {
                    continue;
                }
                if (registeredCustomer.Cpf == cpf)
                {
                    throw new ArgumentException("Cpf já existe");
                }
            }
        }

        public void IdExists(long id)
        {
            foreach (Customer customer in _customers)
            {
                if (customer.Id == id) return;
            }
            throw new Exception($"O id {id} não foi encontrado");
        }
    }

}
