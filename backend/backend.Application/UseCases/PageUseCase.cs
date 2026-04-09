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
}