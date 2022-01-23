using System.Collections.Generic;

namespace EPaczucha.database
{
    public interface IDestinationRepository : ICrudRepository<Destination>, IRepostiory<Destination>
    {
        public IEnumerable<Destination> GetCustomers();
    }
}