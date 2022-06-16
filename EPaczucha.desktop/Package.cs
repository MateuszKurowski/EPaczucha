using System;
using System.Collections.Generic;

#nullable disable

namespace EPaczucha.desktop
{
    public partial class Package
    {
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public int? Type { get; set; }
        public int? Method { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string ZipCode { get; set; }
        public int? FlatNumber { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Price { get; set; }
    }
}
