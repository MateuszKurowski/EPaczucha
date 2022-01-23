namespace EPaczuchaWeb.Models
{
    public class PackageViewModel
    {
        public int Id { get; set; }
        public string SimpleName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public CustomerViewModel Customer { get; set; }
        public PackagePriceViewModel PackagePrice { get; set; }
        public PackageTypeViewModel PackageType { get; set; }
        public SendMethodViewModel SendMethod { get; set; }
    }
}