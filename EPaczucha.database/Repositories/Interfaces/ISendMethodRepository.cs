using System.Collections.Generic;

namespace EPaczucha.database
{
    public interface ISendMethodRepository
    {
        List<SendMethod> GetAll();
        void SaveChanges();
    }
}