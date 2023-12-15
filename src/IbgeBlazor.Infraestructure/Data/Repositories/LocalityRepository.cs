using IbgeBlazor.Core.LocalityContext.Entities;
using IbgeBlazor.Core.LocalityContext.Repositories;
using Microsoft.Extensions.Logging;

namespace IbgeBlazor.Infraestructure.Data.Repositories;

public class LocalitiesRepository : ILocalitiesRepository
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<LocalitiesRepository> _logger;

    public LocalitiesRepository(IApplicationDbContext context, ILogger<LocalitiesRepository> logger)
    {
        _context = context;
        _logger = logger;
    }
    public Task<Locality> Create(Locality locality)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IbgeCodIsExists(string ibgeCode)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsExistsStateWithId(int stateId)
    {
        throw new NotImplementedException();
    }
}
