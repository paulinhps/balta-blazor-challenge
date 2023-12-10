using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.LocalityContext.UseCases.Localities.Commands;

namespace IbgeBlazor.Core.LocalityContext.UseCases.Localities.Handlers;

public interface IDeleteLocalityHandler
{
    Task<CommandResult> Handle(DeleteLocalityCommand command, CancellationToken cancellationToken);
}

