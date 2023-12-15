using System.Text.RegularExpressions;
using Flunt.Validations;
using IbgeBlazor.Core.LocalityContext.Entities;

namespace IbgeBlazor.Core;

public class LocalityContract : Contract<Locality>
{
    public LocalityContract(Locality locality)
    {
        Requires()
        .IsNotNullOrWhiteSpace(locality.City, "Locality.City", "City is required")
        .IsGreaterThan(locality.StateId, 0, "Locality.State", "State is required");

        if (locality?.State is not null)
            AddNotifications(locality.State);

        if (locality?.Id is not null)
        {
            AddNotifications(locality.Id.AssertContaisStateId(locality.State.Id));

        }



    }
}
