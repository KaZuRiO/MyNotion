namespace backend.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using backend.Application.UseCases;
using System.Threading.Tasks;
using backend.Application.DTOs.Role;

[Route("api/[controller]")]
public class RolesController : Controller
{
  private readonly RoleUseCase _roleUsecase;

  public RolesController(RoleUseCase roleUsecase)
  {
    _roleUsecase = roleUsecase;
  }

  [HttpGet]
  public async Task<IActionResult> GetRoles()
  {
    try
    {
      var roles = await _roleUsecase.GetRolesAsync();
      return Ok(roles);
    }
    catch (Exception)
    {
      return StatusCode(500, "An error occurred while retrieving roles.");
    }
  }
  [HttpGet("{id}")]
  public async Task<IActionResult> GetRoleById(int id)
  {
    try    {
      var role = await _roleUsecase.GetRoleByIdAsync(id);
      if (role == null)      {
        return NotFound($"Role with ID {id} not found.");   
      }
      return Ok(role);
    }
    catch (Exception)
    {
      return StatusCode(500, "An error occurred while retrieving the role.");
    }
  }

  [HttpPost]
  public async Task<IActionResult> CreateRole([FromBody] CreateRoleDto dto)
  {
    try
    {
      var createdRole = await _roleUsecase.CreateRoleAsync(dto);
      return CreatedAtAction(nameof(GetRoleById), new { id = createdRole.Id }, createdRole);
    }
    catch (Exception)
    {
      return StatusCode(500, "An error occurred while creating the role.");
    }
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateRole(int id, [FromBody] UpdateRoleDto dto)
  {
    try
    {
      var updatedRole = await _roleUsecase.UpdateRoleAsync(id, dto);
      if (updatedRole == null)
      {
        return NotFound($"Role with ID {id} not found.");
      }
      return Ok(updatedRole);
    }
    catch (Exception)
    {
      return StatusCode(500, "An error occurred while updating the role.");
    }
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteRole(int id)
  {
    try
    {
      await _roleUsecase.DeleteRoleAsync(id);
      return Ok();
    }
    catch (Exception)
    {
      return StatusCode(500, "An error occurred while deleting the role.");
    }
  }
}