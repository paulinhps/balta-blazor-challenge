using IbgeBlazor.Core.LocalityContext.Entities;
using IbgeBlazor.Core.LocalityContext.Repositories;
using IbgeBlazor.Core.LocalityContext.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace IbgeBlazor.Infraestructure.Data.Repositories;

public sealed class StatesRepository : IStatesRepository
{
    private readonly IApplicationDbContext _applicationDbContext;
    public StatesRepository(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<State> CreateState(State state)
    {
        try
        {
            var result = await _applicationDbContext.States.AddAsync(state);


            await _applicationDbContext.SaveChangesAsync(CancellationToken.None);



            return result.Entity;
        }
        catch (Exception ex)
        {

            throw;
        }
        
    }

    public async Task<bool> RemoveState(State state)
    {
        _applicationDbContext.States.Remove(state);

        await _applicationDbContext.SaveChangesAsync(CancellationToken.None);

        return true;
    }

    public async Task<State?> GetStateById(int id)
    => await _applicationDbContext.States
    .FirstOrDefaultAsync(state => state.Id == id);

    public async Task<bool> IsExistsStateWithIdOrUf(int stateId, StateCode ufCode)
    => await _applicationDbContext.States
        .AsNoTracking()
        .AnyAsync(state =>
            state.Id == stateId
            || state.Code.Equals(ufCode));

    public async Task<bool> UpdateState(State state)
    {
        _applicationDbContext.States.Update(state);

        await _applicationDbContext.SaveChangesAsync(CancellationToken.None);

        return true;
    }

    public async Task<IEnumerable<State>> ListStates(int pageNumber, int pageSize)
    {
        var take = pageSize;
        var skip = pageNumber > 1 ? take * (pageNumber - 1) : 0;

        return await _applicationDbContext.States
            .AsNoTracking()
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }

    public async Task<bool> IsExistsStateLinkedCity(int id)
    => await _applicationDbContext.States
    .AsNoTracking()
    .Include(c => c.Cities)
    .AnyAsync(state => state.Id == id && state.Cities.Any());

    public async Task<bool> IsExistsStateById(int id)
    => await _applicationDbContext.States
    .AsNoTracking()
    .AnyAsync(state => state.Id == id);
}