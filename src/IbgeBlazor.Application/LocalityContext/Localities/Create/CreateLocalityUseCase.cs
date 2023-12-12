using IbgeBlazor.Core.Common.UseCases;
using IbgeBlazor.Core.LocalityContext.UseCases.Localities.Commands;

namespace IbgeBlazor.Application.LocalityContext.Localities.Create;

public class CreateLocalityUseCase : IUseCase<CreateLocalityCommand, LocalityCommandResult>
{
    public LocalityCommandResult Execute(CreateLocalityCommand command)
    {
        // call Handler
        throw new NotImplementedException(nameof(Execute));
    }
}
