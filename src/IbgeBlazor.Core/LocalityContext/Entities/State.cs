using IbgeBlazor.Core.Common.Commands.Entities;
using IbgeBlazor.Core.LocalityContext.Entities.Contracts;
using IbgeBlazor.Core.LocalityContext.ValueObjects;

namespace IbgeBlazor.Core.LocalityContext.Entities;

public class State : Entity
{
    public StateCode Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public virtual int CityId { get; }
    public virtual IEnumerable<City> Cities { get; } = null!;

    public State(int id, StateCode code, string name) : base(id)
    {
        Code = code;
        Name = name;
        Validate();
    }

    protected override void Validate()
    {
        AddNotifications(new StateContract(this));
    }

    public void ChangeDescription(string description)
    {
        Name = description;
    }
}
