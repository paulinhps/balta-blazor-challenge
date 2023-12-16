using IbgeBlazor.Core.LocalityContext.Entities;

namespace IbgeBlazor.Core.LocalityContext.Repositories;

public  interface ICitiesRepository
{
    Task<City> CreateCity(City city);
    Task<bool> IsExistsCityWithIdOrUf(string ibgeCode, string cityName, string state );
}