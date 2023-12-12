using IbgeBlazor.Core.LocalityContext.Entities;

namespace IbgeBlazor.Core.LocalityContext.Repositories;

public interface ILocalityRepository
{
    Task<Locality> Create(Locality locality);
    Task<bool> StateIsExists(int stateId);
    Task<bool> IbgeCodIsExists(string ibgeCode);
}
