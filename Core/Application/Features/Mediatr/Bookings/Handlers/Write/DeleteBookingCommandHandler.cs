using Application.Features.Mediatr.Abouts.Commands;
using Application.Features.Mediatr.Bookings.Commands;
using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Bookings.Handlers.Write
{
    public class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand>
    {
        private readonly IGenericRepository<Booking> _repository;

        public DeleteBookingCommandHandler(IGenericRepository<Booking> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
