﻿using BusinessContact.Domain.Commons;

namespace BusinessContact.Domain.Entities
{
    public class UserImage : Auditable
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
