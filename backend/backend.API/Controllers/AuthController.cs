namespace backend.API.Controllers;

using backend.Domain.Entities;
using backend.Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using backend.Application.DTOs.Auth;
using Microsoft.AspNetCore.Authorization;

[Route("api/[controller]")]
[ApiController]

public class AuthController : Controller
{
  private readonly AuthUseCase _authUsecase;

  public AuthController(AuthUseCase authUsecase)
  {
    _authUsecase = authUsecase;
  }
  [AllowAnonymous]
  [HttpPost("Login")]
  public async Task<IActionResult> LoginUser(LoginUserDto loginUserDto)
  {
    try
    {
      var response = await _authUsecase.LoginUserAsync(loginUserDto);
      if (!response.Flag)
        return BadRequest(response.Message);
      return Ok(response);
    }
    catch (Exception ex)
    {
      return StatusCode(500, "An error occurred while logging in: " + ex.Message);
    }
  }
  [AllowAnonymous]
  [HttpPost("Register")]
  public async Task<IActionResult> RegisterUser(RegisterUserDto registerUserDto)
  {
    try
    {
      var response = await _authUsecase.RegisterUserAsync(registerUserDto);
      if (!response.Flag)
        return BadRequest(response.Message);
      return Ok(response);
    }
    catch (Exception)
    {
      return StatusCode(500, "An error occurred while registering.");
    }
  }



}