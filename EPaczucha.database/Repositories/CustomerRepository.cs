using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EPaczucha.database
{
    public class UserRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public UserRepository(EPaczuchaDbContext dbContext) : base(dbContext) { }
        protected override DbSet<Customer> DbSet => _dbContext.Customers;

        public IEnumerable<Customer> GetCustomers() => DbSet.Select(x => x).ToList();

        public void Update(Customer customer)
        {
            var foundUser = DbSet.Where(x => x.Id == customer.Id).FirstOrDefault();
            if (foundUser == null)
            {
                Create(customer);
            }
            else
            {
                foundUser.Street = customer.Street;
                foundUser.City = customer.City;
                foundUser.Email = customer.Email;
                foundUser.ApartmentNumber = customer.ApartmentNumber;
                foundUser.LastName = customer.LastName;
                foundUser.FirstName = customer.FirstName;
                foundUser.ZipCode = customer.ZipCode;
                foundUser.PhoneNumber = customer.PhoneNumber;
                foundUser.BuildingNumber = customer.BuildingNumber;
                SaveChanges();
            }
        }

        public int? GetCustomerIdByGuid(string guid) => DbSet.Where(x => x.Guid == guid)?.FirstOrDefault()?.Id;
    }
}