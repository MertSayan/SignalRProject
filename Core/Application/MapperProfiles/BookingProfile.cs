using Application.Features.Mediatr.Bookings.Commands;
using Application.Features.Mediatr.Bookings.Results;
using AutoMapper;
using Domain;

namespace Application.MapperProfiles
{
    public class BookingProfile:Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, CreateBookingCommand>().ReverseMap();
            CreateMap<Booking, UpdateBookingCommand>().ReverseMap();
            CreateMap<Booking, GetBookingQueryResult>().ReverseMap();
            CreateMap<Booking, GetByIdBookingQueryResult>().ReverseMap();
        }
    }
}
