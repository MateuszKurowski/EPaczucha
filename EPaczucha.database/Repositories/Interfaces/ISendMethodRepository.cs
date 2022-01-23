using System.Collections.Generic;

namespace EPaczucha.database
{
    public interface ISendMethodRepository : ICrudRepository<SendMethod>, IRepostiory<SendMethod>
    {
        public IEnumerable<SendMethod> GetSendMethod();
    }
}