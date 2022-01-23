using System.Collections.Generic;

namespace EPaczucha.database
{
    public interface ICustomerRepository : ICrudRepository<Customer>, IRepostiory<Customer>
    {
        public IEnumerable<Customer> GetCustomers();
    }
}