using BusinessContact.Domain.Commons;

namespace BusinessContact.Domain.Entities
{
    public class User : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public long YearOfBirth { get; set; }
    }
}
