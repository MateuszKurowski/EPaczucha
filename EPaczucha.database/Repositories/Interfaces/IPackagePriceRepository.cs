using System.Collections.Generic;

namespace EPaczucha.database
{
    public interface IPackagePriceRepository : ICrudRepository<PackagePrice>, IRepostiory<PackagePrice>
    {
        public IEnumerable<PackagePrice> GetPackagePrice();
    }
}