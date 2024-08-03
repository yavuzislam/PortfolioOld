using Microsoft.AspNetCore.Mvc;
using Portfolio.Repositories.FeatureRepositories;
using Portfolio.Repositories.FooterRepositories;
using Portfolio.Repositories.SocialMediaRepositories;

namespace Portfolio.ViewComponents;

public class FooterComponent : ViewComponent
{
    private readonly IFooterRepository _footerRepository;
    private readonly ISocialMediaRepository _socialMediaRepository;

    public FooterComponent(IFooterRepository footerRepository, ISocialMediaRepository socialMediaRepository)
    {
        _footerRepository = footerRepository;
        _socialMediaRepository = socialMediaRepository;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        ViewBag.Media = await _socialMediaRepository.GetAllSocialMediaAsync();
        var footer = await _footerRepository.GetLastFooterAsync();
        return View(footer);
    }

}