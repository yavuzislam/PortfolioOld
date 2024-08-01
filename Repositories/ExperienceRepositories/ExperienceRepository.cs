using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models.ExperienceDtos;

namespace Portfolio.Repositories.ExperienceRepositories;

public class ExperienceRepository : IExperienceRepository
{
    private readonly Context _context;

    public ExperienceRepository(Context context)
    {
        _context = context;
    }
    public async Task<List<ExperienceDto>> GetAllExperienceAsync()
    {
        var values = await _context.Experiences.ToListAsync();
        return values.Select(x => new ExperienceDto
        {
            Description = x.Description,
            Id = x.Id,
            ImagePath = x.ImagePath,
            Title = x.Title
        }).ToList();
    }

    public async Task CreateExperienceAsync(CreateExperienceDto createExperience)
    {
        await _context.Experiences.AddAsync(new Experience
        {
            Description = createExperience.Description,
            ImagePath = createExperience.ImagePath,
            Title = createExperience.Title
        });
        await _context.SaveChangesAsync();
    }

    public async Task DeleteExperienceAsync(int id)
    {
        var value = await _context.Experiences.FindAsync(id);
        _context.Experiences.Remove(value);
        await _context.SaveChangesAsync();
    }


    public async Task<ExperienceDto> GetExperienceByIdAsync(int id)
    {
        var value = await _context.Experiences.FindAsync(id);
        return new ExperienceDto
        {
            Description = value.Description,
            Id = value.Id,
            ImagePath = value.ImagePath,
            Title = value.Title
        };
    }

    public async Task UpdateExperienceAsync(ExperienceDto experience)
    {
        var value = await _context.Experiences.FindAsync(experience.Id);
        value.Description = experience.Description;
        value.ImagePath = experience.ImagePath;
        value.Title = experience.Title;
        await _context.SaveChangesAsync();
    }
}
