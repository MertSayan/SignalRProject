using Application.Features.Mediatr.Bookings.Queries;
using Application.Features.Mediatr.Bookings.Results;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Bookings.Handlers.Read
{
    public class GetByIdBookingQueryHandler : IRequestHandler<GetByIdBookingQuery, GetByIdBookingQueryResult>
    {
        private readonly IGenericRepository<Booking> _repository;
        private readonly IMapper _mapper;

        public GetByIdBookingQueryHandler(IGenericRepository<Booking> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GetByIdBookingQueryResult> Handle(GetByIdBookingQuery request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetByIdBookingQueryResult>(value);
        }
    }
}
