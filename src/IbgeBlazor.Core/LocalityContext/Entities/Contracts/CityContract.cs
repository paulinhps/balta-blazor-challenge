using Flunt.Validations;

namespace IbgeBlazor.Core.LocalityContext.Entities.Contracts
{
    internal class CityContract : Contract<City>
    {
        public CityContract(City cities)
        {
            Requires()
                .IsNotNull(cities.CityName, "City.CityName", "Name City IBGE is required")
                .IsGreaterThan(cities.StateId,0, "City.UfCode", "UF is required");


            //Code Rules Notifications
            if (cities.State != null)
                AddNotifications(cities.State);
            
            if (cities.Id != null)
                AddNotifications(cities.Id.AssertContaisStateId(cities.StateId));
        }
    }
}