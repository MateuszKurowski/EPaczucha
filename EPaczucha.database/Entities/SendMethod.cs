namespace EPaczucha.database
{
    public class SendMethod : BaseEntity
    {
        public string MethodName { get; set; }
        public decimal Price { get; set; }
    }
}