using Microsoft.EntityFrameworkCore;

namespace EPaczucha.database
{
    public class EPaczuchaDbContext : DbContext
    {
        //public DbSet<User> Users { get; set; }

        public EPaczuchaDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
