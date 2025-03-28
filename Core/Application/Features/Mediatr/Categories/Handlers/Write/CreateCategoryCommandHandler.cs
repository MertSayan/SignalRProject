using Application.Features.Mediatr.Categories.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Categories.Handlers.Write
{
    public class CreateCategoryCommandHandler:IRequestHandler<CreateCategoryCommand>
    {
        private readonly IGenericRepository<Category> _genericRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IGenericRepository<Category> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {

            var value = _mapper.Map<Category>(request);
            await _genericRepository.CreateAsync(value);
        }
    }
}
