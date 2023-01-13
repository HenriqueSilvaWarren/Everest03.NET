using AppServices.Dtos;
using AppServices.Interfaces;
using AutoMapper;
using DomainModels.Entities;
using DomainServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppServices.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerService _service;
        private readonly IMapper _mapper;
        public CustomerAppService(ICustomerService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public List<GetCustomer> GetCustomers()
        {
            var customers = _service.GetCustomers();

            return _mapper.Map<List<GetCustomer>>(customers);
        }

        public GetCustomer GetCustomerById(long Id)
        {
            var customer = _service.GetCustomerById(Id);

            return _mapper.Map<GetCustomer>(customer);
        }

        public void DeleteCustomer(long Id)
        {
            _service.DeleteCustomer(Id);
        }

        public long AddCustomer(CreateCustomer createCustomer)
        {
            var mappedCustomer = _mapper.Map<Customer>(createCustomer);

            return _service.AddCustomer(mappedCustomer);
        }

        public void UpdateCustomer(long Id, UpdateCustomer updateCustomer)
        {
            var mappedCustomer = _mapper.Map<Customer>(updateCustomer);

            _service.UpdateCustomer(Id, mappedCustomer);
        }
    }
};
