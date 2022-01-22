using System.ComponentModel.DataAnnotations.Schema;


namespace EPaczucha.database
{
    public class Package
    {
        public int PackageID { get; set; }
        public string SimpleName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }
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