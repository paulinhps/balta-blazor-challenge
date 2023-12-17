using IbgeBlazor.Core.LocalityContext.Entities;
using Microsoft.EntityFrameworkCore;

namespace IbgeBlazor.Infraestructure.Data
{
    public interface IApplicationDbContext
    {
        //DbSet<Locality> Localities { get; }

        DbSet<State> States { get; }
        DbSet<City> Cities { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }

}