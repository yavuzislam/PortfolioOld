using Portfolio.Models.ServiceDtos;

namespace Portfolio.Repositories.ServiceRepositories;

public interface IServiceRepository
{
    Task<List<ServiceDto>> GetAllServicesAsync();
    Task<ServiceDto> GetServiceByIdAsync(int id);
    Task CreateServiceAsync(CreateServiceDto createServiceDto);
    Task UpdateServiceAsync(ServiceDto serviceDto);
    Task DeleteServiceAsync(int id);
}
