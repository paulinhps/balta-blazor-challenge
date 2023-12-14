using System.Collections.Immutable;
using Flunt.Notifications;
using IbgeBlazor.Core.Common.DataModels;

namespace IbgeBlazor.Core.Common.Commands;

public interface ICommandResult<TData> : ICommandResult where TData : class {
    TData? Data {get;}
}

public interface ICommandResult
{
    string Message { get; }
    bool Success {get;}

    IEnumerable<IErrorModel> Errors {get;}

    void AddErrors(params Notifiable<Notification>[] notifications);
    void AddErrors(string message, params Notifiable<Notification>[] notifications);


}
