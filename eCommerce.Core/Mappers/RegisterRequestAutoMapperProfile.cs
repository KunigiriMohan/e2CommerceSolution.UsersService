using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Core.Mappers
{
    public class RegisterRequestAutoMapperProfile : Profile
    {
        public RegisterRequestAutoMapperProfile() 
        {
            CreateMap<DTO.RegisterRequest, Entities.ApplicationUser>()
                .ForMember(dest => dest.UserID, opt => opt.Ignore())
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.PersonName))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()));
        }
    }
}
