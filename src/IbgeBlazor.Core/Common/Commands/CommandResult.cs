using Flunt.Notifications;
using IbgeBlazor.Core.Common.DataModels;
using IbgeBlazor.Core.Common.Extensions;

namespace IbgeBlazor.Core.Common.Commands;

public class CommandResult : Notifiable<Notification>, ICommandResult
{
    public string Message { get; protected set; } = null!;

    public virtual bool Success => IsValid;

    public IEnumerable<IErrorModel> Errors => this.GetErrors();

    public int ResultCode { get; protected set; } = 400;
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

    public virtual ICommandResult WithStatus(int resultStatus)
    {
        ResultCode = resultStatus;

        return this;
    }

    public ICommandResult AddMessageWhenInvalid(string message)
    {
        if(!Success)
         {
            return WithMessage(message);
         }

         return this;
    }

    public ICommandResult AddStateWhenInvalid(int resultStatus)
    {
        if(!Success)
         {
            return WithStatus(resultStatus);
         }

         return this;
    }
}

public enum CommandResultTypes {
    Success = 200,
    Created = 201,
    InputedError = 400,
    ProccessErro = 422,
}
