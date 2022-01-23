using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EPaczucha.database
{
    public class EPaczuchaDbContext : IdentityDbContext
    {
        public EPaczuchaDbContext(DbContextOptions options) : base(options) { }
    }
}