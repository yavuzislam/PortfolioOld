using Microsoft.AspNetCore.Mvc;
using Portfolio.Repositories.ServiceRepositories;

namespace Portfolio.ViewComponents;

public class ServiceComponent : ViewComponent
{
    private readonly IServiceRepository _serviceRepository;

    public ServiceComponent(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var values = await _serviceRepository.GetAllServicesAsync();
        return View(values);
    }
}
