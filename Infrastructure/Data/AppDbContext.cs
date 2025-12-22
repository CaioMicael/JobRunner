using Microsoft.EntityFrameworkCore;

namespace JobRunner.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ExternalApis.RandomUserGenerator.Domain.Entities.User> User { get; set; }
        public DbSet<ExternalApis.RandomUserGenerator.Domain.Entities.UserLocation> UserLocation { get; set; }
    }
}
