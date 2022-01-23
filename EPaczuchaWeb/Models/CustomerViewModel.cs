using System.Collections.Generic;
using System.ComponentModel;

namespace EPaczuchaWeb.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        [DisplayName("Imię")]
        public string FirstName { get; set; }
        [DisplayName("Nazwisko")]
        public string LastName { get; set; }
        [DisplayName("Miasto")]
        public string City { get; set; }
        [DisplayName("Ulica")]
        public string Street { get; set; }
        [DisplayName("Numer budynku")]
        public string BuildingNumber { get; set; }
        [DisplayName("Numer mieszkania")]
        public string ApartmentNumber { get; set; }
        [DisplayName("Kod pocztowy")]
        public string ZipCode { get; set; }
        [DisplayName("Adres email")]
        public string Email { get; set; }
        [DisplayName("Numer telefonu")]
        public string PhoneNumber { get; set; }
        public List<PackageViewModel> Packages { get; set; }
    }
}