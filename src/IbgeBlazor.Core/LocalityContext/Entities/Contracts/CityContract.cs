using Flunt.Validations;

namespace IbgeBlazor.Core.LocalityContext.Entities.Contracts
{
    internal class CityContract : Contract<City>
    {
        public CityContract(City cities)
        {
            Requires()
                .IsNotNull(cities.IbgeCode, "Ibge.Code", "Code IBGE is required")
                .IsNotNull(cities.CityName, "Ibge.Code", "Name City IBGE is required")
                .IsNotNull(cities.UfCode, "Uf.Code", "UF is required");
                

            //Code Rules Notifications
            //AddNotifications(cities);

        }
    }
}
