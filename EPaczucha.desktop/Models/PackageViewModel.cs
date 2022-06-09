using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPaczucha.desktop.Models
{
    public class PackageViewModel
    {
        public int Id { get; set; }
        public string SimpleName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public decimal PackagePrice { get; set; }

        public string DestinationCity { get; set; }
        public string DestinationStreet { get; set; }
        public string DestinationBuildingNumber { get; set; }
        public string DestinationApartmentNumber { get; set; }
        public string DestinationZipCode { get; set; }
    }
}