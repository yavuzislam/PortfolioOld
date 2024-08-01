using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models.SkillDtos;

namespace Portfolio.Repositories.SkillRepositories;

public class SkillRepository : ISkillRepository
{
    private readonly Context _context;

    public SkillRepository(Context context)
    {
        _context = context;
    }
    public async Task<List<SkillDto>> GetAllSkillsAsync()
    {
        var values = await _context.Skills.ToListAsync();
        return values.Select(x => new SkillDto
        {
            Id = x.Id,
            Title = x.Title,
            Ratio = x.Ratio
        }).ToList();
    }

    public async Task CreateSkillAsync(CreateSkillDto createSkillDto)
    {
        await _context.Skills.AddAsync(new Skill
        {
            Title = createSkillDto.Title,
            Ratio = createSkillDto.Ratio
        });
        await _context.SaveChangesAsync();
    }

    public async Task DeleteSkillAsync(int id)
    {
        var value = await _context.Skills.FindAsync(id);
        _context.Skills.Remove(value);
        await _context.SaveChangesAsync();
    }


    public async Task<SkillDto> GetSkillByIdAsync(int id)
    {
        var value = await _context.Skills.FindAsync(id);
        return new SkillDto
        {
            Id = value.Id,
            Title = value.Title,
            Ratio = value.Ratio
        };
    }

    public async Task UpdateSkillAsync(SkillDto skillDto)
    {
        var value = await _context.Skills.FindAsync(skillDto.Id);
        value.Title = skillDto.Title;
        value.Ratio = skillDto.Ratio;
        await _context.SaveChangesAsync();
    }
}
