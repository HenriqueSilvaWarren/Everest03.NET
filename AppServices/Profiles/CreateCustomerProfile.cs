using AppServices.Dtos;
using AutoMapper;
using DomainModels.Entities;

namespace AppServices.Profiles
{
    public class CreateCustomerProfile : Profile
    {
        public CreateCustomerProfile()
        {
            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<UpdateCustomerDto, Customer>();
            CreateMap<Customer, GetCustomerDto>();
        }
    }
}
