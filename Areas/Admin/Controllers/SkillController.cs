using Microsoft.AspNetCore.Mvc;
using Portfolio.Models.SkillDtos;
using Portfolio.Repositories.SkillRepositories;

namespace Portfolio.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/Skill")]
public class SkillController : Controller
{
    private readonly ISkillRepository _skillRepository;

    public SkillController(ISkillRepository skillRepository)
    {
        _skillRepository = skillRepository;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var values = await _skillRepository.GetAllSkillsAsync();
        return View(values);
    }

    [HttpGet]
    [Route("CreateSkill")]
    public IActionResult CreateSkill()
    {
        return View();
    }

    [HttpPost]
    [Route("CreateSkill")]
    public async Task<IActionResult> CreateSkill(CreateSkillDto createSkillDto)
    {
        if (ModelState.IsValid)
        {
            await _skillRepository.CreateSkillAsync(createSkillDto);
            return RedirectToAction("Index", "Skill", new { area = "Admin" });
        }

        return View(createSkillDto);
    }

    [Route("UpdateSkill/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateSkill(int id)
    {
        var value = await _skillRepository.GetSkillByIdAsync(id);
        return View(value);
    }

    [Route("UpdateSkill/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateSkill(SkillDto skillDto)
    {
        if (ModelState.IsValid)
        {
            await _skillRepository.UpdateSkillAsync(skillDto);
            return RedirectToAction("Index", "Skill", new { area = "Admin" });
        }

        return View(skillDto);
    }

    [Route("DeleteSkill/{id}")]
    public async Task<IActionResult> DeleteSkill(int id)
    {
        await _skillRepository.DeleteSkillAsync(id);
        return RedirectToAction("Index", "Skill", new { area = "Admin" });
    }
}
