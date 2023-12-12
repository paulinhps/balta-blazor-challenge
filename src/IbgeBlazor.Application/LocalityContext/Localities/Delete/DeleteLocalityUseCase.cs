using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.Common.UseCases;
using IbgeBlazor.Core.LocalityContext.UseCases.Localities.Commands;

namespace IbgeBlazor.Application.LocalityContext.Localities.Delete;

public class DeleteLocalityUseCase : IUseCase<DeleteLocalityCommand, CommandResult>
{
    public CommandResult Execute(DeleteLocalityCommand command)
    {

        // call Handler
        throw new NotImplementedException(nameof(Execute));
    }
}
