namespace backend.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using backend.Application.UseCases;
using System.Threading.Tasks;

public class PageController : Controller
{
  private readonly PageUseCase _pageUsecase;

  public PageController(PageUseCase pageUsecase)
  {
    _pageUsecase = pageUsecase;
  }

  public IActionResult Index()
  {
    return View();
  }
  public async Task<IActionResult> GetPages()
  {
    try
    {
      var pages = await _pageUsecase.GetPagesAsync();
      return Ok(pages);
    }
    catch (Exception ex)
    {
      // Log the exception (ex) here if needed
      return StatusCode(500, "An error occurred while retrieving pages.");
    }
  }
  // public async Task<IActionResult> GetPageById(int id)
  // {
  //   return Ok(await _pageUsecase.GetPageByIdAsync(id));
  // }
}