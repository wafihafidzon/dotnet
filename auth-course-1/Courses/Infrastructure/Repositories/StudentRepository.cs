using Courses.Domain.Entities;
using Courses.Domain.Interfaces;

namespace Courses.Infrastrutre.Repositories
{
  public class StudentRepository : IStudentRepository
  {
    private List<Student> _students =  new List<Student>();

    public List<Student> GetStudents() => _students;

    public Student? GetStudentById(Guid id) => _students.FirstOrDefault(x => x.Id == id);

    public void AddStudent(Student student) => _students.Add(student);

    public void UpdateStudent(Student student) 
    {
      var existingStudent = _students.FirstOrDefault(x => x.Id == student.Id);
      if (existingStudent != null) 
      {
        existingStudent.Name = student.Name;
        existingStudent.Email = student.Email;
      }
    }

    public void DeleteStudent(Guid id) {
      var student = _students.FirstOrDefault(x => x.Id == id);
      if (student != null) 
      {
        _students.Remove(student);
      }
    }
    
  }
}
