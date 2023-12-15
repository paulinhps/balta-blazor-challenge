using IbgeBlazor.Core.LocalityContext.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace IbgeBlazor.Infraestructure.Data
{
    public class AppDbContext : DbContext, IApplicationDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        //public DbSet<Locality> Localities => Set<Locality>();

        public DbSet<State> States => Set<State>();
        public DbSet<City> Cities => Set<City>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

    }

}