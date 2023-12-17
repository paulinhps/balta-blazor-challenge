using IbgeBlazor.Core.LocalityContext.Entities;
using IbgeBlazor.Core.LocalityContext.ValueObjects;

namespace IbgeBlazor.Core.LocalityContext.Repositories;

public  interface ICitiesRepository
{
    Task<City> CreateCity(City city);
    Task<bool> IsExistsCityWithIdOrUf(IbgeCode ibgeCode);
    
    Task<bool> IsExistsStateLinkedCity(int Id);
    void DeleteCity(int cityId);
    Task<City> UpdateCity(City city);

}