using System.ComponentModel.DataAnnotations;

namespace BusinessContact.Service.DTOs.Login
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
