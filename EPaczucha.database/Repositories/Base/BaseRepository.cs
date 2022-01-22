using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace EPaczucha.database
{
    public abstract class BaseRepository<Entity> where Entity : class
    {
        protected EPaczuchaDbContext _dbContext;

        protected abstract DbSet<Entity> DbSet { get; }

        protected BaseRepository(EPaczuchaDbContext dbContext) => _dbContext = dbContext;

        public List<Entity> GetAll()
        {
            var list = new List<Entity>();

            var entities = DbSet;

            foreach (var entity in entities)
                list.Add(entity);

            return list;
        }

        public void SaveChanges() => _dbContext.SaveChanges();
    }
}