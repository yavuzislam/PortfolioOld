using Microsoft.AspNetCore.Mvc;
using Portfolio.Models.PortfolioDataDtos;
using Portfolio.Repositories.PortfolioDataRepositories;

namespace Portfolio.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/PortfolioData")]
public class PortfolioDataController : Controller
{
    private readonly IPortfolioDataRepository _portfolioDataRepository;

    public PortfolioDataController(IPortfolioDataRepository portfolioDataRepository)
    {
        _portfolioDataRepository = portfolioDataRepository;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var values = await _portfolioDataRepository.GetAllPortfolioDataAsync();
        return View(values);
    }

    [HttpGet]
    [Route("CreatePortfolioData")]
    public IActionResult CreatePortfolioData()
    {
        return View();
    }

    [HttpPost]
    [Route("CreatePortfolioData")]
    public async Task<IActionResult> CreatePortfolioData(CreatePortfolioDataDto createPortfolioDataDto)
    {
        if (ModelState.IsValid)
        {
            await _portfolioDataRepository.CreatePortfolioDataAsync(createPortfolioDataDto);
            return RedirectToAction("Index", "PortfolioData", new { area = "Admin" });
        }
        return View(createPortfolioDataDto);
    }

    [Route("UpdatePortfolioData/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdatePortfolioData(int id)
    {
        var value = await _portfolioDataRepository.GetPortfolioDataByIdAsync(id);
        return View(value);
    }

    [Route("UpdatePortfolioData/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdatePortfolioData(PortfolioDataDto portfolioDataDto)
    {
        if (ModelState.IsValid)
        {
            await _portfolioDataRepository.UpdatePortfolioDataAsync(portfolioDataDto);
            return RedirectToAction("Index", "PortfolioData", new { area = "Admin" });
        }
        return View(portfolioDataDto);
    }

    [Route("DeletePortfolioData/{id}")]
    public async Task<IActionResult> DeletePortfolioData(int id)
    {
        await _portfolioDataRepository.DeletePortfolioDataAsync(id);
        return RedirectToAction("Index", "PortfolioData", new { area = "Admin" });
    }
}
