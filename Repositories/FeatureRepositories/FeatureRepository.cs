using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models.FeatureDtos;

namespace Portfolio.Repositories.FeatureRepositories;

public class FeatureRepository : IFeatureRepository
{
    private readonly Context _context;

    public FeatureRepository(Context context)
    {
        _context = context;
    }

    public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
    {
        await _context.Features.AddAsync(new Feature
        {
            Title = createFeatureDto.Title,
            Introduction = createFeatureDto.Introduction,
            Description = createFeatureDto.Description
        });
        await _context.SaveChangesAsync();
    }

    public async Task DeleteFeatureAsync(int id)
    {
        var value = await _context.Features.FindAsync(id);
        _context.Features.Remove(value);
        await _context.SaveChangesAsync();
    }

    public async Task<List<FeatureDto>> GetAllFeatureAsync()
    {
        var values = await _context.Features.ToListAsync();
        return values.Select(x => new FeatureDto
        {
            Id = x.Id,
            Description = x.Description,
            Introduction = x.Introduction,
            Title = x.Title
        }).ToList();
    }

    public async Task<FeatureDto> GetFeatureByIdAsync(int id)
    {
        var value = await _context.Features.FindAsync(id);
        return new FeatureDto
        {
            Id = value.Id,
            Description = value.Description,
            Introduction = value.Introduction,
            Title = value.Title
        };
    }


    public async Task UpdateFeatureAsync(FeatureDto featureDto)
    {
        var value = await _context.Features.FindAsync(featureDto.Id);
        value.Title = featureDto.Title;
        value.Introduction = featureDto.Introduction;
        value.Description = featureDto.Description;
        await _context.SaveChangesAsync();
    }
    public async Task<FeatureDto> GetLastFeatureAsync()
    {
        var value = await _context.Features.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
        return new FeatureDto
        {
            Id = value.Id,
            Description = value.Description,
            Introduction = value.Introduction,
            Title = value.Title
        };
    }
}
