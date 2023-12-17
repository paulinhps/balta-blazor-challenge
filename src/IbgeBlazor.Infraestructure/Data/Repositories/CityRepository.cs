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

        await _applicationDbContext.SaveChangesAsync(CancellationToken.None);

        return result.Entity;
    }

    public async Task<bool> IsExistsCityWithIbgeCode(IbgeCode ibgeCode)
        => await _applicationDbContext.Cities
            .AsNoTracking()
            .AnyAsync(city => city.Id.Equals(ibgeCode));



    public async Task<bool> DeleteCity(IbgeCode cityId)
    {
        var city = _applicationDbContext.Cities.First(city => city.Id.Equals(cityId));

        if (city == null) return false;

        _applicationDbContext.Cities.Remove(city);
        await _applicationDbContext.SaveChangesAsync(CancellationToken.None);

        return true;
    }

    public async Task<City> UpdateCity(City city)
    {
        var result = _applicationDbContext.Cities.Update(city);
        await _applicationDbContext.SaveChangesAsync(CancellationToken.None);
        return result.Entity;
    }


    public Task<bool> IsExistsStateLinkedCity(int Id)
    {
        throw new NotImplementedException();
    }

    public async Task<City?> GetCityByIbeCode(IbgeCode ibgeCode)
    => await _applicationDbContext.Cities.FirstOrDefaultAsync(city => city.Id.Equals(ibgeCode));

    public async Task<IEnumerable<City>> ListCities(int pageNumber, int pageSize)
    => await _applicationDbContext.Cities
        .AsNoTracking()
        .Include(c => c.State)
        .ToListAsync();
}