using IbgeBlazor.Core.LocalityContext.UseCases.Localities.Commands;

namespace IbgeBlazor.Core.LocalityContext.UseCases.Localities.Handlers;

public interface ICreateLocalityHandler
{
    Task<LocalityCommandResult> Handle(CreateLocalityCommand command, CancellationToken cancellationToken);
}
