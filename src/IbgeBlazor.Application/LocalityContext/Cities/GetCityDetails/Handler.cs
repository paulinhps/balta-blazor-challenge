using IbgeBlazor.Core.Common.Queries;
using IbgeBlazor.Core.LocalityContext.Entities;
using IbgeBlazor.Core.LocalityContext.Repositories;
using MediatR;

namespace IbgeBlazor.Application.LocalityContext.Cities.GetCityDetails;

public class Handler :
IRequestHandler<GetCityDetailByIbgeCodeQuery, IQueryResult<City>>
{
    private readonly ICitiesRepository _statesRepository;

    public Handler(ICitiesRepository statesRepository)
    {
        _statesRepository = statesRepository;
    }


    public async Task<IQueryResult<City>> Handle(GetCityDetailByIbgeCodeQuery request, CancellationToken cancellationToken)
    {

        if (request is null)
            return new QueryResult<City>(null!);

        try
        {
            City? items = await _statesRepository.GetCityByIbeCode(request.IbgeCode);

            return new QueryResult<City>(items);
        }
        catch (Exception)
        {
            // Deveriamos tratar erro, podemos colocar no backlog
            return new QueryResult<City>(null!);
        }
    }
}
