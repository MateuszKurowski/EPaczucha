using System.Linq;

using Microsoft.EntityFrameworkCore;

namespace EPaczucha.database
{
    public class PackageTypeRepository : BaseRepository<PackageType>, ICrudRepository<PackageType>, IPackageTypeRepository
    {
        public PackageTypeRepository(EPaczuchaDbContext dbContext) : base(dbContext) { }
        protected override DbSet<PackageType> DbSet => _dbContext.PackagesTypes;

        public void Create(PackageType packageType) => DbSet.Add(packageType);
        public void Delete(PackageType packageType) => DbSet.Remove(DbSet.Where(x => x.PackageTypeId == packageType.PackageTypeId).FirstOrDefault());
        public PackageType GetById(string id) => DbSet.FirstOrDefault(x => x.PackageTypeId.ToString() == id);
        public void Update(PackageType packageType)
        {
            var foundPackageType = DbSet.Where(x => x.PackageTypeId == packageType.PackageTypeId).FirstOrDefault();
            if (foundPackageType == null)
            {
                Create(packageType);
            }
            else
            {
                foundPackageType.TypeName = packageType.TypeName;
                foundPackageType.Height = packageType.Height;
                foundPackageType.Price = packageType.Price;
                foundPackageType.Width = packageType.Width;
            }
        }
    }
}