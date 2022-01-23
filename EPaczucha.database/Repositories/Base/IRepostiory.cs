using System.Collections.Generic;

namespace EPaczucha.database
{
    public interface IRepostiory<Entity> where Entity : BaseEntity
    {
        List<Entity> GetAll();
        bool SaveChanges();
    }
}