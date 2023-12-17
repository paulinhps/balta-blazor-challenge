using IbgeBlazor.Core.Common.Queries;
using IbgeBlazor.Core.LocalityContext.Entities;
using MediatR;

namespace IbgeBlazor.Application.LocalityContext.Cities.GetCityDetails;

public record GetCityDetailByIbgeCodeQuery(string IbgeCode) : IRequest<IQueryResult<City>>;
