using Application.Features.Mediatr.Abouts.Commands;
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
    public class UpdateBookingCommandHandler:IRequestHandler<UpdateBookingCommand>
    {
        private readonly IGenericRepository<Booking> _repository;
        private readonly IMapper _mapper;

        public UpdateBookingCommandHandler(IGenericRepository<Booking> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.BookingId);
            _mapper.Map(request, value);
            await _repository.UpdateAsync(value);

        }
    }
}
