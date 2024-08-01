using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models.ServiceDtos;

namespace Portfolio.Repositories.ServiceRepositories;

public class ServiceRepository : IServiceRepository
{
    private readonly Context _context;

    public ServiceRepository(Context context)
    {
        _context = context;
    }
    public async Task<List<ServiceDto>> GetAllServicesAsync()
    {
        var values = await _context.Services.ToListAsync();
        return values.Select(x => new ServiceDto
        {
            Id = x.Id,
            Title = x.Title,
            ImagePath = x.ImagePath
        }).ToList();
    }

    public async Task CreateServiceAsync(CreateServiceDto createServiceDto)
    {
        await _context.Services.AddAsync(new Service
        {
            Title = createServiceDto.Title,
            ImagePath = createServiceDto.ImagePath
        });
        await _context.SaveChangesAsync();
    }

    public async Task DeleteServiceAsync(int id)
    {
        var value = await _context.Services.FindAsync(id);
        _context.Services.Remove(value);
        await _context.SaveChangesAsync();
    }


    public async Task<ServiceDto> GetServiceByIdAsync(int id)
    {
        var value = await _context.Services.FindAsync(id);
        return new ServiceDto
        {
            Id = value.Id,
            Title = value.Title,
            ImagePath = value.ImagePath
        };
    }

    public async Task UpdateServiceAsync(ServiceDto serviceDto)
    {
        var value = await _context.Services.FindAsync(serviceDto.Id);
        value.Title = serviceDto.Title;
        value.ImagePath = serviceDto.ImagePath;
        await _context.SaveChangesAsync();
    }
}
