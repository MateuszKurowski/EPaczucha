using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EPaczuchaWeb.Models
{
    public class PackageViewModel
    {
        public int Id { get; set; }
        [DisplayName("Nazwa")]
        [MaxLength(30, ErrorMessage = "Proszę podać krótsza nazwę paczki!")]
        public string SimpleName { get; set; }
        [DisplayName("Data nadania")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DisplayName("Przewidywana data dostarczenia")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public CustomerViewModel Customer { get; set; }
        public PackagePriceViewModel PackagePrice { get; set; }
        public PackageTypeViewModel PackageType { get; set; }
        public SendMethodViewModel SendMethod { get; set; }
    }
}