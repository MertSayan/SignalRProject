using Application.Features.Mediatr.Categories.Commands;
using Application.Features.Mediatr.Categories.Results;
using AutoMapper;
using Domain;

namespace Application.MapperProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
            CreateMap<Category, GetCategoryQueryResult>().ReverseMap();
            CreateMap<Category, GetByIdCategoryQueryResult>().ReverseMap();


        }
    }
}
