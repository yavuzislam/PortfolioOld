using Microsoft.AspNetCore.Mvc;
using Portfolio.Models.SocialMediaDtos;
using Portfolio.Repositories.SocialMediaRepositories;

namespace Portfolio.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/SocialMedia")]
public class SocialMediaController : Controller
{
    private readonly ISocialMediaRepository _SocialMediaRepository;

    public SocialMediaController(ISocialMediaRepository SocialMediaRepository)
    {
        _SocialMediaRepository = SocialMediaRepository;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var values = await _SocialMediaRepository.GetAllSocialMediaAsync();
        return View(values);
    }

    [HttpGet]
    [Route("CreateSocialMedia")]
    public IActionResult CreateSocialMedia()
    {
        return View();
    }

    [HttpPost]
    [Route("CreateSocialMedia")]
    public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
    {
        if (ModelState.IsValid)
        {
            await _SocialMediaRepository.CreateSocialMediaAsync(createSocialMediaDto);
            return RedirectToAction("Index", "SocialMedia", new { area = "Admin" });
        }

        return View(createSocialMediaDto);
    }

    [Route("UpdateSocialMedia/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateSocialMedia(int id)
    {
        var value = await _SocialMediaRepository.GetSocialMediaByIdAsync(id);
        return View(value);
    }

    [Route("UpdateSocialMedia/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateSocialMedia(SocialMediaDto SocialMediaDto)
    {
        if (ModelState.IsValid)
        {
            await _SocialMediaRepository.UpdateSocialMediaAsync(SocialMediaDto);
            return RedirectToAction("Index", "SocialMedia", new { area = "Admin" });
        }

        return View(SocialMediaDto);
    }

    [Route("DeleteSocialMedia/{id}")]
    public async Task<IActionResult> DeleteSocialMedia(int id)
    {
        await _SocialMediaRepository.DeleteSocialMediaAsync(id);
        return RedirectToAction("Index", "SocialMedia", new { area = "Admin" });
    }
}
