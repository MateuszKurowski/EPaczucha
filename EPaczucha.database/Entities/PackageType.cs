namespace EPaczucha.database
{
    public class PackageType : BaseEntity
    {
        public string TypeName { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public decimal Price { get; set; }
    }
}