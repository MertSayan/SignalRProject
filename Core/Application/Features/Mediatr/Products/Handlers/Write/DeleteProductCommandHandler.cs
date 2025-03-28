using Application.Features.Mediatr.Products.Commands;
using Application.Features.Mediatr.Products.Commands;
using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Products.Handlers.Write
{
    public class DeleteProductCommandHandler:IRequestHandler<DeleteProductCommand>
    {
        private readonly IGenericRepository<Product> _repository;

        public DeleteProductCommandHandler(IGenericRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
