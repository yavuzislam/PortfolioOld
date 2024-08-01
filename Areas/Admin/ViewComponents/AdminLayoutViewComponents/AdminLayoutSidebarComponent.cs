using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Areas.Admin.ViewComponents.AdminLayoutViewComponents;

public class AdminLayoutSidebarComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
