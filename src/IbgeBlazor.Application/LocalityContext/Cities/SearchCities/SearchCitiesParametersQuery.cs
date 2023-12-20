
using IbgeBlazor.Core.Common.Queries;
using IbgeBlazor.Core.LocalityContext.Entities;
using MediatR;

namespace IbgeBlazor.Application.LocalityContext.Cities.SearchCities;

public class SearchCitiesParametersQuery : ListQuery, IRequest<IQueryResult<IEnumerable<City>>>
{
    public string? Term { get; set; }
}