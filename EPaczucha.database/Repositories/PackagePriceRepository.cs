using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;

namespace EPaczucha.database
{
    public class PackagePriceRepository : BaseRepository<PackagePrice>, IPackagePriceRepository
    {
        public PackagePriceRepository(EPaczuchaDbContext dbContext) : base(dbContext) { }
        protected override DbSet<PackagePrice> DbSet => _dbContext.PackagePrices;

        public IEnumerable<PackagePrice> GetPackagePrice() => DbSet.Select(x => x);

        public void Update(PackagePrice packagePrice)
        {
            var foundPackagePrice = DbSet.Where(x => x.Id == packagePrice.Id).FirstOrDefault();
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