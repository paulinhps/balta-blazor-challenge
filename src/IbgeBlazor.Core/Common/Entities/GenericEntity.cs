using Flunt.Notifications;

namespace IbgeBlazor.Core.Common.Commands.Entities;

public abstract class GenericEntity<T> : Notifiable<Notification>{

     public T Id { get; }

    public GenericEntity(T id)
    {
        Id = id;
    }

    protected abstract void Validate();
}