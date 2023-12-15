using IbgeBlazor.Core.Common.Queries;
using IbgeBlazor.Core.LocalityContext.Entities;
using MediatR;

namespace IbgeBlazor.Application.LocalityContext.States.GetStatesList
{
    public class GetStateWithPaginationQuery
    : ListQuery, IRequest<IQueryResult<IEnumerable<State>>>
    {
    }
}