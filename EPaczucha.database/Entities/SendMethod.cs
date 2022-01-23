using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPaczucha.database
{
    public class SendMethod : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        new public int Id { get; set; }
        public string MethodName { get; set; }
        public decimal Price { get; set; }
    }
}