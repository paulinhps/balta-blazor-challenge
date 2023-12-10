using IbgeBlazor.Core.LocalityContext.UseCases.Localities.Commands;

namespace IbgeBlazor.Core.LocalityContext.UseCases.Localities.Handlers;

public interface IUpdateLocalityHandler
{
    Task<LocalityCommandResult> Handle(UpdateLocalityCommand command, CancellationToken cancellationToken);
}

