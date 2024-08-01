using Microsoft.AspNetCore.Mvc;
using Portfolio.Models.ServiceDtos;
using Portfolio.Repositories.ServiceRepositories;

namespace Portfolio.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/Service")]
public class ServiceController : Controller
{
    private readonly IServiceRepository _serviceRepository;

    public ServiceController(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var values = await _serviceRepository.GetAllServicesAsync();
        return View(values);
    }

    [HttpGet]
    [Route("CreateService")]
    public IActionResult CreateService()
    {
        return View();
    }

    [HttpPost]
    [Route("CreateService")]
    public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
    {
        if (ModelState.IsValid)
        {
            await _serviceRepository.CreateServiceAsync(createServiceDto);
            return RedirectToAction("Index", "Service", new { area = "Admin" });
        }

        return View(createServiceDto);
    }

    [Route("UpdateService/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateService(int id)
    {
        var value = await _serviceRepository.GetServiceByIdAsync(id);
        return View(value);
    }

    [Route("UpdateService/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateService(ServiceDto serviceDto)
    {
        if (ModelState.IsValid)
        {
            await _serviceRepository.UpdateServiceAsync(serviceDto);
            return RedirectToAction("Index", "Service", new { area = "Admin" });
        }

        return View(serviceDto);
    }

    [Route("DeleteService/{id}")]
    public async Task<IActionResult> DeleteService(int id)
    {
        await _serviceRepository.DeleteServiceAsync(id);
        return RedirectToAction("Index", "Service", new { area = "Admin" });
    }
}
