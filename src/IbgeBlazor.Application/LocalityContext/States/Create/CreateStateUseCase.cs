using IbgeBlazor.Core.Common.UseCases;
using IbgeBlazor.Core.LocalityContext.UseCases.States.Commands;

namespace IbgeBlazor.Application.LocalityContext.States.Create;

public class CreateStateUseCase : IUseCase<CreateStateCommand, StateCommandResult>
{
    public StateCommandResult Execute(CreateStateCommand command)
    {
        // call Handler
        throw new NotImplementedException(nameof(Execute));
    }
}
