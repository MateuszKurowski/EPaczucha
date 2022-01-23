namespace EPaczuchaWeb.Models
{
    public class PackageViewModel
    {
        public int PackageID { get; set; }
        public string SimpleName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public CustomerViewModel Customer { get; set; }
        public PackagePriceViewMode PackagePrice { get; set; }
        public PackageTypeViewModel PackageType { get; set; }
        public SendMethodViewModel SendMethod { get; set; }
    }
}