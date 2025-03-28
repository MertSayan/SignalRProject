using Application.Features.Mediatr.Products.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Products.Handlers.Write
{
    public class CreateProductCommandHandler:IRequestHandler<CreateProductCommand>
    {
        private readonly IGenericRepository<Product> _genericRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IGenericRepository<Product> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {

            var value = _mapper.Map<Product>(request);
            await _genericRepository.CreateAsync(value);
        }
    }
}
