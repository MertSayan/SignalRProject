using Application.Features.Mediatr.Testimonials.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Testimonials.Handlers.Write
{
    public class CreateTestimonialCommandHandler : IRequestHandler<CreateTestimonialCommand>
    {
        private readonly IGenericRepository<Testimonial> _genericRepository;
        private readonly IMapper _mapper;

        public CreateTestimonialCommandHandler(IGenericRepository<Testimonial> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
        {

            var value = _mapper.Map<Testimonial>(request);
            await _genericRepository.CreateAsync(value);
        }
    }
}
