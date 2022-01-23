using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;

namespace EPaczucha.database
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(EPaczuchaDbContext dbContext) : base(dbContext) { }
        protected override DbSet<Customer> DbSet => _dbContext.Customers;

        public IEnumerable<Customer> GetCustomers() => DbSet/*
            .Include(x => x.Packages).ThenInclude(x => x.SendMethod)
            .Include(x => x.Packages).ThenInclude(x => x.PackageType)
            .Include(x => x.Packages).ThenInclude(x => x.PackagePrice)
            */.Select(x => x);

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
            }
        }
    }
}