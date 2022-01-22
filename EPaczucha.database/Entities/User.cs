
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;

namespace EPaczucha.database
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string ApartmentNumber{ get; set; }
        public string ZipCode { get; set; }

        [NotMapped]
        public virtual List<Package> Packages { get; set; }
    }
}