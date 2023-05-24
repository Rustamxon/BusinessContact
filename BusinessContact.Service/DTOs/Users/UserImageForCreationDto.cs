using Microsoft.AspNetCore.Http;

namespace BusinessContact.Service.DTOs.Users
{
    public class UserImageForCreationDto
    {
        public IFormFile Image { get; set; }
        public int UserId { get; set; }
    }
}
