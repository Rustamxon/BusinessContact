using BusinessContact.Domain.Commons;

namespace BusinessContact.Domain.Entities
{
    public class Users : Auditable
    {
        public List<Contacts>? Contactlar { get; set; }
        public string Password { get; set; }
    }
}
