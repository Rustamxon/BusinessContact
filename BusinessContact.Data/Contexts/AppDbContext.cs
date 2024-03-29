﻿using BusinessContact.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessContact.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserImage> UserImages { get; set; }
        
        public DbSet<UserContact> UserContacts { get; set; }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactImage> ContactImages { get; set; }
    }
}
