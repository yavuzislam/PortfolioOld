using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models.TestimonialDtos;

namespace Portfolio.Repositories.TestimonialRepositories;

public class TestimonialRepository : ITestimonialRepository
{
    private readonly Context _context;

    public TestimonialRepository(Context context)
    {
        _context = context;
    }
    public async Task<List<TestimonialDto>> GetAllTestimonialsAsync()
    {
        var values = await _context.Testimonials.ToListAsync();
        return values.Select(x => new TestimonialDto
        {
            Id = x.Id,
            Name = x.Name,
            Title = x.Title,
            ImagePath = x.ImagePath,
            Comment = x.Comment
        }).ToList();
    }

    public async Task CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto)
    {
        await _context.Testimonials.AddAsync(new Testimonial
        {
            Name = createTestimonialDto.Name,
            Title = createTestimonialDto.Title,
            ImagePath = createTestimonialDto.ImagePath,
            Comment = createTestimonialDto.Comment
        });
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTestimonialAsync(int id)
    {
        var value = await _context.Testimonials.FindAsync(id);
        _context.Testimonials.Remove(value);
        await _context.SaveChangesAsync();
    }


    public async Task<TestimonialDto> GetTestimonialByIdAsync(int id)
    {
        var value = await _context.Testimonials.FindAsync(id);
        return new TestimonialDto
        {
            Id = value.Id,
            Name = value.Name,
            Title = value.Title,
            ImagePath = value.ImagePath,
            Comment = value.Comment
        };
    }

    public async Task UpdateTestimonialAsync(TestimonialDto testimonialDto)
    {
        var value = await _context.Testimonials.FindAsync(testimonialDto.Id);
        value.Name = testimonialDto.Name;
        value.Title = testimonialDto.Title;
        value.ImagePath = testimonialDto.ImagePath;
        value.Comment = testimonialDto.Comment;
        await _context.SaveChangesAsync();
    }
}
