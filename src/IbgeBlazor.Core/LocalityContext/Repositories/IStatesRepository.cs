using IbgeBlazor.Core.LocalityContext.Entities;
using IbgeBlazor.Core.LocalityContext.ValueObjects;

namespace IbgeBlazor.Core.LocalityContext.Repositories;

public interface IStatesRepository
{
    Task<State?> GetStateById(int id);
    Task<bool> IsExistsStateWithIdOrUf(int stateId, StateCode ufCode);
    Task<bool> IsExistsStateLinkedCity(int id);
    Task<bool> IsExistsStateById(int id);
    Task<State> CreateState(State state);
    Task<bool> UpdateState(State state);
    Task<bool> RemoveState(State state);
    Task<IEnumerable<State>> ListStates(PaginationQuery pagination);
    
}
