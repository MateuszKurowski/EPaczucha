using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EPaczucha.database
{
    public class EPaczuchaDbContext : IdentityDbContext
    {
        public DbSet<Test> Tests { get; set; }
        public DbSet<PackagePrice> PackagePrices { get; set; }
        public DbSet<Pies> Piess { get; set; }
        public EPaczuchaDbContext(DbContextOptions options) : base(options) { }
    }
}