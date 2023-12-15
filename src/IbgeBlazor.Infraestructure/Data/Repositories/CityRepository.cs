using IbgeBlazor.Core.LocalityContext.Entities;
using IbgeBlazor.Core.LocalityContext.Repositories;
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

    public async Task<bool> IsExistsCityWithIdOrUf(string ibgeCode, string cityName) => await _applicationDbContext.Cities
            .AsNoTracking()
            .AnyAsync(city => city.IbgeCode == ibgeCode || city.CityName == cityName);
}