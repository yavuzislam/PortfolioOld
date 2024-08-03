using Portfolio.Models.FooterDtos;

namespace Portfolio.Repositories.FooterRepositories;

public interface IFooterRepository
{
    Task<List<FooterDto>> GetAllFooterAsync();
    Task<FooterDto> GetLastFooterAsync();
    Task<FooterDto> GetFooterByIdAsync(int id);
    Task CreateFooterAsync(CreateFooterDto createFooterDto);
    Task UpdateFooterAsync(FooterDto FooterDto);
    Task DeleteFooterAsync(int id);
}
