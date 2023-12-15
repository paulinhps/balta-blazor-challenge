

using Flunt.Notifications;
using IbgeBlazor.Core.Common.DataModels;

namespace IbgeBlazor.Core.Common.Extensions;

public static class ErrorModelExtensions
{
    public static IEnumerable<IErrorModel> GetErrors(this Notifiable<Notification> item)
        => item.Notifications.Select(notification => new ErrorModel(notification.Key, notification.Message));
}