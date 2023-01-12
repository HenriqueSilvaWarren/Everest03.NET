using AppServices.Dtos;
using AutoMapper;
using DomainModels.Entities;
using System.Collections.Generic;

namespace AppServices.Interfaces
{
    public interface ICustomerAppService
    {
        List<GetCustomerDto> GetCustomers();
        GetCustomerDto GetCustomerById(long Id);
        void DeleteCustomer(long Id);
        long AddCustomer(CreateCustomerDto customer);
        void UpdateCustomer(long Id, UpdateCustomerDto customer);
    }
}
