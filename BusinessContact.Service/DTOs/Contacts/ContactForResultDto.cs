﻿using System.ComponentModel.DataAnnotations;

namespace BusinessContact.Service.DTOs.Contacts
{
    public class ContactForResultDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }

    }
}