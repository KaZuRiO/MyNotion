namespace backend.API.Controllers;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using backend.Infrastructure.Config;
using backend.Domain.Entities;

[ApiController]
[Route("[controller]")]
public class RolesController : ControllerBase
{ 
  private readonly AppDbContext _context;

  public RolesController(AppDbContext context)
  {
    _context = context;
  }

  [HttpGet]

  public async Task<IActionResult> GetRoles()
  {
    var roles = await _context.Roles.ToListAsync();
    return Ok(roles);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetRole(int id)
  {
    var role = await _context.Roles.FindAsync(id);

    if (role == null)
    {
      return NotFound();
    }

    return Ok(role);
  }

  [HttpPost]
  public async Task<IActionResult> CreateRole(Role role)
  {
    _context.Roles.Add(role);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetRole), new { id = role.Id }, role);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateRole(int id, Role role)
  {
    if(id != role.Id)
    {
      return BadRequest();
    }
    _context.Roles.Update(role);
    await _context.SaveChangesAsync();

    return NoContent();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteRole(int id)
  {
    var role = await _context.Roles.FindAsync(id);

    if (role == null)
    {
      return NotFound();
    }

    _context.Roles.Remove(role);
    await _context.SaveChangesAsync();

    return NoContent();
  }
}
