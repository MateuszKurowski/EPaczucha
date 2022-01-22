namespace EPaczucha.database
{
    public interface ICrudRepository<Entity> where Entity : class
    {
        void Create(Entity entity);     // C
        Entity GetById(string id);      // R
        void Delete(Entity entity);     // U 
        void Update(Entity entity);     // D
    }
}