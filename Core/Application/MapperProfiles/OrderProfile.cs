using Application.Features.Mediatr.Orders.Commands;
using Application.Features.Mediatr.Orders.Results;
using AutoMapper;
using Domain;

namespace Application.MapperProfiles
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, CreateOrderCommand>().ReverseMap();
            CreateMap<Order, UpdateOrderCommand>().ReverseMap();
            CreateMap<Order, GetOrderQueryResult>().ReverseMap();
            CreateMap<Order, GetByIdOrderQueryResult>().ReverseMap();
        }
    }
}
