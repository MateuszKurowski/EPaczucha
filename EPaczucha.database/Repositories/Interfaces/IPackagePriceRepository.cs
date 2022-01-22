using System.Collections.Generic;

namespace EPaczucha.database
{
    public interface IPackagePriceRepository
    {
        List<PackagePrice> GetAll();
        void SaveChanges();
    }
}