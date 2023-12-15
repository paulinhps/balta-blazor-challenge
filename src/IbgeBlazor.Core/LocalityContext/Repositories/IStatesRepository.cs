
using IbgeBlazor.Core.LocalityContext.Entities;

namespace IbgeBlazor.Core.LocalityContext.Repositories;

public interface IStatesRepository
{
    Task<State> CreateState(State state);
    Task<State?> GetStateById(int id);
    Task<bool> IsExistsStateWithIdOrUf(int stateId, string ufCode);
    Task<bool> UpdateState(State state);
}
