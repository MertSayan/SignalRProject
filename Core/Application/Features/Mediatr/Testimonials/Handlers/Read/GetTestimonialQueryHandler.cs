using Application.Features.Mediatr.Testimonials.Queries;
using Application.Features.Mediatr.Testimonials.Results;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Testimonials.Handlers.Read
{
    public class GetTestimonialQueryHandler:IRequestHandler<GetTestimonialQuery,List<GetTestimonialQueryResult>>
    {
        private readonly IGenericRepository<Testimonial> _repository;
        private readonly IMapper _mapper;
        public GetTestimonialQueryHandler(IGenericRepository<Testimonial> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetListAllAsync();
            return _mapper.Map<List<GetTestimonialQueryResult>>(values);
        }
    }
}
