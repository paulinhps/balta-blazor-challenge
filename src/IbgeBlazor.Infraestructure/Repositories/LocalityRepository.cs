using IbgeBlazor.Core.LocalityContext.Entities;
using IbgeBlazor.Core.LocalityContext.Repositories;

public class LocalityRepository : ILocalityRepository
{
    public Task<Locality> Create(Locality locality)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IbgeCodIsExists(string ibgeCode)
    {
        throw new NotImplementedException();
    }

    public Task<bool> StateIsExists(int stateId)
    {
        throw new NotImplementedException();
    }
}