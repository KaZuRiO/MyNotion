namespace backend.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

using backend.Application.DTOs.Auth;
using backend.Application.Services;
using Microsoft.EntityFrameworkCore;
using backend.Infrastructure.Config;
using backend.Domain.Entities;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using System;


public class AuthRepository : IAuthRepository
{
  private readonly AppDbContext _context;
  private readonly IConfiguration _configuration;

  public AuthRepository(AppDbContext context, IConfiguration configuration)
  {
    _context = context;
    _configuration = configuration;
  }

  public async Task<LoginResponse> LoginUserAsync(LoginUserDto loginUserDto)
  {
    var getUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginUserDto.Email);
    if (getUser == null)
      return new LoginResponse(false, "User not found");
    bool checkPassword = BCrypt.Verify(loginUserDto.Password, getUser.Password);
    if (checkPassword)
      return new LoginResponse(true, "Login successful", GenerateJWTToken(getUser));
    else
      return new LoginResponse(false, "Invalid credentials");
  }



  public async Task<RegistrationResponse> RegisterUserAsync(RegisterUserDto registerUserDto)
  {
    var getUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == registerUserDto.Email);
    if (getUser != null)
      return new RegistrationResponse(false, "User already exists");
    _context.Users.Add(new User
    {
      Username = registerUserDto.Username,
      Email = registerUserDto.Email,
      Password = BCrypt.HashPassword(registerUserDto.Password)
    });
    await _context.SaveChangesAsync();
    return new RegistrationResponse(true, "Registration successful");
  }

  private string GenerateJWTToken(User user)
  {
    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
    var userClaims = new[]
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.Username!),
        new Claim(ClaimTypes.Email, user.Email!)
    };
    var token = new JwtSecurityToken(
        issuer: _configuration["Jwt:Issuer"],
        audience: _configuration["Jwt:Audience"],
        claims: userClaims,
        expires: DateTime.Now.AddDays(5),
        signingCredentials: credentials
    );
    return new JwtSecurityTokenHandler().WriteToken(token);
  }
}

