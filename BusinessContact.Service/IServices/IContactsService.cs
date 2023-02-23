using BusinessContact.Domain.Entities;
using BusinessContact.Service.DTOs;
using BusinessContact.Service.Helpers;

namespace BusinessContact.Service.IServices
{
    public interface IContactsService
    {
        Task<GenericResponce<Contacts>> CreateAsync(ContactsDto contactsDto);
        Task<GenericResponce<Contacts>> UpdateAsync(long id, ContactsDto contactsDto);
        Task<GenericResponce<Contacts>> GetByIdAsync(long id);
        Task<GenericResponce<Contacts>> DeleteAsync(long id);
        Task<GenericResponce<Contacts>> GetByNameAsync(string name);
        Task<GenericResponce<Contacts>> GetByPhoneNumberAsync(string pieceOfNumber);
        Task<GenericResponce<List<Contacts>>> GetAllAsync();
    }
}
