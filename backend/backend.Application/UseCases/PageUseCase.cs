namespace backend.Application.UseCases;
using backend.Domain.Entities;
using backend.Domain.Repositories;
public class PageUseCase
{
    private readonly IPageRepository _pageRepository;
    // private readonly ITraductionService _traductionService;

    public PageUseCase(IPageRepository pageRepository)
    {
        _pageRepository = pageRepository;
    }

    public async Task<IEnumerable<Page>> GetPagesAsync()
    {
        var pages = await _pageRepository.GetPagesAsync();
        // Can modify data and call other services
        return pages;
    }
    public async Task<Page> GetPageByIdAsync(int id)
    {
        var page = await _pageRepository.GetPageByIdAsync(id);
        // Can modify data and call other services
        return page;
    }
    public async Task CreatePageAsync(Page page)
    {
        // Can modify data and call other services
        await _pageRepository.CreatePageAsync(page);
    }
    public async Task UpdatePageAsync(Page page)
    {
        // Can modify data and call other services
        await _pageRepository.UpdatePageAsync(page);
    }
    public async Task DeletePageAsync(int id)
    {
        // Can modify data and call other services
        await _pageRepository.DeletePageAsync(id);
    }
}