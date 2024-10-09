using Microsoft.AspNetCore.Mvc;
using StudentCourse.Domain;
using StudentCourse.Services;

namespace StudentCourse.Controlelrs;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
  private readonly StudentServices _studentServices;

  public AuthController(StudentServices studentServices)
  {
    _studentServices = studentServices;
  }
  [HttpPost]
  public IActionResult Register(RegisterStudent request)
  {
    var student = request.toDomain();

    _studentServices.Create(student);
    return Ok(student);
  }

  public IActionResult login(string email, string password)
  {
    return Ok();
  }

  public record RegisterStudent(
      string Name,
      string Email,
      string Password)
  {
    public Student toDomain()
    
    {
      return new Student
      {
        Name = Name,
        Email = Email,
        Password = Password
      };
    }
  }
}