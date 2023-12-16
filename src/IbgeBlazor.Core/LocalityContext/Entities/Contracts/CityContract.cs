using Flunt.Validations;

namespace IbgeBlazor.Core.LocalityContext.Entities.Contracts
{
    internal class CityContract : Contract<City>
    {
        public CityContract(City cities)
        {
            Requires()
                .IsNotNull(cities.IbgeCode, "City.IbgeCode", "Code IBGE is required")
                .IsNotNull(cities.CityName, "City.CityName", "Name City IBGE is required")
                .IsNotNull(cities.UfCode, "City.UfCode", "UF is required");


            //Code Rules Notifications
            //AddNotifications(cities.IbgeCode);
            //AddNotifications(cities.CityName);
            //AddNotifications(cities.UfCode);

        }
    }
}