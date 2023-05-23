using BusinessContact.Domain.Commons;

namespace BusinessContact.Domain.Entities
{
    public class Contact : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
