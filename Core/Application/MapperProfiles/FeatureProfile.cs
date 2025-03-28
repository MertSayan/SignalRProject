using Application.Features.Mediatr.Features.Commands;
using Application.Features.Mediatr.Features.Results;
using AutoMapper;
using Domain;

namespace Application.MapperProfiles
{
    public class FeatureProfile : Profile
    {
        public FeatureProfile()
        {
            CreateMap<Feature, CreateFeatureCommand>().ReverseMap();
            CreateMap<Feature, UpdateFeatureCommand>().ReverseMap();
            CreateMap<Feature, GetFeatureQueryResult>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureQueryResult>().ReverseMap();

        }
    }
}
