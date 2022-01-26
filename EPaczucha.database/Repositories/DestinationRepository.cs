using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;

namespace EPaczucha.database
{
    public class DestinationRepository
        : BaseRepository<Destination>, IDestinationRepository
    {
        public DestinationRepository(EPaczuchaDbContext dbContext) : base(dbContext) { }
        protected override DbSet<Destination> DbSet => _dbContext.Destinations;

        public IEnumerable<Destination> GetDestinations() => DbSet.Select(x => x).ToList();

        public void Update(Destination destination)
        {
            var foundDestination = DbSet.Where(x => x.Id == destination.Id).FirstOrDefault();
            if (foundDestination == null)
            {
                Create(destination);
            }
            else
            {
                foundDestination.Street = destination.Street;
                foundDestination.City = destination.City;
                foundDestination.ApartmentNumber = destination.ApartmentNumber;
                foundDestination.ZipCode = destination.ZipCode;
                foundDestination.BuildingNumber = destination.BuildingNumber;
                SaveChanges();
            }
        }
    }
}