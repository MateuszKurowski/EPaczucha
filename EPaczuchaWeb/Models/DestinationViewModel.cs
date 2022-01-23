using System.ComponentModel;

namespace EPaczuchaWeb.Models
{
    public class DestinationViewModel
    {
        [DisplayName("Miasto")]
        public string DestinationCity { get; set; }
        [DisplayName("Ulica")]
        public string DestinationStreet { get; set; }
        [DisplayName("Numer budynku")]
        public string DestinationBuildingNumber { get; set; }
        [DisplayName("Numer mieszkania")]
        public string DestinationApartmentNumber { get; set; }
        [DisplayName("Kod miasta")]
        public string DestinationZipCode { get; set; }
    }
}