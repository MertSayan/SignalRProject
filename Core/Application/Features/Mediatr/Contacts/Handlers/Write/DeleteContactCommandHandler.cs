using Application.Features.Mediatr.Contacts.Commands;
using Application.Features.Mediatr.Contacts.Commands;
using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Contacts.Handlers.Write
{
    public class DeleteContactCommandHandler:IRequestHandler<DeleteContactCommand>
    {
        private readonly IGenericRepository<Contact> _repository;

        public DeleteContactCommandHandler(IGenericRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
