using BusinessContact.Domain.Commons;
using BusinessContact.Domain.Enums;

namespace BusinessContact.Domain.Entities
{
    public class User : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime GetDate { get; set; }
        public UserRole Role { get; set; }
    }
}
