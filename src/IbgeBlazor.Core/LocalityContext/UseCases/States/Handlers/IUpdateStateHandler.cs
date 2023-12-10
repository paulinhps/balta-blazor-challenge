using IbgeBlazor.Core.LocalityContext.UseCases.States.Commands;

namespace IbgeBlazor.Core.LocalityContext.UseCases.States.Handlers;

public interface IUpdateStateHandler
{

    Task<StateCommandResult> Handle(UpdateStateCommand command, CancellationToken cancellationToken);
}

