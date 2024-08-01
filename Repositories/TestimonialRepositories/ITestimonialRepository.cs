using Portfolio.Models.TestimonialDtos;

namespace Portfolio.Repositories.TestimonialRepositories;

public interface ITestimonialRepository
{
    Task<List<TestimonialDto>> GetAllTestimonialsAsync();
    Task<TestimonialDto> GetTestimonialByIdAsync(int id);
    Task CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto);
    Task UpdateTestimonialAsync(TestimonialDto testimonialDto);
    Task DeleteTestimonialAsync(int id);
}
