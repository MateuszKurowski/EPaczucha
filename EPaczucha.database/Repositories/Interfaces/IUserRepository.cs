using System.Collections.Generic;

namespace EPaczucha.database
{
    public interface IUserRepository
    {
        List<User> GetAll();
        void SaveChanges();
    }
}