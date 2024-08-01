using Microsoft.AspNetCore.Mvc;
using Portfolio.Models.TestimonialDtos;
using Portfolio.Repositories.TestimonialRepositories;

namespace Portfolio.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/Testimonial")]
public class TestimonialController : Controller
{
    private readonly ITestimonialRepository _TestimonialRepository;

    public TestimonialController(ITestimonialRepository TestimonialRepository)
    {
        _TestimonialRepository = TestimonialRepository;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var values = await _TestimonialRepository.GetAllTestimonialsAsync();
        return View(values);
    }

    [HttpGet]
    [Route("CreateTestimonial")]
    public IActionResult CreateTestimonial()
    {
        return View();
    }

    [HttpPost]
    [Route("CreateTestimonial")]
    public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
    {
        if (ModelState.IsValid)
        {
            await _TestimonialRepository.CreateTestimonialAsync(createTestimonialDto);
            return RedirectToAction("Index", "Testimonial", new { area = "Admin" });
        }

        return View(createTestimonialDto);
    }

    [Route("UpdateTestimonial/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateTestimonial(int id)
    {
        var value = await _TestimonialRepository.GetTestimonialByIdAsync(id);
        return View(value);
    }

    [Route("UpdateTestimonial/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateTestimonial(TestimonialDto TestimonialDto)
    {
        if (ModelState.IsValid)
        {
            await _TestimonialRepository.UpdateTestimonialAsync(TestimonialDto);
            return RedirectToAction("Index", "Testimonial", new { area = "Admin" });
        }

        return View(TestimonialDto);
    }

    [Route("DeleteTestimonial/{id}")]
    public async Task<IActionResult> DeleteTestimonial(int id)
    {
        await _TestimonialRepository.DeleteTestimonialAsync(id);
        return RedirectToAction("Index", "Testimonial", new { area = "Admin" });
    }
}
