using System.Linq;

using Microsoft.EntityFrameworkCore;

namespace EPaczucha.database
{
    public class SendMethodRepository : BaseRepository<SendMethod>, ICrudRepository<SendMethod>, ISendMethodRepository
    {
        public SendMethodRepository(EPaczuchaDbContext dbContext) : base(dbContext) { }
        protected override DbSet<SendMethod> DbSet => _dbContext.SendMethods;

        public void Create(SendMethod sendMethod) => DbSet.Add(sendMethod);
        public void Delete(SendMethod sendMethod) => DbSet.Remove(DbSet.Where(x => x.SendMethodId == sendMethod.SendMethodId).FirstOrDefault());
        public SendMethod GetById(string id) => DbSet.FirstOrDefault(x => x.SendMethodId.ToString() == id);
        public void Update(SendMethod sendMethod)
        {
            var foundSendMethod = DbSet.Where(x => x.SendMethodId == sendMethod.SendMethodId).FirstOrDefault();
            if (foundSendMethod == null)
            {
                Create(sendMethod);
            }
            else
            {
                foundSendMethod.Price = sendMethod.Price;
                foundSendMethod.MethodName = sendMethod.MethodName;
            }
        }
    }
}