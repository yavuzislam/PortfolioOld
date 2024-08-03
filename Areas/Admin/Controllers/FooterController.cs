using Microsoft.AspNetCore.Mvc;
using Portfolio.Models.FooterDtos;
using Portfolio.Repositories.FooterRepositories;

namespace Portfolio.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/Footer")]
public class FooterController : Controller
{
    private readonly IFooterRepository _FooterRepository;

    public FooterController(IFooterRepository FooterRepository)
    {
        _FooterRepository = FooterRepository;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var values = await _FooterRepository.GetAllFooterAsync();
        return View(values);
    }

    [HttpGet]
    [Route("CreateFooter")]
    public IActionResult CreateFooter()
    {
        return View();
    }

    [HttpPost]
    [Route("CreateFooter")]
    public async Task<IActionResult> CreateFooter(CreateFooterDto createFooterDto)
    {
        if (ModelState.IsValid)
        {
            await _FooterRepository.CreateFooterAsync(createFooterDto);
            return RedirectToAction("Index", "Footer", new { area = "Admin" });
        }

        return View(createFooterDto);
    }

    [Route("UpdateFooter/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateFooter(int id)
    {
        var value = await _FooterRepository.GetFooterByIdAsync(id);
        return View(value);
    }

    [Route("UpdateFooter/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateFooter(FooterDto FooterDto)
    {
        if (ModelState.IsValid)
        {
            await _FooterRepository.UpdateFooterAsync(FooterDto);
            return RedirectToAction("Index", "Footer", new { area = "Admin" });
        }

        return View(FooterDto);
    }

    [Route("DeleteFooter/{id}")]
    public async Task<IActionResult> DeleteFooter(int id)
    {
        await _FooterRepository.DeleteFooterAsync(id);
        return RedirectToAction("Index", "Footer", new { area = "Admin" });
    }
}
