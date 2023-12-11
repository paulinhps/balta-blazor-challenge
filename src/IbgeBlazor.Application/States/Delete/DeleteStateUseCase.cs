using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.Common.UseCases;
using IbgeBlazor.Core.LocalityContext.UseCases.States.Commands;

namespace IbgeBlazor.Application.States.Delete;

public class DeleteStateUseCase : IUseCase<DeleteStateCommand, CommandResult>
{
    public CommandResult Execute(DeleteStateCommand command)
    {

        // call Handler
        throw new NotImplementedException(nameof(Execute));
    }
}
