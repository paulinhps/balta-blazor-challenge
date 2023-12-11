
using IbgeBlazor.Core.Common.Commands;

namespace IbgeBlazor.Core.Common.UseCases;

public interface IUseCase<TCommand, TCommandResult> 
 where TCommand : ICommand
 where TCommandResult : ICommandResult
{
    TCommandResult Execute(TCommand command);
}