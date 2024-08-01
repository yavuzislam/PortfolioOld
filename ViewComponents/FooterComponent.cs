using Microsoft.AspNetCore.Mvc;
using Portfolio.Repositories.FeatureRepositories;
using Portfolio.Repositories.SocialMediaRepositories;

namespace Portfolio.ViewComponents;

public class FooterComponent : ViewComponent
{
    private readonly IFeatureRepository _featureRepository;
    private readonly ISocialMediaRepository _socialMediaRepository;

    public FooterComponent(IFeatureRepository featureRepository, ISocialMediaRepository socialMediaRepository)
    {
        _featureRepository = featureRepository;
        _socialMediaRepository = socialMediaRepository;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        ViewBag.Media = await _socialMediaRepository.GetAllSocialMediaAsync();
        var value = await _featureRepository.GetLastFeatureAsync();
        return View(value);
    }
}