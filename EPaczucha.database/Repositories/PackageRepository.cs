using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;

namespace EPaczucha.database
{
    public class PackageRepository : BaseRepository<Package>, ICrudRepository<Package>, IPackageRepository
    {
        public PackageRepository(EPaczuchaDbContext dbContext) : base(dbContext) { }
        protected override DbSet<Package> DbSet => _dbContext.Packages;

        public void Create(Package package) => DbSet.Add(package);
        public void Delete(Package package) => DbSet.Remove(DbSet.Where(x => x.PackageID == package.PackageID).FirstOrDefault());
        public Package GetById(string id) => DbSet.FirstOrDefault(x => x.PackageID.ToString() == id);
        public void Update(Package package)
        {
            var foundPackage = DbSet.Where(x => x.PackageID == package.PackageID).FirstOrDefault();
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