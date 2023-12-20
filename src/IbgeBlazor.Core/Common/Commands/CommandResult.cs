using Flunt.Notifications;
using IbgeBlazor.Core.Common.DataModels;
using IbgeBlazor.Core.Common.Extensions;
using IbgeBlazor.Core.Enumerators;

namespace IbgeBlazor.Core.Common.Commands;

public class CommandResult : Notifiable<Notification>, ICommandResult
{
    public string Message { get; protected set; } = null!;

    public virtual bool Success => IsValid;

    public IEnumerable<ErrorModel> Errors => this.GetErrors();

    public CommandResultType ResultCode { get; protected set; } = CommandResultType.InputedError;
    public CommandResult(string message) : this()
    {
        Message = message;
    }

    public CommandResult()
    {
    }


    public ICommandResult AddErrors(params Notifiable<Notification>[] items)
    {
        AddNotifications(items);

        return this;
    }

    public ICommandResult WithMessage(string message)
    {
        Message = message;

        return this;
    }

    public virtual ICommandResult WithStatus(CommandResultType resultStatus)
    {
        ResultCode = resultStatus;

        return this;
    }

    public ICommandResult AddMessageWhenInvalid(string message)
    {
        if (!Success)
        {
            return WithMessage(message);
        }

        return this;
    }

    public ICommandResult AddStateWhenInvalid(CommandResultType resultStatus)
    {
        if (!Success)
        {
            return WithStatus(resultStatus);
        }

        return this;
    }

    public static ICommandResult CreateCommandResult() => new CommandResult();
    public static ICommandResult<TData> CreateCommandResult<TData>() where TData : class => new DataCommandResult<TData>();

}

