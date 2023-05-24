using System.ComponentModel.DataAnnotations;

namespace BusinessContact.Service.DTOs.Users
{
    public class UserForCreationDto
    {
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        
        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }

        
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        
        
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
