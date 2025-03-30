using Application.Features.Mediatr.Tables.Queries;
using Application.Features.Mediatr.Tables.Results;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediatr.Tables.Handlers.Read
{
    public class GetTableCountQueryHandler : IRequestHandler<GetTableCountQuery, GetTableCountQueryResult>
    {
        private readonly ITableRepository _tableRepository;

        public GetTableCountQueryHandler(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        public async Task<GetTableCountQueryResult> Handle(GetTableCountQuery request, CancellationToken cancellationToken)
        {
            int count = await _tableRepository.GetTableCount();
            return new GetTableCountQueryResult
            {
                Count= count
            };
        }
    }
}
