using Microsoft.AspNetCore.Mvc;
using Portfolio.Repositories.ExperienceRepositories;

namespace Portfolio.ViewComponents;

public class ExperienceComponent : ViewComponent
{
    private readonly IExperienceRepository _experienceRepository;

    public ExperienceComponent(IExperienceRepository experienceRepository)
    {
        _experienceRepository = experienceRepository;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var values = await _experienceRepository.GetAllExperienceAsync();
        return View(values);
    }
}
