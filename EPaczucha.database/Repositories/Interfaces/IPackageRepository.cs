using System.Collections.Generic;

namespace EPaczucha.database
{
    public interface IPackageRepository : ICrudRepository<Package>, IRepostiory<Package>
    {
        public IEnumerable<Package> GetPackage();
    }
}