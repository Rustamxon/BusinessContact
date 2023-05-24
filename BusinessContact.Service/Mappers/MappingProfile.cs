using AutoMapper;
using BusinessContact.Domain.Entities;
using BusinessContact.Service.DTOs.Contacts;
using BusinessContact.Service.DTOs.Users;

namespace BusinessContact.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User
            CreateMap<User, UserForCreationDto>().ReverseMap();
            CreateMap<User, UserForResultDto>().ReverseMap();
            CreateMap<User, UserForUpdateDto>().ReverseMap();
            

            // Contact
            CreateMap<Contact, ContactForCreationDto>().ReverseMap();
            CreateMap<Contact, ContactForResultDto>().ReverseMap();
            CreateMap<Contact, ContactForUpdateDto>().ReverseMap();

        }
    }
}
