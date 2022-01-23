using System.ComponentModel;

namespace EPaczuchaWeb.Models
{
    public class PackageViewModel
    {
        public int Id { get; set; }
        [DisplayName("Nazwa")]
        public string SimpleName { get; set; }
        [DisplayName("Data nadania")]
        public string StartDate { get; set; }
        [DisplayName("Przewidywana data dostarczenia")]
        public string EndDate { get; set; }
        public CustomerViewModel Customer { get; set; }
        public PackagePriceViewModel PackagePrice { get; set; }
        public PackageTypeViewModel PackageType { get; set; }
        public SendMethodViewModel SendMethod { get; set; }
    }
}