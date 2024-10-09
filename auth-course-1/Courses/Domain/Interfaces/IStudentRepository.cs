using Courses.Domain.Entities;

namespace Courses.Domain.Interfaces
{
  public interface IStudentRepository
  {
    List<Student> GetStudents();
    Student? GetStudentById(Guid id);
    void AddStudent(Student student);
    void UpdateStudent(Student student);
    void DeleteStudent(Guid id);
  }
}