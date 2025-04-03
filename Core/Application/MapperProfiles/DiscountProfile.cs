using Application.Features.Mediatr.Discounts.Commands;
using Application.Features.Mediatr.Discounts.Results;
using AutoMapper;
using Domain;

namespace Application.MapperProfiles
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<Discount, CreateDiscountCommand>().ReverseMap();
            CreateMap<Discount, UpdateDiscountCommand>().ReverseMap();
            CreateMap<Discount, GetDiscountQueryResult>().ReverseMap();
            CreateMap<Discount, GetByIdDiscountQueryResult>().ReverseMap();
            CreateMap<Discount, GetDiscountListByStatusTrueQueryResult>().ReverseMap();

        }
    }
}
