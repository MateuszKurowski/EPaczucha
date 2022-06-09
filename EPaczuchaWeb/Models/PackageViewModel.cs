using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using EPaczuchaWeb.Validator;

namespace EPaczuchaWeb.Models
{
    public class PackageViewModel
    {
        public int Id { get; set; }
        [DisplayName("Nazwa")]
        [MaxLength(30, ErrorMessage = "Proszę podać krótsza nazwę paczki!")]
        public string SimpleName { get; set; }
        [DisplayName("Data nadania")]
        //[CustomValidation(typeof(DateTimeBeforeTodayValidator), "ValidateEndTimeRange")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DisplayName("Przewidywana data dostarczenia")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }
        public CustomerViewModel Customer { get; set; }
        public PackagePriceViewModel PackagePrice { get; set; }
        public PackageTypeViewModel PackageType { get; set; }
        public SendMethodViewModel SendMethod { get; set; }

        [DisplayName("Miasto")]
        [Required]
        [MinLength(length: 2, ErrorMessage = "Proszę podać poprawną nazwę miasta!")]
        public string DestinationCity { get; set; }
        [DisplayName("Ulica")]
        [Required]
        [MaxLength(length: 50, ErrorMessage = "Proszę podać poprawną nazwę ulicy!")]
        public string DestinationStreet { get; set; }
        [DisplayName("Numer budynku")]
        [Required]
        [Range(1, 3000, ErrorMessage = "Proszę podać poprawny numer budynku!")]
        public string DestinationBuildingNumber { get; set; }
        [DisplayName("Numer mieszkania")]
        [Range(1, 300, ErrorMessage = "Proszę podać poprawny numer mieszkania!")]
        public string DestinationApartmentNumber { get; set; }
        [DisplayName("Kod pocztowy")]
        [Required]
        [RegularExpression("[0-9]{2}-[0-9]{3}", ErrorMessage = "Proszę podać poprawny kod pocztowy!")]
        public string DestinationZipCode { get; set; }
    }
}