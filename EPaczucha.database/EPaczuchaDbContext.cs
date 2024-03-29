﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EPaczucha.database
{
    public class EPaczuchaDbContext : IdentityDbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<PackagePrice> PackagePrices { get; set; }
        public DbSet<PackageType> PackagesTypes { get; set; }
        public DbSet<SendMethod> SendMethods { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Package> Packages { get; set; }

        public EPaczuchaDbContext(DbContextOptions options) : base(options) { }
    }
}