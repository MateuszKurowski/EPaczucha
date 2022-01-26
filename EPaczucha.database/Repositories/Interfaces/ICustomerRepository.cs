using System.Collections.Generic;

namespace EPaczucha.database
{
    public interface ICustomerRepository : ICrudRepository<Customer>, IRepostiory<Customer>
    {
        IEnumerable<Customer> GetCustomers();
        int? GetCustomerIdByGuid(string guid);
    }
}