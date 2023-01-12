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

        public List<GetCustomerDto> GetCustomers()
        {
            var customers = _service.GetCustomers();
            return _mapper.Map<List<GetCustomerDto>>(customers);
        }

        public GetCustomerDto GetCustomerById(long Id)
        {
            return _mapper.Map<GetCustomerDto>(_service.GetCustomerById(Id));
        }

        public void DeleteCustomer(long Id)
        {
            _service.DeleteCustomer(Id);
        }

        public long AddCustomer(CreateCustomerDto customer)
        {
            var mappedCustomer = _mapper.Map<Customer>(customer);
            return _service.AddCustomer(mappedCustomer);
        }

        public void UpdateCustomer(long Id, UpdateCustomerDto customer)
        {
            _service.UpdateCustomer(Id, _mapper.Map<Customer>(customer));
        }
    }
};
