using Flunt.Notifications;
using IbgeBlazor.Core.Common.DataModels;

namespace IbgeBlazor.Core.Common.Commands;

public interface ICommandResult<TData> : ICommandResult where TData : class
{
    TData? Data { get;}

    ICommandResult<TData> WithData(TData? data);

   
}

public interface ICommandResult
{

    string Message { get; }
    bool Success { get; }

    int ResultCode {get;}

    IEnumerable<IErrorModel> Errors { get; }

    ICommandResult AddErrors(params Notifiable<Notification>[] items);
    ICommandResult AddMessageWhenInvalid(string message);
    ICommandResult AddStateWhenInvalid(int resultStatus);
    ICommandResult WithMessage(string message);
    ICommandResult WithStatus(int resultStatus);
    

}
