using IbgeBlazor.Core.LocalityContext.Entities;
using IbgeBlazor.Core.LocalityContext.Repositories;
using IbgeBlazor.Core.LocalityContext.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

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
        var city = await _applicationDbContext.Cities.FirstAsync(city => city.Id.Equals(cityId));

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
    public async Task<City?> GetCityByIbeCode(IbgeCode ibgeCode)
    => await _applicationDbContext.Cities.Include(city => city.State).FirstOrDefaultAsync(city => city.Id.Equals(ibgeCode));

    public async Task<IEnumerable<City>> ListCities(PaginationQuery pagination)
    => await _applicationDbContext.Cities
            .AsNoTracking()
            .Include(city => city.State)
            .Skip(pagination.Skip())
            .Take(pagination.Take())
            .ToListAsync();

    public async Task<IEnumerable<City>> SearchCities(LocalityQueryParameters parameters)
    {
        var byIbgeCode = _applicationDbContext.Cities
             .AsNoTracking()
             .Include(city => city.State)
             .Where(city => city.Id.Code == parameters.Term);

        if(byIbgeCode.Any()) return await byIbgeCode.ToListAsync();

        var byName = _applicationDbContext.Cities
                .AsNoTracking().Include(city => city.State)
                .Where(city => EF.Functions.Like(city.Name, $@"%{parameters.Term}%"));
            
        var byUfCode = _applicationDbContext.Cities
                .AsNoTracking().Include(city => city.State)
                //.Where(city => EF.Functions.Like(city.State.Code.CodeNumber, parameters.Term));
        .Where(city => EF.Functions.Like(city.Name, parameters.Term));

        return await byName.Concat(byUfCode)
            .Distinct(CityComparer.Instance)
            .Skip(parameters.Skip())
            .Take(parameters.Take())
            .ToListAsync();

    }

    private class CityComparer : IEqualityComparer<City>
    {
        public bool Equals(City? x, City? y)
        => x.Id.Equals(y.Id);

        public int GetHashCode([DisallowNull] City obj)
        => obj.Id.GetHashCode();

        internal static CityComparer Instance { get; } = new CityComparer();
    }

}