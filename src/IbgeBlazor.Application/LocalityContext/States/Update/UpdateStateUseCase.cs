using IbgeBlazor.Core.Common.UseCases;
using IbgeBlazor.Core.LocalityContext.UseCases.States.Commands;

namespace IbgeBlazor.Application.LocalityContext.States.Update;

public class UpdateStateUseCase : IUseCase<UpdateStateCommand, StateCommandResult>
{
    public StateCommandResult Execute(UpdateStateCommand command)
    {

        // call CreateStateHandler
        throw new NotImplementedException(nameof(Execute));
    }
}