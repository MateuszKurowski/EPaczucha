namespace EPaczucha.core
{
    public class PackageDto
    {
        public int Id { get; set; }
        public string SimpleName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int UserId { get; set; }
        public virtual CustomerDto Customer { get; set; }
        public virtual PackagePriceDto PackagePrice { get; set; }
        public virtual PackageTypeDto PackageType { get; set; }
        public virtual SendMethodDto SendMethod { get; set; }
    }
}