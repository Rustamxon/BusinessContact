using BusinessContact.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessContact.Service.DTOs
{
    public class UsersDto
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string? DateOfBirth { get; set; }
        public string Password { get; set; }
        public List<Contacts> contactlar { get; set; }
    }
}
