using Application.Features.Mediatr.Products.Commands;
using Application.Features.Mediatr.Products.Results;
using AutoMapper;
using Domain;

namespace Application.MapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();
            CreateMap<Product, GetProductQueryResult>().ReverseMap();
            CreateMap<Product, GetByIdProductQueryResult>().ReverseMap();

            CreateMap<Product, GetProductWithCategoryNameQueryResult>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
            .ReverseMap();

        }
    }
}
