using IbgeBlazor.Core.Common.Commands.Entities;
using IbgeBlazor.Core.LocalityContext.Entities.Contracts;
using IbgeBlazor.Core.LocalityContext.ValueObjects;

namespace IbgeBlazor.Core.LocalityContext.Entities
{
    public class City : GenericEntity<IbgeCode>
    {
      public string CityName { get; set; }
        public int StateCode { get; set; }
        public State State { get; set; }

        public City(IbgeCode ibgeCode, string cityName, int stateCode) : base(ibgeCode)
        {
            CityName = cityName;
            StateCode = stateCode;
            Validate();
        }

        protected override void Validate()
        {
            AddNotifications(new CityContract(this));
        }
    }
}