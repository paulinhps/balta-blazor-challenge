using IbgeBlazor.Core.Common.Queries;
using IbgeBlazor.Core.LocalityContext.Entities;
using IbgeBlazor.Core.LocalityContext.Repositories;
using IbgeBlazor.Core.LocalityContext.ValueObjects;
using MediatR;

namespace IbgeBlazor.Application.LocalityContext.Cities.GetCityList;

public class Handler : IRequestHandler<GetCitiesWithPaginationQuery, IQueryResult<IEnumerable<City>>>
{
    private readonly ICitiesRepository _statesRepository;

    public Handler(ICitiesRepository statesRepository)
    {
        _statesRepository = statesRepository;
    }

    public async Task<IQueryResult<IEnumerable<City>>> Handle(GetCitiesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
            return new QueryResult<IEnumerable<City>>([]);

        try
        {
            IEnumerable<City> items = await _statesRepository.ListCities(new PaginationQuery(request.PageNumber, request.PageSize));

            return new QueryResult<IEnumerable<City>>(items);
        }
        catch (Exception)
        {
            // Deveriamos tratar erro, podemos colocar no backlog
            return new QueryResult<IEnumerable<City>>([]);
        }

    }
}