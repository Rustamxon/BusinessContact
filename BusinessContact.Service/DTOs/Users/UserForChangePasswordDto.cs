using System.ComponentModel.DataAnnotations;

namespace BusinessContact.Service.DTOs.Users
{
    public class UserForChangePasswordDto
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }


        [Required(ErrorMessage = "Old password must not be null or empty")]
        public string OldPassword { get; set; }


        [Required(ErrorMessage = "New password must not be null or empty")]
        public string NewPassword { get; set; }


        [Required(ErrorMessage = "New password must not be null or empty")]
        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; }

    }
}
