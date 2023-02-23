using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessContact.Service.DTOs
{
    public class ContactsDto
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Job { get; set; }
        public string? Address { get; set; }
    }
}
