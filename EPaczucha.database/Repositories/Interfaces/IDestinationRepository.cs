using System.Collections.Generic;

namespace EPaczucha.database
{
    public interface IDestinationRepository : ICrudRepository<Test>, IRepostiory<Test>
    {
        public IEnumerable<Test> GetCustomers();
    }
}