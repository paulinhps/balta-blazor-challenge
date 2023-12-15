
using IbgeBlazor.Core.LocalityContext.Entities;

namespace IbgeBlazor.Core.LocalityContext.Repositories;

public interface IStatesRepository
{
    Task<State> CreateState(State state);
    Task<bool> IsExistsStateWithIdOrUf(int stateId, string ufCode);
}
