using BusinessContact.Data.IRepositories;
using BusinessContact.Data.Repositories;
using BusinessContact.Domain.Entities;
using BusinessContact.Service.DTOs;
using BusinessContact.Service.Helpers;
using BusinessContact.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessContact.Service.Services
{
    public class UsersService : IUsersService
    {
        private readonly IGenericRepository<Users> usersRepository;
        private readonly IContactsService contactsService;
        private readonly IGenericRepository<Contacts> contactsRepository;

        public UsersService()
        {
            usersRepository = new GenericRepository<Users>();
            contactsService = new ContactsService();
            contactsRepository = new GenericRepository<Contacts>();
        }
        public async Task<GenericResponce<Users>> CreateAsync(UsersDto usersDto)
        {
            var user = (await this.usersRepository.GetAllAsync()).FirstOrDefault(x => x.FirstName == usersDto.FirstName);
            if (user is not null) 
            {
                return new GenericResponce<Users>()
                {
                    StatusCode = 409,
                    Message = "This user is already exist",
                    Value = null
                };
            }

            var newUser = new Users()
            {
                FirstName = usersDto.FirstName,
                LastName = usersDto.LastName,
                PhoneNumber = usersDto.PhoneNumber,
                DateOfBirth = usersDto.DateOfBirth,
                CreatedAt = DateTime.Now
            }; 
            
            var result = await this.usersRepository.CreateAsync(newUser);

            return new GenericResponce<Users>()
            {
                StatusCode = 200,
                Message = "OK",
                Value = newUser
            };
        }

        public async Task<GenericResponce<Contacts>> CreateContactAsync(long id, string password, ContactsDto Addingcontact)
        {
            var user = await this.usersRepository.GetByIdAsync(id);
            
            if (user is not null)
            {
                if (user.Password == password)
                {
                   // var userContact = user.Contactlar.FirstOrDefault(c => c.FirstName == Addingcontact.FirstName);
                         Console.WriteLine("hello");

                        var AddContact = new Contacts()
                        {
                            FirstName = Addingcontact.FirstName,
                            LastName = Addingcontact.LastName,
                            Email = Addingcontact.Email,
                            PhoneNumber = Addingcontact.PhoneNumber,
                            DateOfBirth = Addingcontact.DateOfBirth,
                            Address = Addingcontact.Address,
                            Job = Addingcontact.Job,
                            CreatedAt = DateTime.Now,
                        };

                        //obshiy contactlar bazasiga qo'shish 
                        await  contactsRepository.CreateAsync(AddContact);
                        Console.WriteLine("ojojoj");
                        //userdi ozini contactlariga qoshish
                        var sss = user.Contactlar.Append(AddContact);
                        //user.Contactlar += user.Contactlar.Append(AddContact);
                        Console.WriteLine("sasas");

                        return new GenericResponce<Contacts>()
                        {
                            StatusCode = 200,
                            Message = "Contact added",
                            Value = AddContact
                        };
                }
                return new GenericResponce<Contacts>()
                {
                    StatusCode = 404,
                    Message = "UserId or password is incorrect",
                    Value = null
                };
            }
            return new GenericResponce<Contacts>()
            {
                StatusCode = 409,
                Message = "There are already this contact",
                Value = null,
            };
        }

        public async Task<GenericResponce<Users>> DeleteAsync(long id)
        {
            var user = await usersRepository.GetByIdAsync(id);

            if (user is null)
            {
                return new GenericResponce<Users>()
                {
                    StatusCode = 404,
                    Message = "User not found",
                    Value = null
                };
            }

            await usersRepository.DeleteAsync(id);

            return new GenericResponce<Users>()
            {
                StatusCode = 200,
                Message = "OK",
                Value = user
            };
        }

        public async Task<GenericResponce<List<Users>>> GetAllAsync()
        {
            var users = await this.usersRepository.GetAllAsync();

            return new GenericResponce<List<Users>>()
            {
                StatusCode = 200,
                Message = "Ok",
                Value = users
            };
        }

        public async Task<GenericResponce<Users>> GetByIdAsync(long id)
        {
            var user = (await this.usersRepository.GetAllAsync()).FirstOrDefault(u => u.Id == id);
            if (user is null)
            {
                return new GenericResponce<Users>()
                {
                    StatusCode = 404,
                    Message = "User not found",
                    Value = null,
                };
            }

            return new GenericResponce<Users>()
            {
                StatusCode = 200,
                Message = "Ok",
                Value = user
            };
        }

        public async Task<GenericResponce<List<Contacts>>> ShareContactsAsync(long id, string password, long SendingUserid, string ContactName)
        {
            //id jo'natib turgan Id si Password ham jo'natib turganniki, password bilan tasdiqlagandan keyin boshqa userga (SendingUserid) jo'natadi

            var allUsers = await this.usersRepository.GetAllAsync();

            //jo'natayotgan user
            var user = allUsers.FirstOrDefault(u => u.Id == id);
            //qabul qiluvchi id si
            var sendingUser =  allUsers.FirstOrDefault(u => u.Id == SendingUserid);
            //jo'natuvchining contacti
            var sendingContact = user.Contactlar.FirstOrDefault(c => c.FirstName == ContactName);

            if (user.Password == password)
            {
                if (sendingContact is not null)
                {
                    if (sendingUser is not null)
                    {
                        sendingUser.Contactlar.Add(sendingContact);
                    }
                    return new GenericResponce<List<Contacts>>()
                    {
                        StatusCode = 404,
                        Message = "Sending user not found",
                        Value = null
                    };
                }
                return new GenericResponce<List<Contacts>>()
                {
                    StatusCode = 404,
                    Message = "Sorry, you have not contact with this name",
                    Value = null
                };
            }
            return new GenericResponce<List<Contacts>>()
            {
                StatusCode = 200,
                Message = "Id or Password incorrect",
                Value = null
            };
        }

        public async Task<GenericResponce<Users>> UpdateAsync(long id, UsersDto usersDto)
        {
            var allUsers = await this.usersRepository.GetAllAsync();
            var user = allUsers.FirstOrDefault(u => u.Id == id);

            if (user is null) 
            {
                return new GenericResponce<Users>()
                {
                    StatusCode = 404,
                    Message = "User not found",
                    Value = null
                };
            }

            user.FirstName = usersDto.FirstName;
            user.LastName = usersDto.LastName;
            user.PhoneNumber = usersDto.PhoneNumber;
            user.DateOfBirth = usersDto.DateOfBirth;
            user.Contactlar = usersDto.contactlar;
            user.Password = usersDto.Password;
            user.LastUpdatedAt = DateTime.Now;

            await this.usersRepository.UpdateAsync(user);

            return new GenericResponce<Users>()
            {
                StatusCode = 200,
                Message = "Successfully updated",
                Value = user
            };
        }
    }
}
