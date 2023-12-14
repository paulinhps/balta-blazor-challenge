using Flunt.Notifications;
using IbgeBlazor.Core.Common.DataModels;
using IbgeBlazor.Core.Common.Extensions;

namespace IbgeBlazor.Core.Common.Commands;

public class CommandResult : Notifiable<Notification>, ICommandResult
{
    public string Message { get; protected set; } = null!;

    public virtual bool Success => IsValid;

    public IEnumerable<IErrorModel> Errors => this.GetErrors();

    public CommandResult(string message)
    {
        Message = message;
    }

    public CommandResult()
    {
        
    }

    public void AddErrors(params Notifiable<Notification>[] items)
    => AddNotifications(items);

    public void AddErrors(string message, params Notifiable<Notification>[] items)
    {
        Message = message;
        AddErrors(items);
    }
}
