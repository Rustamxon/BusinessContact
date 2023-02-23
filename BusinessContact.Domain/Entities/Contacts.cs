using BusinessContact.Domain.Commons;
namespace BusinessContact.Domain.Entities
{
    public class Contacts : Auditable
    {
        public string? Email { get; set; }
        public string? Job { get; set; }
        public string? Address { get; set; }
    }
}
