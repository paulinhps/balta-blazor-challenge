using IbgeBlazor.Core.LocalityContext.Entities;
using IbgeBlazor.Core.LocalityContext.Repositories;
using Microsoft.Extensions.Logging;

namespace IbgeBlazor.Infraestructure.Data.Repositories;

public class LocalityRepository : ILocalityRepository
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<LocalityRepository> _logger;

    public LocalityRepository(IApplicationDbContext context, ILogger<LocalityRepository> logger)
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

    public Task<bool> StateIsExists(int stateId)
    {
        throw new NotImplementedException();
    }
}