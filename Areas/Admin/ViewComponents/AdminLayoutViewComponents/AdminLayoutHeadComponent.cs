using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Areas.Admin.ViewComponents.AdminLayoutViewComponents;

public class AdminLayoutHeadComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}