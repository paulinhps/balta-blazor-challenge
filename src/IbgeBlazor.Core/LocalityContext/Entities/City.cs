using IbgeBlazor.Core.Common.Commands.Entities;
using IbgeBlazor.Core.LocalityContext.Entities.Contracts;
using IbgeBlazor.Core.LocalityContext.ValueObjects;

namespace IbgeBlazor.Core.LocalityContext.Entities
{
    public class City : GenericEntity<IbgeCode>
    {
      public string CityName { get; set; } = null!;
        public int StateId { get; set; }
        public State State { get; set; } = null!;

        public City(IbgeCode id, string cityName, int stateId) : base(id)
        {
            CityName = cityName;
            StateId = stateId;
            Validate();
        }

        protected override void Validate()
        {
            AddNotifications(new CityContract(this));
        }
    }
}