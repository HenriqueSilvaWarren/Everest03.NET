using AppServices.Dtos;
using AutoMapper;
using DomainModels.Entities;

namespace AppServices.Profiles
{
    internal class GetCustomerProfile : Profile
    {
        public GetCustomerProfile()
        {
            CreateMap<Customer, GetCustomerDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.FullName,
                    opt => opt.MapFrom(src => src.FullName)
                )
                .ForMember(
                    dest => dest.Email,
                    opt => opt.MapFrom(src => src.Email)
                )
                .ForMember(
                    dest => dest.Cellphone,
                    opt => opt.MapFrom(src => src.Cellphone)
                )
                .ForMember(
                    dest => dest.City,
                    opt => opt.MapFrom(src => src.City)
                )
                .ForMember(
                    dest => dest.PostalCode,
                    opt => opt.MapFrom(src => src.PostalCode)
                );
        }
    }
}
