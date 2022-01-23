namespace EPaczucha.database
{
    public interface ICrudRepository<Entity> where Entity : BaseEntity
    {
        int Create(Entity entity);     // C
        Entity GetById(int id);         // R
        bool Delete(Entity entity);     // U 
        void Update(Entity entity);     // D
    }
}