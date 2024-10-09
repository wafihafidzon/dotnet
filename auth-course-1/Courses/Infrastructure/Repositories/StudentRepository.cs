using Courses.Domain.Entities;
using Courses.Domain.Interfaces;

namespace Courses.Infrastrutre.Repositories
{
  public class StudentRepository : IStudentRepository
  {
    private List<Student> _students = new List<Student>();

    public List<Student> GetAllStudents() => _students;

    public Student? GetStudentById(Guid id) => _students.FirstOrDefault(s => s.Id == id);

    public Student? GetStudentByEmail(string email) => _students.FirstOrDefault(s => s.Email == email);

    public void AddStudent(Student student)
    {
      student.Id = Guid.NewGuid();
      _students.Add(student);
    }

    public void UpdateStudent(Student student)
    {
      var existingStudent = GetStudentById(student.Id);
      if (existingStudent != null)
      {
        existingStudent.Name = student.Name;
        existingStudent.Email = student.Email;
        existingStudent.Password = student.Password;
        existingStudent.Courses = student.Courses;
        existingStudent.AuthToken = student.AuthToken;
      }
    }

    public void DeleteStudent(Guid id)
    {
      var student = GetStudentById(id);
      if (student != null)
      {
        _students.Remove(student);
      }
    }

    public Student? Authenticate(string email, string password)
    {
      var student = GetStudentByEmail(email);
      if (student != null && BCrypt.Net.BCrypt.Verify(password, student.Password))
      {
        student.AuthToken = GenerateToken();
        return student;
      }
      return null;
    }

    public Student? GetStudentByToken(string token) => _students.FirstOrDefault(s => s.AuthToken == token);

    public void InvalidateToken(Student student)
    {
      student.AuthToken = null;
    }

    private string GenerateToken()
    {
      return Guid.NewGuid().ToString("N");
    }

  }
}
