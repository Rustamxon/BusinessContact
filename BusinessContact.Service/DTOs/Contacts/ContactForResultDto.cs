using System.ComponentModel.DataAnnotations;

namespace BusinessContact.Service.DTOs.Contacts
{
    public class ContactForResultDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }
}
