namespace TelecomManagement.API.Models
{
    public class ContactNumber
    {
        public int Id { get; set; }
        public long PhoneNumber { get; set; }
        public bool Active { get; set; }
        public int CustomerId { get; set; }
    }
}