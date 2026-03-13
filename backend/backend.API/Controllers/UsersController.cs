namespace backend.API.Controllers;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using backend.Infrastructure.Config;
using backend.Domain.Entities;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{ 
  private readonly AppDbContext _context;

  public UsersController(AppDbContext context)
  {
    _context = context;
  }

  [HttpGet]
  public async Task<IActionResult> GetUsers()
  {
    var users = await _context.Users.ToListAsync();
    return Ok(users);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetUser(int id)
  {
    var user = await _context.Users.FindAsync(id);

    if (user == null)
    {
      return NotFound();
    }

    return Ok(user);
  }

  [HttpPost]
  public async Task<IActionResult> CreateUser(User user)
  {
    _context.Users.Add(user);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateUser(int id, User user)
  {
    if(id != user.Id)
    {
      return BadRequest();
    }
    _context.Users.Update(user);
    await _context.SaveChangesAsync();

    return NoContent();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteUser(int id)
  {
    var user = await _context.Users.FindAsync(id);

    if (user == null)
    {
      return NotFound();
    }

    _context.Users.Remove(user);
    await _context.SaveChangesAsync();

    return NoContent();
  }
}