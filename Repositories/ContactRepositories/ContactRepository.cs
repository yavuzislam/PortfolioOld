using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models.ContactDtos;

namespace Portfolio.Repositories.ContactRepositories;

public class ContactRepository : IContactRepository
{
    private readonly Context _context;

    public ContactRepository(Context context)
    {
        _context = context;
    }

    public async Task CreateContactAsync(CreateContactDto createContactDto)
    {
        await _context.AddAsync(new Contact
        {
            Title = createContactDto.Title,
            Description = createContactDto.Description,
            Email = createContactDto.Email,
            Phone = createContactDto.Phone
        });
        await _context.SaveChangesAsync();
    }

    public async Task DeleteContactAsync(int id)
    {
        var value = await _context.Contacts.FindAsync(id);
        _context.Contacts.Remove(value);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateContactAsync(ContactDto contactDto)
    {
        var value = await _context.Contacts.FindAsync(contactDto.Id);
        value.Title = contactDto.Title;
        value.Description = contactDto.Description;
        value.Email = contactDto.Email;
        value.Phone = contactDto.Phone;
        await _context.SaveChangesAsync();
    }
    public async Task<ContactDto> GetContactByIdAsync(int id)
    {
        var value = await _context.Contacts.FindAsync(id);
        return new ContactDto
        {
            Id = value.Id,
            Title = value.Title,
            Description = value.Description,
            Email = value.Email,
            Phone = value.Phone
        };
    }

    public async Task<List<ContactDto>> GetAllContactAsync()
    {
        var values = await _context.Contacts.ToListAsync();
        return values.Select(x => new ContactDto
        {
            Id = x.Id,
            Title = x.Title,
            Description = x.Description,
            Email = x.Email,
            Phone = x.Phone
        }).ToList();
    }


    public async Task<ContactDto> GetLastContactAsync()
    {
        var value = await _context.Contacts.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
        return new ContactDto
        {
            Id = value.Id,
            Title = value.Title,
            Description = value.Description,
            Email = value.Email,
            Phone = value.Phone
        };
    }

}
