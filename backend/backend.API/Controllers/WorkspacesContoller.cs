namespace backend.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using backend.Application.UseCases;
using backend.Application.DTOs.Workspace;

public class WorkspacesController : Controller
{
  private readonly WorkspaceUseCase _workspaceUsecase;
  public WorkspacesController(WorkspaceUseCase workspaceUsecase)
  {
    _workspaceUsecase = workspaceUsecase;
  }

  [HttpGet("workspaces")]
  public async Task<IActionResult> GetWorkspaces()
  {
    try
    {
      var workspaces = await _workspaceUsecase.GetWorkspacesAsync();
      return Ok(workspaces);
    }
    catch (Exception)
    {
      return StatusCode(500, "An error occurred while retrieving workspaces.");
    }
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetWorkspace(int id)
  {
    try
    {
      var workspace = await _workspaceUsecase.GetWorkspaceByIdAsync(id);
      if (workspace == null)
      {
        return NotFound();
      }
      return Ok(workspace);
    }
    catch (Exception)
    {
      return StatusCode(500, "An error occurred while retrieving the workspace.");
    }
  }

  [HttpPost]
  public async Task<IActionResult> CreateWorkspace([FromBody] CreateWorkspaceDto dto)
  {
    try
    {
      var createdWorkspace = await _workspaceUsecase.CreateWorkspaceAsync(dto);
      return CreatedAtAction(nameof(GetWorkspace), new { id = createdWorkspace.Id }, createdWorkspace);
    }
    catch (Exception)
    {
      return StatusCode(500, "An error occurred while creating the workspace.");
    }
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateWorkspace(int id, [FromBody] UpdateWorkspaceDto dto)
  {
    try
    {
      var updatedWorkspace = await _workspaceUsecase.UpdateWorkspaceAsync(id, dto);
      if (updatedWorkspace == null)
      {
        return NotFound();
      }
      return Ok(updatedWorkspace);
    }
    catch (Exception)
    {
      return StatusCode(500, "An error occurred while updating the workspace.");
    }
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteWorkspace(int id)
  {
    try
    {
      await _workspaceUsecase.DeleteWorkspaceAsync(id);
      return NoContent();
    }
    catch (Exception)
    {
      return StatusCode(500, "An error occurred while deleting the workspace.");
    }
  }
}

