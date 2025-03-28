using Application.Features.Mediatr.Abouts.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Abouts.Handlers.Write
{
    public class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommand>
    {
        private readonly IGenericRepository<About> _repository;
        private readonly IMapper _mapper;

        public UpdateAboutCommandHandler(IGenericRepository<About> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.AboutId);
            _mapper.Map(request, value);
            await _repository.UpdateAsync(value);

        }
    }
}
