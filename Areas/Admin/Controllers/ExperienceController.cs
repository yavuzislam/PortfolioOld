using Microsoft.AspNetCore.Mvc;
using Portfolio.Models.ExperienceDtos;
using Portfolio.Repositories.ExperienceRepositories;

namespace Portfolio.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/Experience")]
public class ExperienceController : Controller
{
    private readonly IExperienceRepository _experienceRepository;

    public ExperienceController(IExperienceRepository experienceRepository)
    {
        _experienceRepository = experienceRepository;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var values = await _experienceRepository.GetAllExperienceAsync();
        return View(values);
    }

    [HttpGet]
    [Route("CreateExperience")]
    public IActionResult CreateExperience()
    {
        return View();
    }

    [HttpPost]
    [Route("CreateExperience")]
    public async Task<IActionResult> CreateExperience(CreateExperienceDto createExperience)
    {
        if (ModelState.IsValid)
        {
            await _experienceRepository.CreateExperienceAsync(createExperience);
            return RedirectToAction("Index", "Experience", new { area = "Admin" });
        }
        return View(createExperience);
    }

    [Route("UpdateExperience/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateExperience(int id)
    {
        var value = await _experienceRepository.GetExperienceByIdAsync(id);
        return View(value);
    }

    [Route("UpdateExperience/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateExperience(ExperienceDto experience)
    {
        if (ModelState.IsValid)
        {
            await _experienceRepository.UpdateExperienceAsync(experience);
            return RedirectToAction("Index", "Experience", new { area = "Admin" });
        }
        return View(experience);
    }

    [Route("DeleteExperience/{id}")]
    public async Task<IActionResult> DeleteExperience(int id)
    {
        await _experienceRepository.DeleteExperienceAsync(id);
        return RedirectToAction("Index", "Experience", new { area = "Admin" });
    }


}
