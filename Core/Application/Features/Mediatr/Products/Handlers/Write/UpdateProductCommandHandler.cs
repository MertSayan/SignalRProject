using Application.Features.Mediatr.Products.Commands;
using Application.Features.Mediatr.Products.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Products.Handlers.Write
{
    public class UpdateProductCommandHandler:IRequestHandler<UpdateProductCommand>
    {
        private readonly IGenericRepository<Product> _repository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IGenericRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ProductId);
            _mapper.Map(request, value);
            await _repository.UpdateAsync(value);

        }
    }
}
