using BusinessContact.Data.IRepositories;
using BusinessContact.Data.Repositories;
using BusinessContact.Domain.Entities;
using BusinessContact.Service.Services;

namespace BusinessContact.Presentation
{
    public class Program
    {
        public static async Task Main()
        {
            //var user = new Users()
            //{
            //    FirstName = "javohir",
            //    LastName = "hoshimov",
            //    DateOfBirth = "12.12.2004",
            //    CreatedAt = DateTime.Now,
            //    Password = "futbol",
            //    PhoneNumber = "+998905862427",                
            //};

            IGenericRepository<Contacts> contactRepository = new GenericRepository<Contacts>();

            var contactService = new ContactsService();
            //var contact = contactService.GetByPhoneNumberAsync("90857");
            //Console.WriteLine(contact.Result.Value.PhoneNumber);
            //var contact1 = contactService.GetByNameAsync("usta");
            //Console.WriteLine(contact1.Result.Value.FirstName);

            IGenericRepository<Users> genericRepository = new GenericRepository<Users>();
            //genericRepository.CreateAsync(user);
            //var user1 = genericRepository.GetByIdAsync(user.Id);
            //Console.WriteLine(user1.Result.FirstName);

            //var contact = new ContactsDto()
            //{
            //    FirstName = "Bositxon",
            //    LastName = "Turdiyev",
            //    Address = "Kokand",
            //    DateOfBirth = "05.08.1997",
            //    PhoneNumber = "+998906561997",
            //};
            
            var userService = new UsersService();
            //Console.WriteLine(userService.GetByIdAsync(1).Result.Value.FirstName);
            //userService.CreateContactAsync(1, "password", contact);
            //userService.ShareContactsAsync(1, "password", 2, "Bositxon");
        }
    }
}
