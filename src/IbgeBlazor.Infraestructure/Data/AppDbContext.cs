using Microsoft.EntityFrameworkCore;

namespace IbgeBlazor.Infraestructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}