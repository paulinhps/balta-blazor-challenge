using IbgeBlazor.Core.Common.Commands.Entities;
using IbgeBlazor.Core.LocalityContext.ValueObjects;

namespace IbgeBlazor.Core.LocalityContext.Entities;

public class Locality : GenericEntity<IbgeCode>
{
    public string City { get; private set; }

    public int StateId { get; set; }
    public State State { get; set; } = null!;
    public Locality(IbgeCode id, string city, int stateId) : base(id)
    {
        City = city;
        StateId = stateId;

        Validate();

    }

    protected override void Validate() => AddNotifications(new LocalityContract(this));

}
