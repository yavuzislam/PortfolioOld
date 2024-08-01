using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Repositories.SocialMediaRepositories;
using System.Diagnostics;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISocialMediaRepository _socialMediaRepository;

        public HomeController(ILogger<HomeController> logger, ISocialMediaRepository socialMediaRepository)
        {
            _logger = logger;
            _socialMediaRepository = socialMediaRepository;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Media = await _socialMediaRepository.GetAllSocialMediaAsync();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
