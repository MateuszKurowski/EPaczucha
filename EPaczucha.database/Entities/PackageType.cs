using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EPaczucha.database
{
    public class PackageType : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        new public int Id { get; set; }
        public string TypeName { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public decimal Price { get; set; }
    }
}