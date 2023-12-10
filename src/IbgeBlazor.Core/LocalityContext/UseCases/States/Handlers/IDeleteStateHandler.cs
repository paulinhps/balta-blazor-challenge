using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.LocalityContext.UseCases.States.Commands;

namespace IbgeBlazor.Core.LocalityContext.UseCases.States.Handlers;

public interface IDeleteStateHandler
{
    Task<CommandResult> Handle(DeleteStateCommand command, CancellationToken cancellationToken);
}

