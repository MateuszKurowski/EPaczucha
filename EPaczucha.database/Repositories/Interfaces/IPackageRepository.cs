using System.Collections.Generic;

namespace EPaczucha.database
{
    public interface IPackageRepository
    {
        List<Package> GetAll();
        void SaveChanges();
    }
}