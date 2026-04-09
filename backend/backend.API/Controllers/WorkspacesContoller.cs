namespace backend.API.Controllers;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using backend.Infrastructure.Config;
using backend.Domain.Entities;

[ApiController]
[Route("[controller]")]
public class WorkspacesController : ControllerBase
{ 
  private readonly AppDbContext _context;

  public WorkspacesController(AppDbContext context)
  {
    _context = context;
  }

  [HttpGet]
  public async Task<IActionResult> GetWorkspaces()
  {
    var workspaces = await _context.Workspaces.ToListAsync();
    return Ok(workspaces);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetWorkspace(int id)
  {
    var workspace = await _context.Workspaces.FindAsync(id);

    if (workspace == null)
    {
      return NotFound();
    }

    return Ok(workspace);
  }

  [HttpPost]
  public async Task<IActionResult> CreateWorkspace(Workspace workspace)
  {
    _context.Workspaces.Add(workspace);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetWorkspace), new { id = workspace.Id }, workspace);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateWorkspace(int id, Workspace workspace)
  {
    if(id != workspace.Id)
    {
      return BadRequest();
    }
    _context.Workspaces.Update(workspace);
    await _context.SaveChangesAsync();

    return NoContent();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteWorkspace(int id)
  {
    var workspace = await _context.Workspaces.FindAsync(id);

    if (workspace == null)
    {
      return NotFound();
    }

    _context.Workspaces.Remove(workspace);
    await _context.SaveChangesAsync();

    return NoContent();
  }
}