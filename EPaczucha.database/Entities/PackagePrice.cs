namespace EPaczucha.database
{
    public class PackagePrice : BaseEntity
    {
        public decimal Net { get; set; }
        public decimal VAT { get; set; }
        public decimal Gross { get; set; }
    }
}