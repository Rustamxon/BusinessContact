using BusinessContact.Data.IRepositories;
using BusinessContact.Data.Repositories;
using BusinessContact.Domain.Entities;

namespace BusinessContact.Presentation
{
    public class Program
    {
        public async Task Main()
        {
            Contacts contacts = new Contacts()
            {
                Id = 1,
                FirstName = "Name1",
                LastName = "Surname1",
                PhoneNumber = "1234567890",
                Character = "good",
                City = "Kokand",
                DateOfBirth = "12.12.2022",
                Job = "dasturchi",
                Email = "name1@gmail.com",
                CreatedAt = DateTime.Now,
                LastUpdatedAt = DateTime.Now,

            };

            IGenericRepository<Contacts> genericRepository = new GenericRepository<Contacts>();
            await genericRepository.CreateAsync(contacts);
            var model = await genericRepository.GetByIdAsync(1);
            Console.WriteLine(model.FirstName);
        }
    }
}
