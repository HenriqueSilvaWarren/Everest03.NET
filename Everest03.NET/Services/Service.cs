using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Everest03.NET.Services
{
    public class Service : IService
    {
        private readonly List<Customer> _customers;
        
        public Service(List<Customer> customers)
        {
            _customers= customers ?? throw new ArgumentNullException(nameof(customers));
        }

        private long _id = 1;

        public long SetCustomer(Customer customer)
        {
            customer.Cpf = new Regex("[.-]").Replace(customer.Cpf, string.Empty);
            EmailAlreadyExists(customer.Email);
            CpfAlreadyExists(customer.Cpf);
            customer.handle(_id);
            _customers.Add(customer);
            _id++;
            return _customers.Last().Id;
        }

        public List<Customer> GetCustomers()
        {
            return _customers;
        }

        public Customer GetCustomerById(long Id)
        {
            IdExists(Id);
            return _customers.FirstOrDefault(customer => customer.Id == Id)!;
        }
        
        public void DeleteCustomer(long id)
        {
            IdExists(id);
            _customers.RemoveAll(customer => customer.Id == id);
        }

        public void UpdateCustomer(long Id, Customer customer)
        {
            IdExists(Id);
            EmailAlreadyExists(customer.Email, Id);
            CpfAlreadyExists(customer.Cpf, Id);
            customer.handle(Id);
            var index = _customers.FindIndex(customer => customer.Id == Id);
            _customers[index] = customer;
        }

        private void EmailAlreadyExists(string email, long Id = 0)
        {
            foreach (Customer registeredCustomer in _customers)
            {
                if (registeredCustomer.Id == Id)
                {
                    continue;
                }
                if (registeredCustomer.Email == email)
                {
                    throw new ArgumentException("Email já existe");
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
                    throw new ArgumentException("Cpf já existe");
                }
            }
        }

        private void IdExists(long id)
        {
            foreach (Customer customer in _customers)
            {
                if (customer.Id == id) return;
            }
            throw new Exception($"O id {id} não foi encontrado");
        }
    }
}
