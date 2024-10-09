using Courses.Domain.Entities;
using Courses.Domain.Interfaces;

namespace Courses.Application.Services
{
  public class StudentAuthService
  {
    private readonly IStudentRepository _studentRepository;

    public StudentAuthService(IStudentRepository studentRepository)
    {
      _studentRepository = studentRepository;
    }

    public Student? Login(string email, string password)
    {
      return _studentRepository.Authenticate(email, password);
    }

    public Student? ValidateToken(string token)
    {
      return _studentRepository.GetStudentByToken(token);
    }

    public void Logout(string token)
    {
      var student = _studentRepository.GetStudentByToken(token);
      if (student != null)
      {
        _studentRepository.InvalidateToken(student);
      }
    }
  }
}
