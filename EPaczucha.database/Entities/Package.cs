using System.ComponentModel.DataAnnotations.Schema;


namespace EPaczucha.database
{
    public class Package : BaseEntity
    {
        public string SimpleName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        [ForeignKey("Customer")]
        public int UserId { get; set; }
        public virtual Customer Customer { get; set; }
        [ForeignKey("PackagePrice")]
        public int PackagePriceID { get; set; }
        public virtual PackagePrice PackagePrice { get; set; }
        [ForeignKey("PackageType")]
        public int PackageTypeID { get; set; }
        public virtual PackageType PackageType { get; set; }
        [ForeignKey("SendMethod")]
        public int SendMethodID { get; set; }
        public virtual SendMethod SendMethod { get; set; }
    }
}