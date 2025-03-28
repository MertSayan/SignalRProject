using Application.Features.Mediatr.Testimonials.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Testimonials.Handlers.Write
{
    public class UpdateTestimonialCommandHandler:IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly IGenericRepository<Testimonial> _repository;
        private readonly IMapper _mapper;

        public UpdateTestimonialCommandHandler(IGenericRepository<Testimonial> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.TestimonialId);
            _mapper.Map(request, value);
            await _repository.UpdateAsync(value);

        }
    }
}
