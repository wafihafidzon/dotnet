using StudentCourse.Domain;

namespace StudentCourse.Services;

public class StudentServices
{
  private readonly List<Student> _students = new();

  public void Create(Student student)
  {
    _students.Add(student);
  }

  public List<Student> GetAll()
  {
    return _students;
  }

  public Student? GetById(Guid Id)
  {
    return _students.FirstOrDefault(x => x.Id == Id);
  }

  public void AddCourse(Student student, Course course)
  {
    student.Courses.Add(course);
  }
}
