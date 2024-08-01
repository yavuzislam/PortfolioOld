using Portfolio.Models.ContactDtos;

namespace Portfolio.Repositories.ContactRepositories;

public interface IContactRepository
{
    Task<List<ContactDto>> GetAllContactAsync();
    Task<ContactDto> GetLastContactAsync();
    Task<ContactDto> GetContactByIdAsync(int id);
    Task CreateContactAsync(CreateContactDto createContactDto);
    Task UpdateContactAsync(ContactDto contactDto);
    Task DeleteContactAsync(int id);
}
