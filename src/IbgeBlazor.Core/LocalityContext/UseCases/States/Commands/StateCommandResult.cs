using IbgeBlazor.Core.Common.Commands;
using IbgeBlazor.Core.LocalityContext.Entities;

namespace IbgeBlazor.Core.LocalityContext.UseCases.States.Commands;

public class StateCommandResult : DataContentResult<State>
{
    public StateCommandResult(State data, bool success, string message) : base(data, success, message)
    {
    }
}
