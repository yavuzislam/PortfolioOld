using Portfolio.Models.SkillDtos;

namespace Portfolio.Repositories.SkillRepositories;

public interface ISkillRepository
{
    Task<List<SkillDto>> GetAllSkillsAsync();
    Task<SkillDto> GetSkillByIdAsync(int id);
    Task CreateSkillAsync(CreateSkillDto createSkillDto);
    Task UpdateSkillAsync(SkillDto skillDto);
    Task DeleteSkillAsync(int id);
}
