using IbgeBlazor.Core.Common.Commands.Entities;
using IbgeBlazor.Core.LocalityContext.Entities.Contracts;

namespace IbgeBlazor.Core.LocalityContext.Entities
{
    public class City : Entity
    {

        public string IbgeCode { get; set; }
        public string CityName { get; set; }
        public string UfCode { get; set; }

        public City(int id, int ibgeCode, string cityName, int ufCode) : base(id)
        {
            IbgeCode = ibgeCode;
            CityName = cityName;
            UfCode = ufCode;
            Validate();
        }

        protected override void Validate()
        {
            AddNotifications(new CityContract(this));
        }
    }
}
