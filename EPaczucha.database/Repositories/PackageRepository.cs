using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;

namespace EPaczucha.database
{
    public class PackageRepository : BaseRepository<Package>, IPackageRepository
    {
        public PackageRepository(EPaczuchaDbContext dbContext) : base(dbContext) { }
        protected override DbSet<Package> DbSet => _dbContext.Packages;

        public IEnumerable<Package> GetPackage() => DbSet./*Include(x => x.SendMethod).Include(x => x.PackageType).Include(x => x.PackagePrice).*/Select(x => x);
        public void Update(Package package)
        {
            var foundPackage = DbSet.Where(x => x.Id == package.Id).FirstOrDefault();
            if (foundPackage == null)
            {
                Create(package);
            }
            else
            {
                foundPackage.SimpleName = package.SimpleName;
                foundPackage.StartDate = package.StartDate;
            }
        }
    }
}