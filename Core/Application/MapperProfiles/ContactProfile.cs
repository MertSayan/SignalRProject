using Application.Features.Mediatr.Contacts.Commands;
using Application.Features.Mediatr.Contacts.Results;
using AutoMapper;
using Domain;

namespace Application.MapperProfiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, CreateContactCommand>().ReverseMap();
            CreateMap<Contact, UpdateContactCommand>().ReverseMap();
            CreateMap<Contact, GetContactQueryResult>().ReverseMap();
            CreateMap<Contact, GetByIdContactQueryResult>().ReverseMap();

        }
    }
}
