using IbgeBlazor.Core.LocalityContext.Entities;

namespace IbgeBlazor.Core.LocalityContext.Repositories;

public interface ILocalitiesRepository
{
    Task<Locality> Create(Locality locality);
    Task<bool> IsExistsStateWithId(int stateId);
    Task<bool> IbgeCodIsExists(string ibgeCode);
}
