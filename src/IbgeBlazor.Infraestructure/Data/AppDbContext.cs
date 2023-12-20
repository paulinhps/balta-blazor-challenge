using IbgeBlazor.Application.Data;
using IbgeBlazor.Core.LocalityContext.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace IbgeBlazor.Infraestructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<ApplicationUser>(options), IApplicationDbContext
    {
        
        public DbSet<State> States => Set<State>();
        public DbSet<City> Cities => Set<City>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

    }

}