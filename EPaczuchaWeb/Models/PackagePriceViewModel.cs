using System.ComponentModel;

namespace EPaczuchaWeb.Models
{
    public class PackagePriceViewModel

    {
        public int Id { get; set; }
        [DisplayName("Netto")]
        public decimal Net { get; set; }
        [DisplayName("Podatek VAT")]
        public decimal VAT { get; set; }
        [DisplayName("Brutto")]
        public decimal Gross { get; set; }
    }
}