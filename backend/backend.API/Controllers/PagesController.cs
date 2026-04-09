namespace backend.API.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using backend.Infrastructure.Config;
using backend.Domain.Entities;

[ApiController]
[Route("[controller]")]
public class PagesController : ControllerBase
{ 
  private readonly AppDbContext _context;

  public PagesController(AppDbContext context)
  {
    _context = context;
  }

  [HttpGet]
  public async Task<IActionResult> GetPages()
  {
    var pages = await _context.Pages.ToListAsync();
    return Ok(pages);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetPage(int id)
  {
    var page = await _context.Pages.FindAsync(id);

    if (page == null)
    {
      return NotFound();
    }

    return Ok(page);
  }

  [HttpPost]
  public async Task<IActionResult> CreatePage(Page page)
  {
    _context.Pages.Add(page);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetPage), new { id = page.Id }, page);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> UpdatePage(int id, Page page)
  {
    if(id != page.Id)
    {
      return BadRequest();
    }
    _context.Pages.Update(page);
    await _context.SaveChangesAsync();

    return NoContent();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeletePage(int id)
  {
    var page = await _context.Pages.FindAsync(id);

    if (page == null)
    {
      return NotFound();
    }

    _context.Pages.Remove(page);
    await _context.SaveChangesAsync();

    return NoContent();
  }
}
