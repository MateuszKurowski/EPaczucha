using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EPaczucha.database
{
    public class EPaczuchaDbContext : IdentityDbContext
    {
        //public DbSet<User> Users { get; set; }

        public EPaczuchaDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
