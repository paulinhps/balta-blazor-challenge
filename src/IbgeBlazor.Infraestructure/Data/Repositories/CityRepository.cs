using IbgeBlazor.Core.LocalityContext.Entities;
using IbgeBlazor.Core.LocalityContext.Repositories;
using IbgeBlazor.Core.LocalityContext.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace IbgeBlazor.Infraestructure.Data.Repositories;

public sealed class CityRepository : ICitiesRepository
{
    private readonly IApplicationDbContext _applicationDbContext;
    public CityRepository(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }


    public async Task<City> CreateCity(City city)
    {
        var result = await _applicationDbContext.Cities.AddAsync(city);

        _applicationDbContext.SaveChangesAsync(CancellationToken.None);

        return result.Entity;
    }

    public async Task<bool> IsExistsCityWithIdOrUf(IbgeCode ibgeCode) 
        => await _applicationDbContext.Cities
            .AsNoTracking()
            .AnyAsync(city => city.Id.Equals(ibgeCode));


    public async Task<bool> IsExistsStateLinkedCity(int Id) 
        => await _applicationDbContext.Cities
        .AsNoTracking()
        .AnyAsync(city => city.StateId.Equals(Id));


    public void DeleteCity(int cityId)
    {
        var city = _applicationDbContext.Cities.AsNoTracking().First(city => city.Id.Equals(cityId));
        if (city != null)
        {
            _applicationDbContext.Cities.Remove(city);
            _applicationDbContext.SaveChangesAsync(CancellationToken.None);
        }
    }

    public async Task<City> UpdateCity(City city)
    {
        var result = _applicationDbContext.Cities.Update(city);
        await _applicationDbContext.SaveChangesAsync(CancellationToken.None);
        return result.Entity;
    }
}