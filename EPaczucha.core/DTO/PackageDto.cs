using System;

namespace EPaczucha.core
{
    public class PackageDto
    {
        public int Id { get; set; }
        public string SimpleName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CustomerId { get; set; }
        public virtual CustomerDto Customer { get; set; }
        public virtual PackagePriceDto PackagePrice { get; set; }
        public virtual PackageTypeDto PackageType { get; set; }
        public virtual SendMethodDto SendMethod { get; set; }
        public virtual DestinationDto Destination { get; set; }
    }
}