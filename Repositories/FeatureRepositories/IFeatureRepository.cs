using Portfolio.Models.FeatureDtos;

namespace Portfolio.Repositories.FeatureRepositories;

public interface IFeatureRepository
{
    Task<List<FeatureDto>> GetAllFeatureAsync();
    Task<FeatureDto> GetLastFeatureAsync();
    Task<FeatureDto> GetFeatureByIdAsync(int id);
    Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);
    Task UpdateFeatureAsync(FeatureDto featureDto);
    Task DeleteFeatureAsync(int id);
}
