using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Areas.Admin.ViewComponents.AdminLayoutViewComponents;

public class AdminLayoutHeaderComponent: ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
