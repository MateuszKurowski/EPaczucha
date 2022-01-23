using System.ComponentModel;

namespace EPaczuchaWeb.Models
{
    public class DestinationViewModel
    {
        [DisplayName("Miasto")]
        public string City { get; set; }
        [DisplayName("Ulica")]
        public string Street { get; set; }
        [DisplayName("Numer budynku")]
        public string BuildingNumber { get; set; }
        [DisplayName("Numer mieszkania")]
        public string ApartmentNumber { get; set; }
        [DisplayName("Kod miasta")]
        public string ZipCode { get; set; }
    }
}