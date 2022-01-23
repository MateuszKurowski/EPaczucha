using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;

namespace EPaczucha.database
{
    public class SendMethodRepository : BaseRepository<SendMethod>, ISendMethodRepository
    {
        public SendMethodRepository(EPaczuchaDbContext dbContext) : base(dbContext) { }
        protected override DbSet<SendMethod> DbSet => _dbContext.SendMethods;

        public IEnumerable<SendMethod> GetSendMethod() => DbSet.Select(x => x);

        public void Update(SendMethod sendMethod)
        {
            var foundSendMethod = DbSet.Where(x => x.Id == sendMethod.Id).FirstOrDefault();
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