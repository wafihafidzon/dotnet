using Microsoft.AspNetCore.Mvc;
using Courses.Application.Services;

namespace Courses.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AuthController : ControllerBase
  {
    private readonly StudentAuthService _authService;

    public AuthController(StudentAuthService authService)
    {
      _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest loginRequest)
    {
      var student = _authService.Login(loginRequest.Email, loginRequest.Password);
      if (student == null)
        return Unauthorized("Invalid credentials");

      return Ok(new { Token = student.AuthToken });
    }

    [HttpGet("validate")]
    public IActionResult ValidateToken([FromHeader] string token)
    {
      var student = _authService.ValidateToken(token);
      if (student == null)
        return Unauthorized("Invalid token");

      return Ok(student);
    }

    [HttpPost("logout")]
    public IActionResult Logout([FromHeader] string token)
    {
      _authService.Logout(token);
      return NoContent();
    }
  }

  public class LoginRequest
  {
    public required string Email { get; set; }
    public required string Password { get; set; }
  }
}
