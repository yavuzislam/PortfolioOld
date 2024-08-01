using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models.AboutDtos;

namespace Portfolio.Repositories.AboutRepositories;

public class AboutRepository : IAboutRepository
{
    private readonly Context _context;

    public AboutRepository(Context context)
    {
        _context = context;
    }

    public async Task CreateAbout(CreateAboutDto createAboutDto)
    {
        await _context.Abouts.AddAsync(new About
        {
            Title = createAboutDto.Title,
            Description = createAboutDto.Description,
            Age = createAboutDto.Age,
            Email = createAboutDto.Email,
            Phone = createAboutDto.Phone,
            Address = createAboutDto.Address,
            ImagePath = createAboutDto.ImagePath
        });
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAbout(int id)
    {
        var value = await _context.Abouts.FindAsync(id);
        _context.Abouts.Remove(value);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAbout(AboutDto aboutDto)
    {
        var value = await _context.Abouts.FindAsync(aboutDto.Id);
        value.Title = aboutDto.Title;
        value.Description = aboutDto.Description;
        value.Age = aboutDto.Age;
        value.Email = aboutDto.Email;
        value.Phone = aboutDto.Phone;
        value.Address = aboutDto.Address;
        value.ImagePath = aboutDto.ImagePath;
        await _context.SaveChangesAsync();
    }

    public async Task<List<AboutDto>> GetAllAbout()
    {
        var values = await _context.Abouts.ToListAsync();
        return values.Select(value => new AboutDto
        {
            Id = value.Id,
            Address = value.Address,
            Email = value.Email,
            Description = value.Description,
            Phone = value.Phone,
            Title = value.Title,
            ImagePath = value.ImagePath,
            Age = value.Age
        }).ToList();
    }

    public async Task<AboutDto> GetLastAbout()
    {
        var value = await _context.Abouts.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
        return new AboutDto
        {
            Id = value.Id,
            Address = value.Address,
            Email = value.Email,
            Description = value.Description,
            Phone = value.Phone,
            Title = value.Title,
            ImagePath = value.ImagePath,
            Age = value.Age
        };
    }

    public async Task<AboutDto> GetAboutById(int id)
    {
        var value = await _context.Abouts.FindAsync(id);
        return new AboutDto
        {
            Id = value.Id,
            Address = value.Address,
            Email = value.Email,
            Description = value.Description,
            Phone = value.Phone,
            Title = value.Title,
            ImagePath = value.ImagePath,
            Age = value.Age
        };
    }
}
