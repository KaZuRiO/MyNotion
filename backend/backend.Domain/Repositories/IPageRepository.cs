namespace backend.Domain.Repositories;
using backend.Domain.Entities;
public interface IPageRepository
{
    Task<IEnumerable<Page>> GetPagesAsync();
    Task<Page> GetPageByIdAsync(int id);
    Task CreatePageAsync(Page page);
    Task UpdatePageAsync(Page page);
    Task DeletePageAsync(int id);
}