using Microsoft.AspNetCore.Mvc;
using Portfolio.Repositories.AboutRepositories;

namespace Portfolio.ViewComponents;

public class AboutComponent : ViewComponent
{
    private readonly IAboutRepository _aboutRepository;

    public AboutComponent(IAboutRepository aboutRepository)
    {
        _aboutRepository = aboutRepository;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var value = await _aboutRepository.GetLastAbout();
        return View(value);
    }
}
