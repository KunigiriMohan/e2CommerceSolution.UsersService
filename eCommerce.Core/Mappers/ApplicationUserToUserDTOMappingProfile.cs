

using AutoMapper;

namespace eCommerce.Core.Mappers;
public  class ApplicationUserToUserDTOMappingProfile : Profile
{
    public ApplicationUserToUserDTOMappingProfile()
    {
        CreateMap<Entities.ApplicationUser, DTO.UserDTO>()
            .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserID))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.PersonName))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender));
    }
}

