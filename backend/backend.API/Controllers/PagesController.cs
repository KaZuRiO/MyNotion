namespace backend.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using backend.Application.UseCases;
using System.Threading.Tasks;
using backend.Application.DTOs.Page;

public class PageController : Controller
{
  private readonly PageUseCase _pageUsecase;
  public PageController(PageUseCase pageUsecase)
  {
    _pageUsecase = pageUsecase;
  }

  [HttpGet("pages")]
  public async Task<IActionResult> GetPages()
  {
    try
    {
      var pages = await _pageUsecase.GetPagesAsync();
      return Ok(pages);
    }
    catch (Exception)
    {
      return StatusCode(500, "An error occurred while retrieving pages.");
    }
  }
  [HttpGet("{id}")]
  public async Task<IActionResult> GetPageById(int id)
  {
    try
    {
      var page = await _pageUsecase.GetPageByIdAsync(id);
      if (page == null)
      {
        return NotFound($"Page with ID {id} not found.");
      }
      return Ok(page);
    }
    catch (Exception)
    {
      return StatusCode(500, "An error occurred while retrieving the page.");
    }
  }


[HttpPost("pages")]
  public async Task<IActionResult> CreatePage([FromBody] CreatePageDto dto)
  {
    try
    {
      var createdPage = await _pageUsecase.CreatePageAsync(dto);
      return CreatedAtAction(nameof(GetPageById), new { id = createdPage.Id }, createdPage);
    }
    catch (Exception)
    {
      return StatusCode(500, "An error occurred while creating the page.");
    }
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> UpdatePage(int id, [FromBody] UpdatePageDto dto)
  {
    try
    {
      var updatedPage = await _pageUsecase.UpdatePageAsync(id, dto);
      if (updatedPage == null)
      {
        return NotFound($"Page with ID {id} not found.");
      }
      return Ok(updatedPage);
    }
    catch (Exception)
    {
      return StatusCode(500, "An error occurred while updating the page.");
    }
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeletePage(int id)
  {
    try
    {
      await _pageUsecase.DeletePageAsync(id);
      return NoContent();
    }
    catch (Exception)
    {
      return StatusCode(500, "An error occurred while deleting the page.");
    }
  }
}