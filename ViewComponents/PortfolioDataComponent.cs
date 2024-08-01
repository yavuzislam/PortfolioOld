using Microsoft.AspNetCore.Mvc;
using Portfolio.Repositories.PortfolioDataRepositories;

namespace Portfolio.ViewComponents;

public class PortfolioDataComponent : ViewComponent
{
    private readonly IPortfolioDataRepository _portfolioDataRepository;

    public PortfolioDataComponent(IPortfolioDataRepository portfolioDataRepository)
    {
        _portfolioDataRepository = portfolioDataRepository;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var values = await _portfolioDataRepository.GetAllPortfolioDataAsync();
        return View(values);
    }
}
