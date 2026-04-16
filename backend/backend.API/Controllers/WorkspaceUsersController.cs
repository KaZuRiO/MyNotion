namespace backend.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using backend.Application.UseCases;
using backend.Application.DTOs.WorkspaceUser;
using backend.Domain.Entities;

[Route("api/[controller]")]
public class WorkspaceUsersController : Controller
{
  private readonly WorkspaceUserUseCase _workspaceUserUseCase;
  public WorkspaceUsersController(WorkspaceUserUseCase workspaceUserUseCase)
  {
    _workspaceUserUseCase = workspaceUserUseCase;
  }
  [HttpGet]
  public async Task<IActionResult> GetWorkspaceUsers()
  {
    try
    {
      var workspaceUsers = await _workspaceUserUseCase.GetWorkspaceUsersAsync();
      return Ok(workspaceUsers);
    }
    catch (Exception)
    {
      return StatusCode(500, "An error occurred while retrieving workspace users.");
    }
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetWorkspaceUserById(int id)
  {
    try
    {
      var workspaceUser = await _workspaceUserUseCase.GetWorkspaceUserByIdAsync(id);
      if (workspaceUser == null)
      {
        return NotFound();
      }
      return Ok(workspaceUser);
    }
    catch (Exception)
    {
      return StatusCode(500, "An error occurred while retrieving the workspace user.");
    }
  }

  [HttpPost]
  public async Task<IActionResult> CreateWorkspaceUser([FromBody] CreateWorkspaceUserDto dto)
  {
    try
    {
      var createdWorkspaceUser = await _workspaceUserUseCase.CreateWorkspaceUserAsync(dto);
      return CreatedAtAction(nameof(GetWorkspaceUserById), new { id = createdWorkspaceUser.Id }, createdWorkspaceUser);
    }
    catch (Exception)
    {
      return StatusCode(500, "An error occurred while creating the workspace user.");
    }
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateWorkspaceUser(int id, [FromBody] UpdateWorkspaceUserDto dto)
  {
    try
    {
      var updatedWorkspaceUser = await _workspaceUserUseCase.UpdateWorkspaceUserAsync(id, dto);
      if (updatedWorkspaceUser == null)
      {
        return NotFound();
      }
      return Ok(updatedWorkspaceUser);
    }
    catch (Exception)
    {
      return StatusCode(500, "An error occurred while updating the workspace user.");
    }
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteWorkspaceUser(int id)
  {
    try
    {
      await _workspaceUserUseCase.DeleteWorkspaceUserAsync(id);
      return NoContent();
    }
    catch (Exception)
    {
      return StatusCode(500, "An error occurred while deleting the workspace user.");
    }
  }
}