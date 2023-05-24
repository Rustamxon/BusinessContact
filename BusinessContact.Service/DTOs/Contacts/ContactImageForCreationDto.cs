using Microsoft.AspNetCore.Http;

namespace BusinessContact.Service.DTOs.Contacts
{
    public class ContactImageForCreationDto
    {
        public IFormFile Image { get; set; }
        public long UserId { get; set; }
    }
}
