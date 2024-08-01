using Portfolio.Models.PortfolioDataDtos;

namespace Portfolio.Repositories.PortfolioDataRepositories;

public interface IPortfolioDataRepository
{
    Task<List<PortfolioDataDto>> GetAllPortfolioDataAsync();
    Task<PortfolioDataDto> GetPortfolioDataByIdAsync(int id);
    Task CreatePortfolioDataAsync(CreatePortfolioDataDto createPortfolioDataDto);
    Task UpdatePortfolioDataAsync(PortfolioDataDto portfolioDataDto);
    Task DeletePortfolioDataAsync(int id);
}
