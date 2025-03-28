using Application.Features.Mediatr.Testimonials.Commands;
using Application.Features.Mediatr.Testimonials.Results;
using AutoMapper;
using Domain;

namespace Application.MapperProfiles
{
    public class TestimonialProfile : Profile
    {
        public TestimonialProfile()
        {
            CreateMap<Testimonial, CreateTestimonialCommand>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialCommand>().ReverseMap();
            CreateMap<Testimonial, GetTestimonialQueryResult>().ReverseMap();
            CreateMap<Testimonial, GetByIdTestimonialQueryResult>().ReverseMap();

        }
    }
}
