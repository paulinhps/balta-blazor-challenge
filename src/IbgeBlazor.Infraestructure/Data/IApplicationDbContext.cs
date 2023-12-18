using IbgeBlazor.Core.LocalityContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace IbgeBlazor.Infraestructure.Data
{
    public interface IApplicationDbContext
    {
        DbSet<State> States { get; }
        DbSet<City> Cities { get; }
        public DatabaseFacade Database {get;}


        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }

}