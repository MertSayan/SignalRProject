using Application.Features.Mediatr.Baskets.Commands;
using Application.Features.Mediatr.Baskets.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Baskets.Handlers.Write
{
    public class UpdateBasketCommandHandler:IRequestHandler<UpdateBasketCommand>
    {
        private readonly IGenericRepository<Basket> _repository;
        private readonly IMapper _mapper;

        public UpdateBasketCommandHandler(IGenericRepository<Basket> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.BasketId);
            _mapper.Map(request, value);
            await _repository.UpdateAsync(value);

        }
    }
}
