using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc;

namespace EPaczuchaWeb.Models
{
    public class CustomerViewModel
    {
        [HiddenInput]
        public int Id { get; set; }
        [DisplayName("Imię")]
        [Required]
        [StringLength(20, ErrorMessage = "Proszę podać poprawne imię!")]
        public string FirstName { get; set; }
        [HiddenInput]
        public string Guid { get; set; }
        [HiddenInput]
        public string Login { get; set; }
        [DisplayName("Nazwisko")]
        [Required]
        [StringLength(30, ErrorMessage = "Proszę podać poprawne nazwisko!")]
        public string LastName { get; set; }
        [DisplayName("Miasto")]
        [Required]
        [MinLength(length: 2, ErrorMessage = "Proszę podać poprawną nazwę miasta!")]
        public string City { get; set; }
        [DisplayName("Ulica")]
        [Required]
        [MaxLength(length: 50, ErrorMessage = "Proszę podać poprawną nazwę ulicy!")]
        public string Street { get; set; }
        [DisplayName("Numer budynku")]
        [Required]
        [Range(1, 3000, ErrorMessage = "Proszę podać poprawny numer budynku!")]
        public string BuildingNumber { get; set; }
        [DisplayName("Numer mieszkania")]
        [Range(1, 300, ErrorMessage = "Proszę podać poprawny numer mieszkania!")]
        public string ApartmentNumber { get; set; }
        [DisplayName("Kod pocztowy")]
        [Required]
        [RegularExpression("[0-9]{2}-[0-9]{3}", ErrorMessage = "Proszę podać poprawny kod pocztowy!")]
        public string ZipCode { get; set; }
        [DisplayName("Adres email")]
        public string Email { get; set; }
        [DisplayName("Numer telefonu")]
        [Required]
        [Phone(ErrorMessage = "Proszę podać poprawny numer telefonu!")]
        public string PhoneNumber { get; set; }
        public List<PackageViewModel> Packages { get; set; }
    }
}