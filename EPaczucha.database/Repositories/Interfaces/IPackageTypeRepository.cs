using System.Collections.Generic;

namespace EPaczucha.database
{
    public interface IPackageTypeRepository : ICrudRepository<PackageType>, IRepostiory<PackageType>
    {
        public IEnumerable<PackageType> GetPackageType();
    }
}