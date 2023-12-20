using IbgeBlazor.Core.Common.Queries;
using IbgeBlazor.Core.LocalityContext.Entities;
using IbgeBlazor.Core.LocalityContext.Repositories;
using IbgeBlazor.Core.LocalityContext.ValueObjects;
using MediatR;

namespace IbgeBlazor.Application.LocalityContext.States.GetStatesList
{
    public class Handler : IRequestHandler<GetStateWithPaginationQuery, IQueryResult<IEnumerable<State>>>
    {
        private readonly IStatesRepository _statesRepository;

        public Handler(IStatesRepository statesRepository)
        {
            _statesRepository = statesRepository;
        }

        public async Task<IQueryResult<IEnumerable<State>>> Handle(GetStateWithPaginationQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                return new QueryResult<IEnumerable<State>>([]);

            try
            {
                IEnumerable<State> items = await _statesRepository.ListStates(new PaginationQuery(request.PageNumber, request.PageSize));

                return new QueryResult<IEnumerable<State>>(items);
            }
            catch (Exception)
            {
                // Deveriamos tratar erro, podemos colocar no backlog
                return new QueryResult<IEnumerable<State>>([]);
            }

        }
    }
}