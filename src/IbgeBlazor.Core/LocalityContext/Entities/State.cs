using IbgeBlazor.Core.Common.Commands.Entities;
using IbgeBlazor.Core.LocalityContext.Entities.Contracts;
using IbgeBlazor.Core.LocalityContext.ValueObjects;

namespace IbgeBlazor.Core.LocalityContext.Entities;

public class State : Entity
{
    public StateCode Code { get; private set; }
    public string Description { get; private set; }
    //TODO: Precisa mapear Locality para podemos ter acesso.
    // public IReadOnlyList<Locality> Localities {get;} = [];
    public State(int id, StateCode code, string description) : base(id)
    {
        Code = code;
        Description = description;
        Validate();
    }

    protected override void Validate()
    {
        AddNotifications(new StateContract(this));
    }

    public void ChangeDescription(string description)
    {
        Description = description;
    }
}
