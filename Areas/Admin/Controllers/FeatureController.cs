using Microsoft.AspNetCore.Mvc;
using Portfolio.Models.FeatureDtos;
using Portfolio.Repositories.FeatureRepositories;

namespace Portfolio.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/Feature")]
public class FeatureController : Controller
{
    private readonly IFeatureRepository _featureRepository;

    public FeatureController(IFeatureRepository featureRepository)
    {
        _featureRepository = featureRepository;
    }
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var values = await _featureRepository.GetAllFeatureAsync();
        return View(values);
    }

    [HttpGet]
    [Route("CreateFeature")]
    public IActionResult CreateFeature()
    {
        return View();
    }

    [HttpPost]
    [Route("CreateFeature")]
    public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
    {
        if (ModelState.IsValid)
        {
            await _featureRepository.CreateFeatureAsync(createFeatureDto);
            return RedirectToAction("Index", "Feature", new { area = "Admin" });
        }

        return View(createFeatureDto);
    }

    [Route("UpdateFeature/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateFeature(int id)
    {
        var value = await _featureRepository.GetFeatureByIdAsync(id);
        return View(value);
    }

    [Route("UpdateFeature/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateFeature(FeatureDto featureDto)
    {
        if (ModelState.IsValid)
        {
            await _featureRepository.UpdateFeatureAsync(featureDto);
            return RedirectToAction("Index", "Feature", new { area = "Admin" });
        }

        return View(featureDto);
    }

    [Route("DeleteFeature/{id}")]
    public async Task<IActionResult> DeleteFeature(int id)
    {
        await _featureRepository.DeleteFeatureAsync(id);
        return RedirectToAction("Index", "Feature", new { area = "Admin" });
    }
}
