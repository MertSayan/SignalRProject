using Application.Features.Mediatr.Baskets.Commands;
using Application.Features.Mediatr.Baskets.Results;
using Application.Features.Mediatr.Products.Results;
using AutoMapper;
using Domain;

namespace Application.MapperProfiles
{
    public class BasketProfile:Profile
    {
        public BasketProfile()
        {
            CreateMap<Basket, CreateBasketCommand>().ReverseMap();
            CreateMap<Basket, UpdateBasketCommand>().ReverseMap();
            CreateMap<Basket, GetBasketQueryResult>().ReverseMap();
            CreateMap<Basket, GetByIdBasketQueryResult>().ReverseMap();
            CreateMap<Basket, GetBasketByTableNumberQueryResult>()
                .ForMember(dest=>dest.ProductName,opt=>opt.MapFrom(src=>src.Product.ProductName))
                .ReverseMap();


          
        }
    }
}
