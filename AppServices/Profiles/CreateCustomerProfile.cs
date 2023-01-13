using AppServices.Dtos;
using AutoMapper;
using DomainModels.Entities;

namespace AppServices.Profiles
{
    public class CreateCustomerProfile : Profile
    {
        public CreateCustomerProfile()
        {
            CreateMap<CreateCustomer, Customer>();
            CreateMap<UpdateCustomer, Customer>();
            CreateMap<Customer, GetCustomer>();
        }
    }
}
