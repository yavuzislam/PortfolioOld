using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models.FooterDtos;

namespace Portfolio.Repositories.FooterRepositories;

public class FooterRepository : IFooterRepository
{
    private readonly Context _context;

    public FooterRepository(Context context)
    {
        _context = context;
    }

    public async Task CreateFooterAsync(CreateFooterDto createFooterDto)
    {
        await _context.Footers.AddAsync(new Footer
        {
            Name = createFooterDto.Name,
            Title = createFooterDto.Title
        });
        await _context.SaveChangesAsync();
    }

    public async Task DeleteFooterAsync(int id)
    {
        var value = await _context.Footers.FindAsync(id);
        _context.Footers.Remove(value);
        await _context.SaveChangesAsync();
    }

    public async Task<List<FooterDto>> GetAllFooterAsync()
    {
        var values = await _context.Footers.ToListAsync();
        return values.Select(x => new FooterDto
        {
            Id = x.Id,
            Name = x.Name,
            Title = x.Title
        }).ToList();
    }

    public async Task<FooterDto> GetFooterByIdAsync(int id)
    {
        var value = await _context.Footers.FindAsync(id);
        return new FooterDto
        {
            Id = value.Id,
            Name = value.Name,
            Title = value.Title
        };
    }


    public async Task UpdateFooterAsync(FooterDto FooterDto)
    {
        var value = await _context.Footers.FindAsync(FooterDto.Id);
        value.Title = FooterDto.Title;
        value.Name = FooterDto.Name;
        await _context.SaveChangesAsync();
    }
    public async Task<FooterDto> GetLastFooterAsync()
    {
        var value = await _context.Footers.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
        return new FooterDto
        {
            Id = value.Id,
            Name = value.Name,
            Title = value.Title
        };
    }
}
