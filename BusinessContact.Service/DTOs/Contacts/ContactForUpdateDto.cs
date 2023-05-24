using System.ComponentModel.DataAnnotations;

namespace BusinessContact.Service.DTOs.Contacts
{
    public class ContactForUpdateDto
    {
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        

        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; }


        [EmailAddress]
        public string Email { get; set; }
    }
}
