using System.Linq;

using Microsoft.EntityFrameworkCore;

namespace EPaczucha.database
{
    public class PackagePriceRepository : BaseRepository<PackagePrice>, IPackagePriceRepository, ICrudRepository<PackagePrice>
    {
        public PackagePriceRepository(EPaczuchaDbContext dbContext) : base(dbContext) { }
        protected override DbSet<PackagePrice> DbSet => _dbContext.PackagePrices;

        public void Create(PackagePrice packagePrice) => DbSet.Add(packagePrice);
        public void Delete(PackagePrice packagePrice) => DbSet.Remove(DbSet.Where(x => x.PackagePriceID == packagePrice.PackagePriceID).FirstOrDefault());
        public PackagePrice GetById(string id) => DbSet.FirstOrDefault(x => x.PackagePriceID.ToString() == id);
        public void Update(PackagePrice packagePrice)
        {
            var foundPackagePrice = DbSet.Where(x => x.PackagePriceID == packagePrice.PackagePriceID).FirstOrDefault();
            if (foundPackagePrice == null)
            {
                Create(packagePrice);
            }
            else
            {
                foundPackagePrice.Net = packagePrice.Net;
                foundPackagePrice.Gross = packagePrice.Gross;
            }
        }
    }
}