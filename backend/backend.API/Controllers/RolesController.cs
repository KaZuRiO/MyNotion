namespace backend.API.Controllers;
using backend.Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

public class RolesController : ControllerBase
{
  private readonly RoleUseCase _roleUsecase;

  public RolesController(RoleUseCase roleUsecase)
  {
    _roleUsecase = roleUsecase;
  }

  [HttpGet]
  public IActionResult Index()
  {
    return Ok("Roles API is running");
  }

  [HttpGet("roles")]
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
}