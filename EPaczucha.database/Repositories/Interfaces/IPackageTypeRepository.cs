using System.Collections.Generic;

namespace EPaczucha.database
{
    public interface IPackageTypeRepository
    {
        List<PackageType> GetAll();
        void SaveChanges();
    }
}