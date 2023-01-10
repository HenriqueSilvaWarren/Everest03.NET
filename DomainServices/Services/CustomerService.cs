using DomainModels;
using DomainServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DomainServices.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly List<Customer> _customers = new();

        public long AddCustomer(Customer customer)
        {
            customer.Cpf = new Regex("[.-]").Replace(customer.Cpf, string.Empty);
            EmailAlreadyExists(customer.Email);
            CpfAlreadyExists(customer.Cpf);

            customer.Id = _customers.Any() ? _customers.LastOrDefault().Id + 1 : 1;
            _customers.Add(customer);

            return customer.Id;
        }

        public List<Customer> GetCustomers()
        {
            return _customers;
        }

        public Customer GetCustomerById(long Id)
        {
            Exists(Id);
            return _customers.FirstOrDefault(customer => customer.Id == Id)!;
        }

        public void DeleteCustomer(long id)
        {
            var customer = GetCustomerById(id);
            _customers.Remove(customer);
        }

        public void UpdateCustomer(long Id, Customer customer)
        {
            Exists(Id);
            EmailAlreadyExists(customer.Email, Id);
            CpfAlreadyExists(customer.Cpf, Id);

            customer.Id = Id;
            var index = _customers.FindIndex(customer => customer.Id == Id);

            _customers[index] = customer;
        }

        private void EmailAlreadyExists(string email, long Id = 0)
        {

            if (_customers.Any(customer => customer.Email == email && customer.Id != Id))
             throw new ArgumentException("Email já existe");
        }

        private void CpfAlreadyExists(string cpf, long Id = 0)
        {
            if (_customers.Any(customer => customer.Cpf == cpf && customer.Id != Id)) 
            { throw new ArgumentException("Cpf já existe"); }
        }

        private void Exists(long id)
        {
            if (_customers.Any(customer => customer.Id == id)) return;
            throw new Exception($"O id {id} não foi encontrado");
        }
    }
}
