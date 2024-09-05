namespace AgriTourismArchi.DTO
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserAddress { get; set; }
        public int CategoryId { get; set; }
        public string PlaceName { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public double Cost { get; set; }
    }
}
