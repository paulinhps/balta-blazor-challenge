using Flunt.Notifications;

namespace IbgeBlazor.Core.Common.Commands;

public abstract class CommandBase : Notifiable<Notification>, ICommand
{
    public abstract void Validate();
}