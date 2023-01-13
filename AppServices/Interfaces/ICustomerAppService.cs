using AppServices.Dtos;
using AutoMapper;
using DomainModels.Entities;
using System.Collections.Generic;

namespace AppServices.Interfaces
{
    public interface ICustomerAppService
    {
        List<GetCustomer> GetCustomers();
        GetCustomer GetCustomerById(long Id);
        void DeleteCustomer(long Id);
        long AddCustomer(CreateCustomer customer);
        void UpdateCustomer(long Id, UpdateCustomer customer);
    }
}
