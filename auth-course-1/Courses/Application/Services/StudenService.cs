using Courses.Domain.Entities;
using Courses.Domain.Interfaces;

namespace Courses.Application.Services
{
  public class StudentService
  {
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
      _studentRepository = studentRepository;
    }

    public List<Student> GetStudents() => _studentRepository.GetStudents();
    public Student? GetStudentById(Guid id) => _studentRepository.GetStudentById(id);
    public void AddStudent(Student student) => _studentRepository.AddStudent(student);
    public void UpdateStudent(Student student) => _studentRepository.UpdateStudent(student);
    public void DeleteStudent(Guid id) => _studentRepository.DeleteStudent(id);
  }
}