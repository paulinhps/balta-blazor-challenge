using IbgeBlazor.Core.Common.UseCases;
using IbgeBlazor.Core.LocalityContext.UseCases.Localities.Commands;

namespace IbgeBlazor.Application.Localities.Update;

public class UpdateLocalityUseCase : IUseCase<UpdateLocalityCommand, LocalityCommandResult>
{
    public LocalityCommandResult Execute(UpdateLocalityCommand command)
    {

        // call Handler
        throw new NotImplementedException(nameof(Execute));
    }
}