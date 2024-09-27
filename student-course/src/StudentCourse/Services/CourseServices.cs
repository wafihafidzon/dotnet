using StudentCourse.Domain;

namespace StudentCourse.Services;

public class CourseServices
{
  private readonly List<Course> _courses = new();

  public void Create(Course course)
  {
    _courses.Add(course);
  }

  public List<Course> GetAll()
  {
    return _courses;
  }

  public Course? GetById(Guid Id)
  {
    return _courses.FirstOrDefault(x => x.Id == Id);
  }
}
