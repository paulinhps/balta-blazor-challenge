using IbgeBlazor.Core.LocalityContext.Entities;
using IbgeBlazor.Core.LocalityContext.ValueObjects;

namespace IbgeBlazor.Core.LocalityContext.Repositories;

public interface ICitiesRepository
{
    Task<City> CreateCity(City city);
    Task<bool> IsExistsCityWithIbgeCode(IbgeCode ibgeCode);

    Task<bool> IsExistsStateLinkedCity(int Id);
    Task<bool> DeleteCity(IbgeCode cityId);
    Task<City> UpdateCity(City city);
    Task<City?> GetCityByIbeCode(IbgeCode ibgeCode);
    Task<IEnumerable<City>> ListCities(int pageNumber, int pageSize);
}