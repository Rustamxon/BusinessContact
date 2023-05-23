using BusinessContact.Domain.Commons;

namespace BusinessContact.Domain.Entities
{
    public class ContactTable : Auditable
    {
        public long UserId { get; set; }
        public User User { get; set; }


        public long ContactId { get; set; }
        public User contact { get; set; }
    }
}
