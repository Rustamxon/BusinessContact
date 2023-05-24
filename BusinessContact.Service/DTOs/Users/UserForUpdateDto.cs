using System.ComponentModel.DataAnnotations;

namespace BusinessContact.Service.DTOs.Users
{
    public class UserForUpdateDto
    {
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        
        [Required(ErrorMessage = "Phone number is required")]
        public string Phone { get; set; }

        
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

    }
}
