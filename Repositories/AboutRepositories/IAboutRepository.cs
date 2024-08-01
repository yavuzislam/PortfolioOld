using Portfolio.Models.AboutDtos;

namespace Portfolio.Repositories.AboutRepositories;

public interface IAboutRepository
{
    Task<List<AboutDto>> GetAllAbout();
    Task<AboutDto> GetLastAbout();
    Task<AboutDto> GetAboutById(int id);    
    Task CreateAbout(CreateAboutDto createAboutDto);
    Task UpdateAbout(AboutDto aboutDto);
    Task DeleteAbout(int id);
}
