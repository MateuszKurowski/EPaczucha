using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;

namespace EPaczucha.database
{
    public abstract class BaseRepository<Entity> : IRepostiory<Entity> where Entity : BaseEntity
    {
        protected EPaczuchaDbContext _dbContext;

        protected abstract DbSet<Entity> DbSet { get; }

        protected BaseRepository(EPaczuchaDbContext dbContext) => _dbContext = dbContext;

        public bool Delete(Entity entity)
        {
            DbSet.Remove(DbSet.Where(x => x.Id == entity.Id)?.FirstOrDefault());
            return SaveChanges();
        }

        public bool Create(Entity entity)
        {
            DbSet.ToList().Add(entity);
            return SaveChanges();
        }
        public Entity GetById(int id) => DbSet.FirstOrDefault(x => x.Id == id);

        public List<Entity> GetAll()
        {
            var list = new List<Entity>();

            var entities = DbSet;

            foreach (var entity in entities)
                list.Add(entity);

            return list;
        }

        public bool SaveChanges() => _dbContext.SaveChanges() > 0;
    }
}