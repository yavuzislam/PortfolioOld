using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models.PortfolioDataDtos;

namespace Portfolio.Repositories.PortfolioDataRepositories;

public class PortfolioDataRepository : IPortfolioDataRepository
{
    private readonly Context _context;

    public PortfolioDataRepository(Context context)
    {
        _context = context;
    }
    public async Task<List<PortfolioDataDto>> GetAllPortfolioDataAsync()
    {
        var values = await _context.PortfolioDatas.ToListAsync();
        return values.Select(x => new PortfolioDataDto
        {
            Id = x.Id,
            Name = x.Name,
            Url = x.Url,
            ImagePath = x.ImagePath
        }).ToList();
    }

    public async Task CreatePortfolioDataAsync(CreatePortfolioDataDto createPortfolioDataDto)
    {
        await _context.PortfolioDatas.AddAsync(new PortfolioData
        {
            Name = createPortfolioDataDto.Name,
            Url = createPortfolioDataDto.Url,
            ImagePath = createPortfolioDataDto.ImagePath
        });
        await _context.SaveChangesAsync();
    }

    public async Task DeletePortfolioDataAsync(int id)
    {
        var value = await _context.PortfolioDatas.FindAsync(id);
        _context.PortfolioDatas.Remove(value);
        await _context.SaveChangesAsync();
    }


    public async Task<PortfolioDataDto> GetPortfolioDataByIdAsync(int id)
    {
        var value = await _context.PortfolioDatas.FindAsync(id);
        return new PortfolioDataDto
        {
            Id = value.Id,
            Name = value.Name,
            Url = value.Url,
            ImagePath = value.ImagePath
        };
    }

    public async Task UpdatePortfolioDataAsync(PortfolioDataDto portfolioDataDto)
    {
        var value = await _context.PortfolioDatas.FindAsync(portfolioDataDto.Id);
        value.Name = portfolioDataDto.Name;
        value.Url = portfolioDataDto.Url;
        value.ImagePath = portfolioDataDto.ImagePath;
        await _context.SaveChangesAsync();
    }
}
