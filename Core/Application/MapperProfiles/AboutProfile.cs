using Application.Features.Mediatr.Abouts.Commands;
using Application.Features.Mediatr.Abouts.Results;
using AutoMapper;
using Domain;

namespace Application.MapperProfiles
{
    public class AboutProfile:Profile
    {
        public AboutProfile()
        {
            CreateMap<About, CreateAboutCommand>().ReverseMap();
            CreateMap<About, UpdateAboutCommand>().ReverseMap();
            CreateMap<About, GetAboutQueryResult>().ReverseMap();
            CreateMap<About, GetByIdAboutQueryResult>().ReverseMap();
        }
    }
}
