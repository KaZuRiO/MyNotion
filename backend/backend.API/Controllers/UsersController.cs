namespace backend.API.Controllers;

using backend.Domain.Entities;
using backend.Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using backend.Application.DTOs.User;

public class UsersController : Controller
{
  private readonly UserUseCase _userUsecase;

  public UsersController(UserUseCase userUsecase)
  {
    _userUsecase = userUsecase;
  }

  [HttpGet("users")]
  public async Task<IActionResult> GetUsers()
  {
    try
    {
      var users = await _userUsecase.GetUsersAsync();
      return Ok(users);
    }
    catch (Exception)
    {
      return StatusCode(500, "An error occurred while retrieving users.");
    }
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetUserById(int id)
  {
    try
    {
      var user = await _userUsecase.GetUserByIdAsync(id);
      if (user == null)
      {
        return NotFound($"User with ID {id} not found.");
      }
      return Ok(user);
    }
    catch (Exception)
    {
      return StatusCode(500, "An error occurred while retrieving the user.");
    }
  }
  [HttpPost("users")]
  public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
  {
    try
    {
      var createdUser = await _userUsecase.CreateUserAsync(createUserDto);
      return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
    }
    catch (Exception)
    {
      return StatusCode(500, "An error occurred while creating the user.");
    }
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDto updateUserDto)
  {
    try
    {
      var updatedUser = await _userUsecase.UpdateUserAsync(id, updateUserDto);
      if (updatedUser == null)
      {
        return NotFound($"User with ID {id} not found.");
      }
      return Ok(updatedUser);
    }
    catch (Exception)
    {
      return StatusCode(500, "An error occurred while updating the user.");
    }
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteUser(int id)
  {
    try
    {
      await _userUsecase.DeleteUserAsync(id);
      return NoContent();
    }
    catch (Exception)
    {
      return StatusCode(500, "An error occurred while deleting the user.");
    }
  }


}