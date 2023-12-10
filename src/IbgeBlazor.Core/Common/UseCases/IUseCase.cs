using IbgeBlazor.Core.Common.Commands;

namespace IbgeBlazor.Core.Common.UseCases;

public interface IUseCase
{
    ICommandResult Execute(ICommand command);
}