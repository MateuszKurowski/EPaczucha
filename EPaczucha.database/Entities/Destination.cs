namespace EPaczucha.database
{
    public class Destination : BaseEntity
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string ApartmentNumber{ get; set; }
        public string ZipCode { get; set; }
    }
}