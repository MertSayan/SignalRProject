using Application.Features.Mediatr.Bookings.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Bookings.Handlers.Write
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand>
    {
        private readonly IGenericRepository<Booking> _repository;
        private readonly IMapper _mapper;

        public CreateBookingCommandHandler(IGenericRepository<Booking> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Booking>(request);
            await _repository.CreateAsync(book);
        }
    }
}
