using IbgeBlazor.Core.Common.Queries;
using IbgeBlazor.Core.LocalityContext.Entities;
using IbgeBlazor.Core.LocalityContext.Repositories;
using MediatR;

namespace IbgeBlazor.Application.LocalityContext.States.GetStateDetails;

public class Handler :
IRequestHandler<GetStateDetailByIdQuery, IQueryResult<State>>
{
    private readonly IStatesRepository _statesRepository;

    public Handler(IStatesRepository statesRepository)
    {
        _statesRepository = statesRepository;
    }


    public async Task<IQueryResult<State>> Handle(GetStateDetailByIdQuery request, CancellationToken cancellationToken)
    {

        if (request is null)
            return new QueryResult<State>(null!);

        try
        {
            State? items = await _statesRepository.GetStateById(request.Id);

            return new QueryResult<State>(items);
        }
        catch (Exception)
        {
            // Deveriamos tratar erro, podemos colocar no backlog
            return new QueryResult<State>(null!);
        }
    }
}
