using IbgeBlazor.Core.LocalityContext.Entities;
using IbgeBlazor.Core.LocalityContext.Repositories;
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
        var result = await _applicationDbContext.States.AddAsync(state);

        await _applicationDbContext.SaveChangesAsync(CancellationToken.None);

        return result.Entity;
    }

    public async Task<State?> GetStateById(int id)
    => await _applicationDbContext.States.FirstOrDefaultAsync(state => state.Id == id);

    public async Task<bool> IsExistsStateWithIdOrUf(int stateId, string ufCode)
    => await _applicationDbContext.States
        .AsNoTracking()
        .AnyAsync(state =>
            state.Id == stateId
            || state.Code == ufCode);

    public async Task<bool> UpdateState(State state)
    {
        
        _applicationDbContext.States.Update(state);

        await _applicationDbContext.SaveChangesAsync(CancellationToken.None);

        return true;
    }
}