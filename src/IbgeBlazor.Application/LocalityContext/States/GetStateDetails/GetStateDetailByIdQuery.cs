using IbgeBlazor.Core.Common.Queries;
using IbgeBlazor.Core.LocalityContext.Entities;
using MediatR;

namespace IbgeBlazor.Application.LocalityContext.States.GetStateDetails;

public record GetStateDetailByIdQuery(int Id) : IRequest<IQueryResult<State>>;
