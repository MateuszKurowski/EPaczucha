using System.Linq;

using Microsoft.EntityFrameworkCore;

namespace EPaczucha.database
{
    public class UserRepository : BaseRepository<User>, IUserRepository, ICrudRepository<User>
    {
        public UserRepository(EPaczuchaDbContext dbContext) : base(dbContext) { }
        protected override DbSet<User> DbSet => _dbContext.Users;

        public void Update(User user)
        {
            var foundUser = DbSet.Where(x => x.Id == user.Id).FirstOrDefault();
            if (foundUser == null)
            {
                Create(user);
            }
            else
            {
                foundUser.Street = user.Street;
                foundUser.City = user.City;
                foundUser.Email = user.Email;
                foundUser.ApartmentNumber = user.ApartmentNumber;
                foundUser.LastName = user.LastName;
                foundUser.FirstName = user.FirstName;
                foundUser.ZipCode = user.ZipCode;
                foundUser.PhoneNumber = user.PhoneNumber;
                foundUser.UserName = user.UserName;
                foundUser.BuildingNumber = user.BuildingNumber;
            }
        }
        public void Delete(User user) => DbSet.Remove(DbSet.Where(x => x.Id == user.Id).FirstOrDefault());
        public void Create(User user) => DbSet.Add(user);
        public User GetById(string id) => DbSet.FirstOrDefault(x => x.Id == id);
    }
}