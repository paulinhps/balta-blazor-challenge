using IbgeBlazor.Core.LocalityContext.UseCases.States.Commands;

namespace IbgeBlazor.Core.LocalityContext.UseCases.States.Handlers;

public interface ICreateStateHandler
{
    Task<StateCommandResult> Handle(CreateStateCommand command, CancellationToken cancellationToken);
}
