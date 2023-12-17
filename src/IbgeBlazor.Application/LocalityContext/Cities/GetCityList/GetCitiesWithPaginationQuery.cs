using IbgeBlazor.Core.Common.Queries;
using IbgeBlazor.Core.LocalityContext.Entities;
using MediatR;

namespace IbgeBlazor.Application.LocalityContext.Cities.GetCityList;

public class GetCitiesWithPaginationQuery
: ListQuery, IRequest<IQueryResult<IEnumerable<City>>>
{
}