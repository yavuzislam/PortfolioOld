using Microsoft.AspNetCore.Mvc;
using Portfolio.Models.AboutDtos;
using Portfolio.Repositories.AboutRepositories;

namespace Portfolio.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/About")]
public class AboutController : Controller
{
    private readonly IAboutRepository _aboutRepository;

    public AboutController(IAboutRepository aboutRepository)
    {
        _aboutRepository = aboutRepository;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var values = await _aboutRepository.GetAllAbout();
        return View(values);
    }

    [HttpGet]
    [Route("CreateAbout")]
    public IActionResult CreateAbout()
    {
        return View();
    }

    [HttpPost]
    [Route("CreateAbout")]
    public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
    {
        if (ModelState.IsValid)
        {
            await _aboutRepository.CreateAbout(createAboutDto);
            return RedirectToAction("Index", "About", new { area = "Admin" });
        }

        return View(createAboutDto);
    }

    [Route("UpdateAbout/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateAbout(int id)
    {
        var value = await _aboutRepository.GetAboutById(id);
        return View(value);
    }

    [Route("UpdateAbout/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateAbout(AboutDto aboutDto)
    {
        if (ModelState.IsValid)
        {
            await _aboutRepository.UpdateAbout(aboutDto);
            return RedirectToAction("Index", "About", new { area = "Admin" });
        }

        return View(aboutDto);
    }

    [Route("DeleteAbout/{id}")]
    public async Task<IActionResult> DeleteAbout(int id)
    {
        await _aboutRepository.DeleteAbout(id);
        return RedirectToAction("Index", "About", new { area = "Admin" });
    }
}
