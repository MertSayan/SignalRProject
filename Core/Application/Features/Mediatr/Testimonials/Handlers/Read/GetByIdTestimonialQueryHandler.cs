using Application.Features.Mediatr.Testimonials.Queries;
using Application.Features.Mediatr.Testimonials.Results;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Testimonials.Handlers.Read
{
    public class GetByIdTestimonialQueryHandler:IRequestHandler<GetByIdTestimonialQuery,GetByIdTestimonialQueryResult>
    {
        private readonly IGenericRepository<Testimonial> _repository;
        private readonly IMapper _mapper;
        public GetByIdTestimonialQueryHandler(IGenericRepository<Testimonial> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetByIdTestimonialQueryResult> Handle(GetByIdTestimonialQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetByIdTestimonialQueryResult>(value);
        }
    }
}
