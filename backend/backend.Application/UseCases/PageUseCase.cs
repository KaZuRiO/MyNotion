namespace backend.Application.UseCases;
using backend.Domain.Entities;
using backend.Domain.Repositories;
using backend.Application.DTOs.Page;
public class PageUseCase
{
    private readonly IPageRepository _pageRepository;
    // private readonly ITraductionService _traductionService;
    public PageUseCase(IPageRepository pageRepository)
    {
        _pageRepository = pageRepository;
    }

    public async Task<IEnumerable<PageDto>> GetPagesAsync()
    {
        var pages = await _pageRepository.GetPagesAsync();
        return pages.Select(page => new PageDto
        {
            Id = page.Id,
            Title = page.Title,
            Content = page.Content,
            Icon = page.Icon,
            ParentPageId = page.ParentPageId,
            WorkspaceId = page.WorkspaceId,
            CreatedById = page.CreatedById,
            CreatedAt = page.CreatedAt,
            UpdatedAt = page.UpdatedAt
        });
    }
    public async Task<PageDto?> GetPageByIdAsync(int id)
    {
        var page = await _pageRepository.GetPageByIdAsync(id);
        if (page == null) return null;

        return new PageDto
        {
            Id = page.Id,
            Title = page.Title,
            Content = page.Content,
            Icon = page.Icon,
            ParentPageId = page.ParentPageId,
            WorkspaceId = page.WorkspaceId,
            CreatedById = page.CreatedById,
            CreatedAt = page.CreatedAt,
            UpdatedAt = page.UpdatedAt
        };
    }
    public async Task<PageDto> CreatePageAsync(CreatePageDto dto)
    {
        var page = new Page
        {
            Title = dto.Title,
            Content = dto.Content,
            Icon = dto.Icon,
            WorkspaceId = dto.WorkspaceId,
            CreatedById = dto.CreatedById,
            ParentPageId = dto.ParentPageId
        };
        await _pageRepository.CreatePageAsync(page);
        return new PageDto
        {
            Id = page.Id,
            Title = page.Title,
            Content = page.Content,
            Icon = page.Icon,
            ParentPageId = page.ParentPageId,
            WorkspaceId = page.WorkspaceId,
            CreatedById = page.CreatedById,
            CreatedAt = page.CreatedAt,
            UpdatedAt = page.UpdatedAt
        };
    }
    public async Task<PageDto?> UpdatePageAsync(int id, UpdatePageDto dto)
    {
        var page = await _pageRepository.GetPageByIdAsync(id);
        if (page == null) return null;

        page.Title = dto.Title;
        page.Content = dto.Content;
        page.Icon = dto.Icon;
        page.ParentPageId = dto.ParentPageId;
        page.UpdatedAt = DateTime.UtcNow;

        await _pageRepository.UpdatePageAsync(page);

        return new PageDto
        {
            Id = page.Id,
            Title = page.Title,
            Content = page.Content,
            Icon = page.Icon,
            ParentPageId = page.ParentPageId,
            WorkspaceId = page.WorkspaceId,
            CreatedById = page.CreatedById,
            CreatedAt = page.CreatedAt,
            UpdatedAt = page.UpdatedAt
        };
    }
    public async Task DeletePageAsync(int id)
    {
        await _pageRepository.DeletePageAsync(id);
    }
}