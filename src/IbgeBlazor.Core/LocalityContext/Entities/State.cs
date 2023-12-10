using IbgeBlazor.Core.Common.Commands.Entities;
using IbgeBlazor.Core.LocalityContext.Entities.Contracts;
using IbgeBlazor.Core.LocalityContext.ValueObjects;

namespace IbgeBlazor.Core.LocalityContext.Entities;

public class State  : Entity
{
    public StateCode Code { get; set; }
    public string Description { get; set; }
    public State(int id, StateCode code, string description ) : base(id)
    {
        Code = code;
        Description = description;
        Validate();
    }

    protected override void Validate()
    {
        AddNotifications(new StateContract(this));
    }
}
