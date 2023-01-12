using AppServices.Dtos;
using AutoMapper;
using DomainModels.Entities;

namespace AppServices.Profiles
{
    public class CreateCustomerProfile : Profile
    {
        public CreateCustomerProfile()
        {
            CreateMap<CreateCustomerDto, Customer> ()
                .ForMember(
                    dest => dest.FullName,
                    opt => opt.MapFrom(src => src.FullName)
                )                
                .ForMember(
                    dest => dest.Email,
                    opt => opt.MapFrom(src => src.Email)
                )
                .ForMember(
                    dest => dest.Cpf,
                    opt => opt.MapFrom(src => src.Cpf)
                )
                .ForMember(
                    dest => dest.Cellphone,
                    opt => opt.MapFrom(src => src.Cellphone)
                )
                .ForMember(
                    dest => dest.DateOfBirth,
                    opt => opt.MapFrom(src => src.DateOfBirth)
                )
                .ForMember(
                    dest => dest.Country,
                    opt => opt.MapFrom(src => src.Country)
                )
                .ForMember(
                    dest => dest.City,
                    opt => opt.MapFrom(src => src.City)
                )
                .ForMember(
                    dest => dest.PostalCode,
                    opt => opt.MapFrom(src => src.PostalCode)
                )
                .ForMember(
                    dest => dest.Address,
                    opt => opt.MapFrom(src => src.Address)
                )
                .ForMember(
                    dest => dest.Number,
                    opt => opt.MapFrom(src => src.Number)
                );
        }
    }
}
