//using System.Collections.Generic;
//using System.Linq;

//using Microsoft.EntityFrameworkCore;

//namespace EPaczucha.database
//{
//    public class PackageTypeRepository : BaseRepository<PackageType>, IPackageTypeRepository
//    {
//        public PackageTypeRepository(EPaczuchaDbContext dbContext) : base(dbContext) { }
//        protected override DbSet<PackageType> DbSet => _dbContext.PackagesTypes;

//        public IEnumerable<PackageType> GetPackageType() => DbSet.Select(x => x);
//        public void Update(PackageType packageType)
//        {
//            var foundPackageType = DbSet.Where(x => x.Id == packageType.Id).FirstOrDefault();
//            if (foundPackageType == null)
//            {
//                Create(packageType);
//            }
//            else
//            {
//                foundPackageType.TypeName = packageType.TypeName;
//                foundPackageType.Height = packageType.Height;
//                foundPackageType.Price = packageType.Price;
//                foundPackageType.Width = packageType.Width;
//                SaveChanges();
//            }
//        }
//    }
//}