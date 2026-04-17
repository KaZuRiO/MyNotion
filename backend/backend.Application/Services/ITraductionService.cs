using backend.Domain.Entities;
namespace backend.Application.Services;
public interface ITraductionService 
{
    void Translate(IEnumerable<Page> pages);
}
