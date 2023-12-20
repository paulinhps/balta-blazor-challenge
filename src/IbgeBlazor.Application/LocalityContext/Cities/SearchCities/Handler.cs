
using IbgeBlazor.Core.Common.Queries;
using IbgeBlazor.Core.LocalityContext.Entities;
using IbgeBlazor.Core.LocalityContext.Repositories;
using IbgeBlazor.Core.LocalityContext.ValueObjects;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IbgeBlazor.Application.LocalityContext.Cities.SearchCities;
public class Handler :
IRequestHandler<SearchCitiesParametersQuery, IQueryResult<IEnumerable<City>>>
{
    private readonly ICitiesRepository _statesRepository;
    private readonly ILogger _logger;

    public Handler(ICitiesRepository statesRepository, ILogger<Handler> logger)
    {
        _statesRepository = statesRepository;
        _logger = logger;
    }


    public async Task<IQueryResult<IEnumerable<City>>> Handle(SearchCitiesParametersQuery request, CancellationToken cancellationToken)
    {

        if (request is null)
            return new QueryResult<IEnumerable<City>>(null!);


        LocalityQueryParameters parameters = new LocalityQueryParameters(request.Term, request.PageNumber, request.PageSize);

        try
        {
            IEnumerable<City>? items = await _statesRepository.SearchCities(parameters);

            return new QueryResult<IEnumerable<City>>(items);
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex, $"Houve erro ao listar cidades");
            // Deveriamos tratar erro, podemos colocar no backlog
            return new QueryResult<IEnumerable<City>>(null!);
        }
    }
}
