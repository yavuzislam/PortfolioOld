using Portfolio.Models.SocialMediaDtos;

namespace Portfolio.Repositories.SocialMediaRepositories;

public interface ISocialMediaRepository
{
    Task<List<SocialMediaDto>> GetAllSocialMediaAsync();
    Task<SocialMediaDto> GetSocialMediaByIdAsync(int id);
    Task CreateSocialMediaAsync(CreateSocialMediaDto createSocialMediaDto);
    Task UpdateSocialMediaAsync(SocialMediaDto socialMediaDto);
    Task DeleteSocialMediaAsync(int id);
}
