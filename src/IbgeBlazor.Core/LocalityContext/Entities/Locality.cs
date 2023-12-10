using IbgeBlazor.Core.Common.Commands.Entities;
using IbgeBlazor.Core.LocalityContext.ValueObjects;

namespace IbgeBlazor.Core.LocalityContext.Entities;

public class Locality : GenericEntity<IbgeCode>
{
    public string City { get; private set; }

    public int StateId { get; set; }
    public State State { get; set; }
    public Locality(IbgeCode id, string city, State state) : base(id)
    {
        City = city;
        State = state;

        Validate();
        
    }

    protected override void Validate() => AddNotifications(new LocalityContract(this));
    
}
