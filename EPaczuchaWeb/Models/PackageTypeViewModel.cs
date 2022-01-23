using System.ComponentModel;

namespace EPaczuchaWeb.Models
{
    public class PackageTypeViewModel
    {
        public int Id { get; set; }
        [DisplayName("Typ")]
        public string TypeName { get; set; }
        [DisplayName("Szerokość")]
        public string Width { get; set; }
        [DisplayName("Wysokość")]
        public string Height { get; set; }
        [DisplayName("Cena za typ")]
        public decimal Price { get; set; }
    }
}