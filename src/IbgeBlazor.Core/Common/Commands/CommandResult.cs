namespace IbgeBlazor.Core.Common.Commands;

public class CommandResult : ICommandResult
{
    public bool Success { get; private set; }
    public string Message { get; private set; }

    public CommandResult( bool success, string message)
    {
        Success = success;
        Message = message;
    }
}
