using BusinessContact.Data.IRepositories;
using BusinessContact.Data.Repositories;
using BusinessContact.Domain.Entities;
using BusinessContact.Service.DTOs;
using BusinessContact.Service.Helpers;
using BusinessContact.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessContact.Service.Services
{
    public class ContactsService : IContactsService
    {
        private readonly IGenericRepository<Contacts> contactsRepository;

        public ContactsService()
        {
            contactsRepository = new GenericRepository<Contacts>();
        }
        public async Task<GenericResponce<Contacts>> CreateAsync(ContactsDto contactsDto)
        {
            var contact = (await this.contactsRepository.GetAllAsync()).FirstOrDefault(c => c.PhoneNumber == contactsDto.PhoneNumber);
            
            if (contact is not null)
            {
                return new GenericResponce<Contacts>
                {
                    StatusCode = 409,
                    Message = "This contact is already exist",
                    Value = null,
                };
            }

            var newContact = new Contacts()
            {
                CreatedAt = DateTime.Now,
                FirstName = contactsDto.FirstName,
                LastName = contactsDto.LastName,
                PhoneNumber = contactsDto.PhoneNumber,
                DateOfBirth = contactsDto.DateOfBirth,
                Address = contactsDto.Address,
                Email = contactsDto.Email,
                Job = contactsDto.Job,
            };

            await this.contactsRepository.CreateAsync(newContact);

            return new GenericResponce<Contacts> 
            {
                StatusCode = 200,
                Message = "Succesfully create",
                Value = newContact,
            };
        }

        public async Task<GenericResponce<Contacts>> DeleteAsync(long id)
        {
            var contact = await this.contactsRepository.GetByIdAsync(id);
            
            if (contact is null)
            {
                return new GenericResponce<Contacts>()
                {
                    StatusCode = 404,
                    Message = "Contact not found",
                    Value = null
                };
            }

            await contactsRepository.DeleteAsync(id);

            return new GenericResponce<Contacts>()
            {
                StatusCode = 200,
                Message = "Ok",
                Value = contact
            };
        }

        public async Task<GenericResponce<List<Contacts>>> GetAllAsync()
        {
            
            var result = await this.contactsRepository.GetAllAsync();
            return new GenericResponce<List<Contacts>>()
            {
                StatusCode = 200,
                Message = "Ok",
                Value = result
            };
            
        }

        public async Task<GenericResponce<Contacts>> GetByIdAsync(long id)
        {
            var contacts = (await this.contactsRepository.GetAllAsync()).FirstOrDefault(c => c.Id == id);

            if (contacts is not null)
            {
                return new GenericResponce<Contacts>()
                {
                    StatusCode = 200,
                    Message = "Ok",
                    Value = contacts
                };
            }

            return new GenericResponce<Contacts>()
            {
                StatusCode = 404,
                Message = "Contact not found",
                Value = null
            };
        }
        // It can find if you give name not fully
        public async Task<GenericResponce<Contacts>> GetByNameAsync(string name)
        {
            var contacts = (await this.contactsRepository.GetAllAsync()).FirstOrDefault(c => c.FirstName.Contains(name));
            if (contacts is not null)
            {
                return new GenericResponce<Contacts>()
                {
                    StatusCode = 200,
                    Message = "Ok",
                    Value = contacts
                };
            }

            return new GenericResponce<Contacts>()
            {
                StatusCode = 404,
                Message = "Not found",
                Value = null
            };
        }
        // It can find if you give number not fully )
        public async Task<GenericResponce<Contacts>> GetByPhoneNumberAsync(string pieceOfNumber)
        {
            var contacts = (await this.contactsRepository.GetAllAsync()).FirstOrDefault(c => c.PhoneNumber.Contains(pieceOfNumber));
            
            if (contacts is not null)
            {
                return new GenericResponce<Contacts>()
                {
                    StatusCode = 200,
                    Message = "Ok",
                    Value = contacts,
                };
            }

            return new GenericResponce<Contacts>()
            {
                StatusCode = 404,
                Message = "Contacts not found",
                Value = null,
            };
        }

        public async Task<GenericResponce<Contacts>> UpdateAsync(long id, ContactsDto contactsDto)
        {
            var contacts = await this.contactsRepository.GetAllAsync();
            var contact = contacts.FirstOrDefault(c => c.Id == id);

            if (contact is null)
            {
                return new GenericResponce<Contacts>
                {
                    StatusCode = 404,
                    Message = "Contact not found",
                    Value = null
                };
            }

            contact.FirstName = contactsDto.FirstName;
            contact.LastName = contactsDto.LastName;
            contact.Email = contactsDto.Email;
            contact.DateOfBirth = contactsDto.DateOfBirth;
            contact.Address = contactsDto.Address;
            contact.PhoneNumber = contactsDto.PhoneNumber;
            contact.Job = contactsDto.Job;
            contact.LastUpdatedAt = DateTime.Now;

            var result = await this.contactsRepository.UpdateAsync(contact);

            return new GenericResponce<Contacts>()
            {
                StatusCode = 200,
                Message = "Ok",
                Value  = result
            };

        }
    }
}
