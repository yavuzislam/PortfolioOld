using Microsoft.AspNetCore.Mvc;
using Portfolio.Repositories.TestimonialRepositories;

namespace Portfolio.ViewComponents;

public class TestimonialComponent : ViewComponent
{
    private readonly ITestimonialRepository _testimonialRepository;

    public TestimonialComponent(ITestimonialRepository testimonialRepository)
    {
        _testimonialRepository = testimonialRepository;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var values = await _testimonialRepository.GetAllTestimonialsAsync();
        return View(values);
    }
}
