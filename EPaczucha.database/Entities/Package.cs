using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPaczucha.database
{
    public class Package : BaseEntity
    {
        public string SimpleName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [ForeignKey("Customer")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        [ForeignKey("PackagePrice")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PackagePriceID { get; set; }
        public virtual PackagePrice PackagePrice { get; set; }
        [ForeignKey("PackageType")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PackageTypeID { get; set; }
        public virtual PackageType PackageType { get; set; }
        [ForeignKey("SendMethod")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SendMethodID { get; set; }
        public virtual SendMethod SendMethod { get; set; }
        [ForeignKey("Destination")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DestinationId { get; set; }
        public virtual Destination Destination { get; set; }
    }
}