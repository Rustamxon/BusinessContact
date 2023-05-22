using BusinessContact.Domain.Entities;
using BusinessContact.Service.DTOs;
using BusinessContact.Service.Helpers;

namespace BusinessContact.Service.IServices
{
    public interface IUsersService
    {
        Task<GenericResponce<List<User>>> GetAllAsync();
        Task<GenericResponce<User>> GetByIdAsync(long id);
        Task<GenericResponce<User>> CreateAsync(UsersDto usersDto);
        Task<GenericResponce<User>> DeleteAsync(long id);
        Task<GenericResponce<User>> UpdateAsync(long id, UsersDto usersDto);
        Task<GenericResponce<Contacts>> CreateContactAsync(long id, string password, ContactsDto contacts);
        Task<GenericResponce<List<Contacts>>> ShareContactsAsync(long Sendingid, string password, long ReceiveId, string ContactName);
    }
}
