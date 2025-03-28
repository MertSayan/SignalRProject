using Application.Features.Mediatr.SocialMedias.Commands;
using Application.Features.Mediatr.SocialMedias.Results;
using AutoMapper;
using Domain;

namespace Application.MapperProfiles
{
    public class SocialMediaProfile : Profile
    {
        public SocialMediaProfile()
        {
            CreateMap<SocialMedia, CreateSocialMediaCommand>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaCommand>().ReverseMap();
            CreateMap<SocialMedia, GetSocialMediaQueryResult>().ReverseMap();
            CreateMap<SocialMedia, GetByIdSocialMediaQueryResult>().ReverseMap();

        }
    }
}
