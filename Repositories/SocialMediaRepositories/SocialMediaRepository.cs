using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models.SocialMediaDtos;

namespace Portfolio.Repositories.SocialMediaRepositories;

public class SocialMediaRepository : ISocialMediaRepository
{
    private readonly Context _context;

    public SocialMediaRepository(Context context)
    {
        _context = context;
    }
    public async Task<List<SocialMediaDto>> GetAllSocialMediaAsync()
    {
        var values = await _context.SocialMedias.ToListAsync();

        return values.Select(x => new SocialMediaDto
        {
            Id = x.Id,
            Icon = x.Icon,
            Title = x.Title,
            Url = x.Url
        }).ToList();
    }

    public async Task CreateSocialMediaAsync(CreateSocialMediaDto createSocialMediaDto)
    {
        await _context.SocialMedias.AddAsync(new SocialMedia
        {
            Icon = createSocialMediaDto.Icon,
            Title = createSocialMediaDto.Title,
            Url = createSocialMediaDto.Url
        });
        await _context.SaveChangesAsync();
    }

    public async Task DeleteSocialMediaAsync(int id)
    {
        var value = await _context.SocialMedias.FirstOrDefaultAsync(x => x.Id == id);
        _context.SocialMedias.Remove(value);
        await _context.SaveChangesAsync();
    }


    public async Task<SocialMediaDto> GetSocialMediaByIdAsync(int id)
    {
        var value = await _context.SocialMedias.FirstOrDefaultAsync(x => x.Id == id);
        return new SocialMediaDto
        {
            Id = value.Id,
            Icon = value.Icon,
            Title = value.Title,
            Url = value.Url
        };
    }

    public async Task UpdateSocialMediaAsync(SocialMediaDto socialMediaDto)
    {
        var value = await _context.SocialMedias.FirstOrDefaultAsync(x => x.Id == socialMediaDto.Id);
        value.Icon = socialMediaDto.Icon;
        value.Title = socialMediaDto.Title;
        value.Url = socialMediaDto.Url;
        await _context.SaveChangesAsync();
    }
}
