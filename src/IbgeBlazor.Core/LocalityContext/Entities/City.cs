﻿using IbgeBlazor.Core.Common.Commands.Entities;
using IbgeBlazor.Core.LocalityContext.Entities.Contracts;
using IbgeBlazor.Core.LocalityContext.ValueObjects;

namespace IbgeBlazor.Core.LocalityContext.Entities
{
    public class City : GenericEntity<IbgeCode>
    {
        public string Name { get; private set; } = null!;
        public int StateId { get; private set; }
        public State State { get; } = null!;

        public City(IbgeCode id, string name, int stateId) : base(id)
        {
            Name = name;
            StateId = stateId;
            Validate();
        }

        protected override void Validate()
        {
            Clear();

            AddNotifications(new CityContract(this));
        }

        public void ChangeCityName(string cityName)
        {
            Name = cityName;

            Validate();
        }
    }
}