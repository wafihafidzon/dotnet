using Courses.Domain.Entities;

namespace Courses.Domain.Interfaces
{
  public interface IStudentRepository
  {
    List<Student> GetAllStudents();
    Student? GetStudentByEmail(string email);
    Student? GetStudentById(Guid id);
    void AddStudent(Student student);
    void UpdateStudent(Student student);
    void DeleteStudent(Guid id);
    Student? Authenticate(string email, string password);
    Student? GetStudentByToken(string token);
    void InvalidateToken(Student student);
  }
}
