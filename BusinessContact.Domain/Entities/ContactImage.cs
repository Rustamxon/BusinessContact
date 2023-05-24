using BusinessContact.Domain.Commons;

namespace BusinessContact.Domain.Entities
{
    public class ContactImage : Auditable
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public long ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
