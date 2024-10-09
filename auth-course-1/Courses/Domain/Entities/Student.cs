namespace Courses.Domain.Entities;

using BCrypt.Net;

public class Student
{
  public Guid Id { get; set; } = Guid.NewGuid();
  public required string Name { get; set; }
  public required string Email { get; set; }

  private string _password = string.Empty;
  public string Password
  {
    get => _password;
    set => _password = BCrypt.HashPassword(value);
  }

  public List<Course> Courses { get; set; } = new List<Course>();

  public string? AuthToken { get; set; }
}
