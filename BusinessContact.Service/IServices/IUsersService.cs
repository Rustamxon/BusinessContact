using BusinessContact.Domain.Entities;
using BusinessContact.Service.DTOs;
using BusinessContact.Service.Helpers;

namespace BusinessContact.Service.IServices
{
    public interface IUsersService
    {
        Task<GenericResponce<List<Users>>> GetAllAsync();
        Task<GenericResponce<Users>> GetByIdAsync(long id);
        Task<GenericResponce<Users>> CreateAsync(UsersDto usersDto);
        Task<GenericResponce<Users>> DeleteAsync(long id);
        Task<GenericResponce<Users>> UpdateAsync(long id, UsersDto usersDto);
        Task<GenericResponce<Contacts>> CreateContactAsync(long id, string password, ContactsDto contacts);
        Task<GenericResponce<List<Contacts>>> ShareContactsAsync(long Sendingid, string password, long ReceiveId, string ContactName);
    }
}
