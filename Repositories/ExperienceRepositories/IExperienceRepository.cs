using Portfolio.Models.ExperienceDtos;

namespace Portfolio.Repositories.ExperienceRepositories;

public interface IExperienceRepository
{
    Task<List<ExperienceDto>> GetAllExperienceAsync();
    Task<ExperienceDto> GetExperienceByIdAsync(int id);
    Task CreateExperienceAsync(CreateExperienceDto createExperience);
    Task UpdateExperienceAsync(ExperienceDto experience);
    Task DeleteExperienceAsync(int id);
}
