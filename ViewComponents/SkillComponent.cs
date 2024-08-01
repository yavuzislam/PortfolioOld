using Microsoft.AspNetCore.Mvc;
using Portfolio.Repositories.SkillRepositories;

namespace Portfolio.ViewComponents;

public class SkillComponent : ViewComponent
{
    private readonly ISkillRepository _skillRepository;

    public SkillComponent(ISkillRepository skillRepository)
    {
        _skillRepository = skillRepository;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var values = await _skillRepository.GetAllSkillsAsync();
        return View(values);
    }
}
